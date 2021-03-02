using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ERP
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario, string contraseña)
        {
            if (usuario == "Admin" && contraseña == "123456")
            {
                return true;
            } else
            {
                if (usuario == "Invitado" && contraseña == "000000")
                {
                    return true;
                }

                return false;
              }
        }

    }
}
