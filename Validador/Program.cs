﻿using System;
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
            int suma = 0;
            for (int i = 0; i < vectorCedula.Length - 1; i++)
            {
                if ((i % 2) == 0)
                {
                    suma += Producto(2, Int32.Parse(vectorCedula[i].ToString()));
                }
                else
                {
                    suma += Producto(1, Int32.Parse(vectorCedula[i].ToString()));
                }
            }
            int modulo = suma % 10;
            int sup = (10 - modulo) + suma;
            if ((Int32.Parse(vectorCedula[9].ToString())) == (sup - suma))
            {
                return true;
            }
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