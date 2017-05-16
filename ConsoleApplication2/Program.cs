using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            //GetCombination(new List<int> { 5, 4, 8, 1, 3, 4, 5 }, 13);
            var todasCombinacoes = GeraCombinacaoes(new List<int> { 8, 2, 1, 7, 2, 5, 6, 8, 9, 10, 23, 12, 31, 41 }, 1);

            var valorProcurado = 88;

            foreach (var item in todasCombinacoes)
            {
                if (item.Sum() == valorProcurado)
                {
                    Console.WriteLine("Achei a formula perfeita");
                    Console.WriteLine(item);
                    Console.Read();
                }
            }

            Console.Read();
        }

        public static List<List<T>> GeraCombinacaoes<T>(List<T> inputList, int minimumItems = 1)
        {
            int semCombinacaoVazia = (int)Math.Pow(2, inputList.Count) - 1;
            List<List<T>> listOfLists = new List<List<T>>(semCombinacaoVazia + 1);

            if (minimumItems == 0)
                listOfLists.Add(new List<T>());

            for (int i = 1; i <= semCombinacaoVazia; i++)
            {
                List<T> thisCombination = new List<T>(inputList.Count);
                for (int j = 0; j < inputList.Count; j++)
                {
                    if ((i >> j & 1) == 1) //A Bruxaria do bitwise
                        thisCombination.Add(inputList[j]);
                }

                if (thisCombination.Count >= minimumItems)
                    listOfLists.Add(thisCombination);
            }

            return listOfLists;
        }
    }
}
