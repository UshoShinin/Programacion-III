using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFProductos
{
    [DataContract]
    public class DtoProducto
    {
        [DataMember]
        public int cod { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Peso { get; set; }
        [DataMember]
        public string Rut { get; set; }
    }
}