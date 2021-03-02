using BL.ERP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL.ERP.ProductosServiciosBL;

namespace Win.ERP
{
    public partial class FormProductosServicios : Form
    {
        ProductosServiciosBL _ProductosServicios;

        public FormProductosServicios()
        {
            InitializeComponent();

            _ProductosServicios = new ProductosServiciosBL();
            productosServiciosBL_ProductosServiciosBindingSource.DataSource = _ProductosServicios.ObtenerProductosServicios();
        }

        private void FormProductosServicios_Load(object sender, EventArgs e)
        {

        }

        private void productosServiciosBL_ProductosServiciosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void activoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ProductosServicios.AgregarProductosServicios();
            productosServiciosBL_ProductosServiciosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorDeleteItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void productosServiciosBL_ProductosServiciosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            productosServiciosBL_ProductosServiciosBindingSource.EndEdit();
            var productosservicios = (ProductosServicios)productosServiciosBL_ProductosServiciosBindingSource.Current;

            var resultado = _ProductosServicios.GuardarProductosServicios(productosservicios);

            if(resultado.Exitoso == true)
            {
                productosServiciosBL_ProductosServiciosBindingSource.ResetBindings(false);
                MessageBox.Show("Su Producto/Servicio ha sido guardado exitosamente");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

            DeshabilitarHabilitarBotones(true);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(codigoTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var codigo = Convert.ToInt32(codigoTextBox.Text);
                    Eliminar(codigo);
                    MessageBox.Show("Registro eliminado exitosamente.");
                }
            }
        }

        private void Eliminar(int codigo)
        {
            
            var resultado = _ProductosServicios.EliminarProductosServicios(codigo);

            if (resultado == true)
            {
                productosServiciosBL_ProductosServiciosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al querer eliminar el  producto.");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
