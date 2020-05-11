using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//AGREGADO
using System.Text.RegularExpressions;

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

        #region Redefiniciones de Object
        public override string ToString()
        {
            return this.CI.ToString() + " "
                + this.Password + " "
                + this.Rol + " "
               ;
        }
        public override bool Equals(object obj)
        {
            Usuario otro = obj as Usuario;
            if (otro == null)
                return false;
            return otro.CI == this.CI;
        }
        #endregion
        #region Validaciones
        public bool ValidarUsuario()
        {
            //La política de seguridad de las contraseñas en general establece que deben contar con al menos 6 caracteres, que
            //deben al menos incluir una mayúscula, una minúscula y un dígito. La cédula es un numérico con 7 u 8 dígitos.

            //Regex rgP = new Regex("^ (?=w *d)(?=w *[A - Z])(?=w *[a - z])S{ 6,16}$");


            return true;//this.CI = [0-9]{7} || this.Password(rgP) ;//this.Password.Length > 6 && this.Password.u true;
        }
        #endregion

    }
}
