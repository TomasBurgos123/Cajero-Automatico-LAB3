using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Desarrolle una aplicación en C#, para un cajero automático. La aplicación permitirá 
 * crear cuentas para jubilados y personas en actividad. Los usuarios del cajero podrán 
 * depositar en su cuenta y realizar extracciones de la misma. Si el usuario es una persona 
 * en actividad laboral podrá retirar hasta, 20000 pesos en concepto de adelanto de sueldo. 
 * Si el usuario es una persona jubilada podrá retirar en concepto de adelanto solo 10000. 
 * Cada operación de ingreso o extracción deberá registrar la fecha, el cajero y el monto de 
 * la operación. Los cajeros se identifican por su dirección y número de cajeros. Si durante dos 
 * meses de operación un usuario tubo un saldo positivo superior a 20000 pesos, se le ofrecerá un 
 * crédito pre acordado de, 80000 pesos. Con lo cual, su nuevo límite de extracción en negativo será de, 80000 pesos.*/

namespace AppCajeroAutomatico
{
    internal class program
    {
        static void Main(string[] args)
        {
            Cajero cajero = new Cajero("Av. 25 de Mayo 1460", 16);
            cajero.Menu();
            
            Console.ReadLine();

        }


    }
}
