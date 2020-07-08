using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DndUtils.CharacterGenerator
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

        public void PrintOptions(List<Type> uList)
        {
            foreach(Type item in uList)
                Console.Write($"{AddSpacesToSentence(item.Name)}, ");
            Console.WriteLine();
        }

        string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public string GetLine()
        {
            return Console.ReadLine();
        }
    }
}
