using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppCajeroAutomatico
{
    internal class Cajero
    {
        //..........................................................................
        private string Direccion;
        private int NroCajero;
        public List<CuentaBancaria> Cuentas;
        //..........................................................................

        public Cajero(string direccion, int nroCajero)
        {
            this.Direccion = direccion;
            this.NroCajero = nroCajero;
            Cuentas = new List<CuentaBancaria>();
        }
        //..........................................................................

        public string direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        public int nroCajero
        {
            get { return NroCajero; }
            set { NroCajero = value; }
        }
        //..........................................................................
        
        public void Menu() {
            bool continuar = true;
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Elija entre las siguientes opciones:\n1-Crear cuenta.\n2-Ingresar a una cuenta.\n3-Salir.");
                ConsoleKeyInfo opc = Console.ReadKey(true);
                switch (opc.Key)
                {
                    case ConsoleKey.D1: case ConsoleKey.NumPad1: crearCuenta();
                        break;
                    case ConsoleKey.D2: case ConsoleKey.NumPad2: ingresarACuenta();
                        continuar = false;
                        break;
                        case ConsoleKey.D3: case ConsoleKey.NumPad3:
                        Console.WriteLine("Hasta luego.");
                        continuar = false;
                        break;
                    default: Console.WriteLine("Opcion invalida, vuelva a intentar.") ;break;
                }
            } while (continuar);
        }
        //..................................................................................
        
        public void ingresarACuenta()
        {
            Console.WriteLine("--------------------------------------------");
            Console.Write("Ingrese su numero de cuenta: ");
            int nroCuenta = int.Parse(Console.ReadLine());
            if (Cuentas.Count != 0) {

                foreach (CuentaBancaria o in Cuentas)
                {
                    if (o.NroCuenta == nroCuenta)
                    {
                        bool continuar = true;
                        do
                        {
                            Console.WriteLine("\nElija entre las siguientes opciones:\n1-Depositar.\n2-Extraer.\n3-Prestamo.\n4-Mostrar Operaciones.");
                            ConsoleKeyInfo opc = Console.ReadKey(true);
                            switch (opc.Key)
                            {
                                case ConsoleKey.D1: case ConsoleKey.NumPad1: deposito(o); break;
                                case ConsoleKey.D2: case ConsoleKey.NumPad2: extraccion(o); break;
                                case ConsoleKey.D3: case ConsoleKey.NumPad3: sacarPrestamo(o); break;
                                case ConsoleKey.D4: case ConsoleKey.NumPad4: o.mostrarOperaciones(); break;
                                default: Console.WriteLine("Opcion incorrecta."); break;
                            }
                        } while (continuar);
                    }
                }
            }else { Console.WriteLine("Error, ese numero de cuenta no existe.");
                    Console.WriteLine("Lo redirigimos al menu de crear cuentas.");
                    crearCuenta();
                    
                }
        }

        //..................................................................................

        public void crearCuenta()
        {
            
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Bienvenido al menu de creacion de cuentas:");
            Console.WriteLine("Ingrese los siguientes datos porfavor:");
            Console.Write("-Apellido y nombre: "); String nombreCompleto = Console.ReadLine();
            Console.Write("-DNI(Solo numeros): "); int dni = int.Parse(Console.ReadLine());
            Console.Write("-Direccion: ");string direccion = Console.ReadLine();
            
            Console.Write("\n-Cual es su situacion actual:\n1-Activo(trabajando).\n2-Jubilado.\n"); 
            ConsoleKeyInfo opciones = Console.ReadKey(true);
            String tipoUsuario;
            while ((opciones.Key != ConsoleKey.NumPad1 && opciones.Key != ConsoleKey.D1)&&(opciones.Key != ConsoleKey.NumPad2 && opciones.Key != ConsoleKey.D2)){
                Console.Clear();
                Console.WriteLine("Opcion incorrecta,intente nuevamente");
                Console.Write("\n-Cual es su situacion actual:\n1-Activo(trabajando).\n2-Jubilado.\n");
                opciones = Console.ReadKey(true);
            }
            if (opciones.Key == ConsoleKey.NumPad1 || opciones.Key == ConsoleKey.D1) 
            {
                tipoUsuario = "Activo";
            }
            else
            {
                tipoUsuario = "Jubilado";
            }

            Usuario user = new Usuario(dni,nombreCompleto,direccion,tipoUsuario);
            CuentaBancaria cuenta = new CuentaBancaria(user);
            Cuentas.Add(cuenta);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Cuenta creada con exito.Su numero de cuenta es: \"{cuenta.NroCuenta}\" , le servira para ingresar al menu de opciones.\nPresione cualquier tecla para continuar. ");
            Console.ResetColor();
            Console.ReadKey();
            
            Console.Clear();

        }

        //..................................................................................

        public void deposito(CuentaBancaria cuenta) // deimal para manejo de dinero
        {
            Console.Clear();
            Console.Write("\nIngrese cuanto dinero quiere depositar: ");
            decimal plata = decimal.Parse(Console.ReadLine());
            if (plata > 0)
            {
                cuenta.saldo += plata;
                Console.Clear();
                Console.WriteLine($"Dinero depositado con exito.\nSaldo actual: ${cuenta.saldo}");
                Operacion operacion = new Operacion(toString(), "Deposito.", plata);
                cuenta.agregarOperaciones(operacion);
            }
            else
            {
                Console.WriteLine("Error, no se puede depositar un monto negativo.");
                cuenta.saldo += 0;
            }
            
        }
        public void extraccion(CuentaBancaria cuenta) // deimal para manejo de dinero
        {
            Console.Clear();
            int maximoRetirar;
            Console.Write($"\nIngrese cuanto dinero desea extraer:\nMonto maximo por extaccion: ${(cuenta.Usuario.tipoUsuario == "Activo"? 20000 :10000)}.\n");
            maximoRetirar = (cuenta.Usuario.tipoUsuario == "Activo" ? 20000 : 10000);
            decimal extraer = decimal.Parse(Console.ReadLine());
            if (extraer > 0 && extraer <= cuenta.saldo && extraer <= maximoRetirar)   
            {
                Console.Clear();
                Console.WriteLine($"Se retiro ${extraer} con exito.");
                cuenta.saldo -= extraer;
                Console.WriteLine($"Saldo restante ${cuenta.saldo}");
                Operacion operacion = new Operacion(toString(), "Extraccion.",extraer);
                cuenta.agregarOperaciones(operacion);
            }
            else if(extraer > maximoRetirar){
                
                Console.WriteLine($"Usted pertenece al tipo de usuario: {cuenta.Usuario.tipoUsuario},solo puede retirar hasta ${maximoRetirar}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nError, saldo insuficiente.");
            }


        }
        public void sacarPrestamo(CuentaBancaria cuenta)
        {
            
            Console.Clear();
            Console.WriteLine("Bienvenido al menu de prestamo:\n");
            Console.WriteLine("El limite de cada prestamo es de: $80000.");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("¡ACLARACION! Una vez acreditado un prestamo, debera pagar el monto total del mismo para volver a solicitar un prestamo.");
            Console.ResetColor();
            
            
            Console.WriteLine("Elija entre las siguientes opciones:\n1-Sacar prestamo.\n2-Pagar prestamo.\nSi desea volver al menu principal,presione cualquier otra tecla que no sea el 1(uno) o 2(dos).");
            ConsoleKeyInfo opciones = Console.ReadKey(true);
            switch (opciones.Key){
                case ConsoleKey.D1: case ConsoleKey.NumPad1:
                    Console.Clear();
                    if (cuenta.saldo < 20000)
                    {
                        Console.WriteLine("No puede pedir un prestamo debido a que su saldo actual es menor a: $20000");
                        
                    }
                    else if (cuenta.prestamoEnCurso == true)
                    {
                        Console.WriteLine($"No puede pedir un prestamo debido que ya tiene un prestamo en curso.\nDinero restante para saldar el prestamo: ${80000 -cuenta.dineroPrestamo }");
                        
                    }else {
                        Console.Write("Ingrese cuanto dinero desea pedir de prestamo: $");
                        int dinero = int.Parse(Console.ReadLine());
                        while (dinero <= 0 || dinero > 80000)
                        {
                            Console.Clear();
                            Console.WriteLine($"Error,monto invalido,ingrese un nuevo monto positivo y menor o igual a $80000");
                            dinero = int.Parse(Console.ReadLine());
                        }
                        cuenta.saldo+= dinero;
                        cuenta.prestamoEnCurso= true;
                        cuenta.dineroPrestamo=cuenta.dineroPrestamo - dinero;
                        Console.Clear();                             
                        Console.WriteLine($"Dinero del prestamo acreditado con exito, su saldo ahora es de: {cuenta.saldo}\nPara sacar otro prestamo debe abonar ${80000-cuenta.dineroPrestamo}");
        
                        
                        
                            
                          
                    }
                    break;
                    case ConsoleKey.D2: case ConsoleKey.NumPad2:
                    Console.Clear();
                    if (cuenta.prestamoEnCurso == true)
                    {
                        
                        Console.Write($"Ingrese cuanto dinero quiere abonar para cubrir el prestamo:");
                        int pagoPrestamo = int.Parse(Console.ReadLine());
                        while (pagoPrestamo <=0 || pagoPrestamo >cuenta.saldo)
                        {
                            Console.Clear();
                            Console.WriteLine($"Error,saldo insuficiente o monto invalido,ingrese un nuevo monto.\nSu saldo disponible es: ${cuenta.saldo}");
                            pagoPrestamo = int.Parse(Console.ReadLine()) ;
                        }
                        if (cuenta.dineroPrestamo +  pagoPrestamo >= 80000) {
                            Console.WriteLine("Prestamo Saldado.");
                            cuenta.saldo-= pagoPrestamo;
                            cuenta.saldo += ((cuenta.dineroPrestamo + pagoPrestamo) - 80000);
                            cuenta.prestamoEnCurso= false;
                            cuenta.dineroPrestamo = 80000;
                        }
                        else
                        {
                            cuenta.dineroPrestamo += pagoPrestamo;
                            cuenta.saldo -= pagoPrestamo;
                            Console.WriteLine($"Dinero pagado: ${pagoPrestamo}\nMonto restante: ${80000-cuenta.dineroPrestamo}");
                        }
                    }
                    break;
                default: Console.WriteLine("Volviendo al menu de inicio.");
                    Console.Clear();
                    break;
            }
        }


            
            
        
        public string toString() 
        {
            return ($"Cajero Nro: {NroCajero},Direccion: {Direccion}");
        }

        //..........................................................................

    }
}
