using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils
{
    class CharacterView
    {
        public void PrintLine(string uLine)
        {
            Console.WriteLine(uLine);
        }

        public void PrintSet<T>(HashSet<T> uSet)
        {
            foreach (T item in uSet)
                Console.Write($"{item}, ");
            Console.WriteLine();
        }

        public string GetLine()
        {
            return Console.ReadLine();
        }
    }
}
