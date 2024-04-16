using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCajeroAutomatico
{
    internal class CuentaBancaria
    {
        //..........................................................................
        private decimal Saldo;
        private static int ultimoNrocuenta = 0;
        private int nroCuenta;
        private DateTime FechaApertura;
        private Usuario Usuarios;
        private List<Operacion> LOperacion;
        private int DineroPrestamo;
        private bool PrestamoEnCurso;

        //..........................................................................
        
        public CuentaBancaria(Usuario usuario)
        {
            Saldo = 0;
            ultimoNrocuenta+=1;
            this.nroCuenta = ultimoNrocuenta;
            FechaApertura = DateTime.Now;
            Usuarios = usuario;
            LOperacion = new List<Operacion>();
            DineroPrestamo = 80000;
            PrestamoEnCurso = false;
        }

        //..........................................................................
        public decimal saldo {get { return Saldo; } set { Saldo = value; } }
        public int NroCuenta { get { return nroCuenta; } }
        public Usuario Usuario { get => Usuarios; }
        public DateTime fechaApertura { get {return FechaApertura;} }
        public int dineroPrestamo { get { return DineroPrestamo; } set { DineroPrestamo = value; } }
        public bool prestamoEnCurso { get { return PrestamoEnCurso; } set { PrestamoEnCurso = value; } }

    //..........................................................................

    public void deposito() // decimal para manejo de dinero
        {

        }
        public void extraccion() // decimal para manejo de dinero
        {

        }
        public void preacordado()
        {

        }

        public void toString(Usuario u)
        {
            Console.WriteLine($"Datos de la cuenta:\nTitular:{u.nombre}\nDNI:{u.id}\nTipo de usuario:{u.tipoUsuario}\nSaldo actual:${saldo}");

        }
        //..........................................................................

        public void mostrarOperaciones()//resumen de cuenta
        {
            Console.Clear();
            Console.WriteLine("Operaciones realizadas:");
            foreach (Operacion o in LOperacion)
            {
                o.toString();
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        } 

        //..........................................................................
        public void agregarOperaciones(Operacion o)
        {
            LOperacion.Add(o);
        }
    }
}
