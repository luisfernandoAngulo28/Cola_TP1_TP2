using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            clsCola P = new clsCola();
            for (int i = 2; i < 7; i++)
            {
                P.Add(i);
            }

            clsCola Q = new clsCola();
            for (int i = 7; i < 12; i++)
            {
                Q.Add(i);
            }
            Console.WriteLine("cola P="+P.Imprimir());
            Console.WriteLine("cola Q=" + Q.Imprimir());
            clsCola C = new clsCola();
            Console.WriteLine(C.mezcla(P, Q).Imprimir());
            Console.ReadKey();
        }
    }
}
