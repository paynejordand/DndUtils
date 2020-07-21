using DndUtils.CharacterGenerator;
using DndUtils.CharacterGenerator.Race;
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

            cc = new CharacterController();
            cc.RandomCharacter(5, "Random");
        }
    }
}
