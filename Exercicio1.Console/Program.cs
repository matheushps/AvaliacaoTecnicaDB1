using System.Collections.Generic;
using System.Linq;
using System;

namespace Exercicio1
{
    /// <summary>
    /// Exercicio 1
    /// </summary>
   public class Program
    {
        /// <summary>
        /// Retornará apenas numeros impares
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> numeros = new List<int> { 1, 2, 3, 5, 8, 13, 21, 38, 55, 89, 144 };
            List<int> numerosImpares = numeros.Where(x => x % 2 == 1).ToList();

            foreach(int x in numerosImpares)
            {
                Console.WriteLine("Número Primo: " + x);
            }
            Console.ReadKey();
        }

    }
}
