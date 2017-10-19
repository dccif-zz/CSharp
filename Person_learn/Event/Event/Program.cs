using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event
{
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();

        public event NumManipulationHandler ChangeNum;

        protected virtual void OnNumChanged()
        {
            if(ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event not fire");
                Console.ReadKey();
            }
        }

        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }

    public class subscribEvent
    {
        public void printf()
        {
            Console.WriteLine("event fire");
            Console.ReadKey();
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            EventTest e = new EventTest();
            subscribEvent v = new subscribEvent();
            e.ChangeNum += new EventTest.NumManipulationHandler(v.printf);
            e.SetValue(7);
            e.SetValue(11);
        }
    }
}
