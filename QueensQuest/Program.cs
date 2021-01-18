using System;

namespace QueensQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            QueensSolver solver = new QueensSolver(8);

            bool[][,] result = solver.Solve();

            foreach (var sol in result)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write((sol[i,j] ? "Q" : " "));
                        if (j < 7) Console.Write("|");
                    }
                    Console.WriteLine("]");
                }
                Console.WriteLine();
            }
        }
    }
}
