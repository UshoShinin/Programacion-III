using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dominio.EntidadesPortLog
{
    public class Usuario
    {
        private int ci;
        private string password;
        private string rol;

        public int CI
        {
            get { return ci; }
            set { ci = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public bool ValidarUsuario() {
            bool May = false;
            bool Min = false;
            bool Num = false;
            byte[] bytes = Encoding.ASCII.GetBytes(Password);
            foreach (byte B in bytes) {
                if (B > 47 && B < 58) Num = true;
                else if (B > 64 && B < 91) May = true;
                else if (B > 96 && B < 123) Min = true;
            }
            return (ci > 999999 && ci < 100000000) && Password.Length>5 && May && Min && Num &&(Rol.ToLower()=="admin"|| Rol.ToLower() == "deposito");
        }

    }
}
