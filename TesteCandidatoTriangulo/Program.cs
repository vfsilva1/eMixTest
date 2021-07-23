using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangulo triangulo = new Triangulo();
            Console.WriteLine("Neste triangulo o total máximo é = " + triangulo.ResultadoTriangulo("[[6],[3,5],[9,1,3],[4,6,6,4]]"));
            Console.ReadKey();
        }
    }
}
