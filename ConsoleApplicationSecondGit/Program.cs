using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start");
            // Testing Web Services
            ServiceReference.CalcSEIClient calc = new ServiceReference.CalcSEIClient();
            //int expected = 7;
            int actual = calc.add(3, 4);
            Console.WriteLine("actual = " + actual);
            //
            Console.WriteLine("5+7 = " + calc.add(5, 7));
            Console.WriteLine("Answer = " + calc.hello("Ivan"));
            Console.WriteLine("Done");
        }
    }
}
