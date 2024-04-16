using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCajeroAutomatico
{
        

    internal class Usuario
    {
        //..........................................................................
        private int Id;
        private string Nombre;
        private string Direccion;
        private string TipoUsuario;

        //..........................................................................

        public Usuario()
        { 
        }

        public Usuario(int id, string nombre, string direccion, string tipoUsuario)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            TipoUsuario = tipoUsuario;
        }
        //..........................................................................
        
        public int id { get { return Id; } set => Id = value; }
        public string nombre { get { return nombre; } set => Nombre = value; }
        public string direccion { get => Direccion; set => Direccion = value; }
        public string tipoUsuario { get { return TipoUsuario; } set => TipoUsuario = value; }
        

        //..........................................................................









        //..........................................................................

    }

}
