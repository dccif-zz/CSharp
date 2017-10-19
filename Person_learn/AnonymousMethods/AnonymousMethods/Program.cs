using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

delegate void NumberChanger(int n);
namespace AnonymousMethods
{
    class TestDelegate
    {
        private static int num = 10;

        public static void AddNum(int p)
        {
            num += p;
            Console.WriteLine("Named Method:{0}",num);
        }

        public static void MultiNum(int q)
        {
            num *= q;
            Console.WriteLine("Named Method:{0}",num);
        }

        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            NumberChanger nc = delegate(int x)
            {
                Console.WriteLine("Anonymous Method:{0}", x);
            };
            nc(40);

            nc = new NumberChanger(AddNum);
            nc(5);
            nc = new NumberChanger(MultiNum);
            nc(2);
            Console.ReadKey();
        }
    }
}
