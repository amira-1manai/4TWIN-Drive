using Examen.Data;
using System;

namespace Examen.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            ExamContext ctx = new ExamContext();//création de la base
            System.Console.WriteLine("fin");
            System.Console.ReadKey();
        }
    }
}
