using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesPortLog
{
    public class Producto
    {
        #region Atributos
        private int cod;
        private string nombre;
        private int peso;
        private long rut;
        #endregion

        #region Propiedades
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
        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public long Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        #endregion

    }
}
