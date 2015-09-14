using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01EntityFrameworkMapping
{
    class DiabloMain
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var charNames = context.Characters.Select(c => c.Name);

            foreach (var charName in charNames)
            {
                Console.WriteLine(charName);
            }
        }
    }
}
