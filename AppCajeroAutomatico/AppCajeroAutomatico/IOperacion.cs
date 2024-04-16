using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCajeroAutomatico
{
    internal class Operacion
    {
        private DateTime Fecha;
        private string DireccionCajero;
        private string TipoOperacion;
        private decimal Monto;


        public Operacion() { }
        public Operacion(string dir, string tipo, decimal monto)
        {
            Fecha = DateTime.Now;
            DireccionCajero = dir;
            TipoOperacion = tipo;
            Monto = monto;
        }
        public DateTime fecha { get { return Fecha; } set { Fecha = value; } }
        public string cajero { get { return DireccionCajero; } set { DireccionCajero = value; } }
        public string tipoOperacion { get { return TipoOperacion; } set { TipoOperacion = value; } }
        public decimal monto { get { return Monto; } set { Monto = value; } }

        public void toString()
        {
            
            Console.Write($"\nFecha: {fecha.ToString("dd/MM/yyyy HH:mm")}");
            Console.Write($"    {DireccionCajero}");
            Console.Write($"    Tipo de operacion: {TipoOperacion} / Monto: ${Monto}\n");

        }
    }
}
