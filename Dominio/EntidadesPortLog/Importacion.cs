using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Dominio.EntidadesPortLog
{
    public class Importacion
    {
        private int cod;

        private string nombre;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
