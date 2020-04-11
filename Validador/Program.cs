using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el núemero de la cédula");
            string cedula = Console.ReadLine();
            if (!CedulaValida(cedula))
            {
                Console.WriteLine("Cédula Inválida");

            }
            else
            {
                Console.WriteLine("Cédula válida");
            }
            Console.ReadKey();
        }

        #region MetodoValidadorCedulaEcuatoriana
        public static bool CedulaValida(string cedula)
        {
            char[] vectorCedula = cedula.ToCharArray();
            if (vectorCedula.Length != 10)
            {
                return false;
            }
            int suma = 0;
            for (int i = 0; i < vectorCedula.Length - 1; i++)
            {
                if ((i % 2) == 0)
                {
                    try
                    {
                        suma += Producto(2, Int32.Parse(vectorCedula[i].ToString()));
                    }
                    catch { return false; }
                }
                else
                {
                    try
                    {
                        suma += Producto(1, Int32.Parse(vectorCedula[i].ToString()));
                    }
                    catch { return false; }
                }
            }
            int modulo = suma % 10;
            try
            {
                if (modulo == 0 && (Int32.Parse(vectorCedula[9].ToString())) == 0)
                {
                    return true;
                }
                int sup = (10 - modulo) + suma;
                if ((Int32.Parse(vectorCedula[9].ToString())) == (sup - suma))
                {
                    return true;
                }
            }
            catch { return false; }
            return false;

        }

        private static int Producto(int multiplicador, int dijitoCedula)
        {
            int producto = multiplicador * dijitoCedula;
            if (producto >= 10)
            {
                producto = producto - 9;

            }
            return producto;
        } 
        #endregion
    }
}
