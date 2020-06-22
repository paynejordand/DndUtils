using DndUtils.CharacterGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DndUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterController cc = new CharacterController();
            cc.RollCharacter();
            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }
    }
}
