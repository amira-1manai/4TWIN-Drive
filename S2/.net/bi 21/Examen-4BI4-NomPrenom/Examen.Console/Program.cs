using Examen.Data;
using System;

namespace Examen.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            ExamenContext ctx = new ExamenContext();
            System.Console.WriteLine("Fin");
            System.Console.ReadKey();
        }
    }
}
