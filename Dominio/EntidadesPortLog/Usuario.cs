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

    }
}
