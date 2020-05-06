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
        #region Atributos
        private int cod;
        private DateTime fechaIngreso;
        private DateTime fechaSalidaPrevista;
        private Producto producto;
        private int cantidad;
        private int precio;
        private string entregado;

        #endregion


        #region Propiedades

        public int Cod
        
        {
            get { return cod; }
            set { cod = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        
        public DateTime FechaSalidaPrevista
        {
            get { return fechaSalidaPrevista; }
            set { fechaSalidaPrevista = value; }
        }


        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }


        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Entregado
        {
            get { return entregado; }
            set { entregado = value; }
        }

        #endregion

    }
}
