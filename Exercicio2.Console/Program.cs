using System;
using System.Collections.Generic;
using System.Linq;


namespace Exercicio2
{
    /// <summary>
    /// Exercício 2
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Retornará os numeros do Primeiro Array que não estejam contidos no Segundo Array
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            List<int> primeiroArray = new List<int>();
            List<int> segundoArray = new List<int>();
            primeiroArray.AddRange(new int[] { 1, 3, 7, 29, 42, 98, 234, 93 });
            segundoArray.AddRange(new int[] { 4, 6, 93, 7, 55, 32, 3 });

            var diferentes = from x in primeiroArray
                    where !segundoArray.Contains(x)
                    select x;

            foreach (int i in diferentes)
            {
                Console.WriteLine("O seguinte numero não faz parte do segundo array: " + i);
            }
            Console.ReadKey();

        }
    }
}
