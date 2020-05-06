using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WCFProductos
{
    public class DtoImportacion
    {
        [DataMember]
        public int Cod { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaSalidaPrevista { get; set; }
        [DataMember]
        public DtoProducto Producto { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public int precio { get; set; }
        [DataMember]
        public string Entregado { get; set; }

        //public bool Validar()
        //{
        //    return FechaIngreso <= FechaSalidaPrevista;
        //}
    }
}