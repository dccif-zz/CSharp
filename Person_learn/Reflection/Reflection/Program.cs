using System;
using System.Reflection;

namespace BugFixApplication
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property, AllowMultiple = true)]
    public class DebugInfo : System.Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DebugInfo(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        public int BugNo { get { return bugNo; } }
        public string Developer { get { return developer; } }
        public string LastReview { get { return lastReview; } }
        public string Message { get { return message; } set { message = value; } }
    }

    [DebugInfo(45, "Zara Ali", "12/8/2012",
        Message = "Return type mismatch")]
    [DebugInfo(49, "Nuha Ali", "10/10/2012",
        Message = "Unused variable")]
    class Rectangle
    {
        protected double length;
        protected double width;

        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        [DebugInfo(55, "Zara Ali", "19/10/2012",
            Message = "Return type mismatch")]
        public double GetArea()
        {
            return length * width;
        }

        [DebugInfo(56, "Zara Ali", "19/10/2012")]
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }

    class Exxecute
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(4.5,7.5);
            r.Display();
            Type type = typeof(Rectangle);
            foreach (object attributes in type.GetCustomAttributes(false))
            {
                DebugInfo dbi = (DebugInfo) attributes;
                if (null != dbi)
                {
                    Console.WriteLine("Bug no: {0}",dbi.BugNo);
                    Console.WriteLine("Developer: {0}",dbi.Developer);
                    Console.WriteLine("Last Reviewed: {0}",dbi.LastReview);
                    Console.WriteLine("Remarks: {0}",dbi.Message);
                }
            }

            foreach (MethodInfo m in type.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(true))
                {
                    DebugInfo dbi = (DebugInfo) a;
                    if (null != dbi)
                    {
                        Console.WriteLine("Bug no : {0},for Method: {1}",dbi.BugNo,m.Name);
                        Console.WriteLine("Developer:{0}",dbi.Developer);
                        Console.WriteLine("Last Reviewed:{0}",dbi.LastReview);
                        Console.WriteLine("Remarks:{0}",dbi.Message);
                    }
                }
            }
            Console.ReadLine();
        }
    }

}