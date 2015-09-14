using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01EntityFrameworkMapping;
using System.Web.Script.Serialization;
using System.IO;

namespace _02ExportCharsAndPlayers
{
    class ExportToJSON
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var charactersWithPlayers = context.Characters.OrderBy(c => c.Name).Select(c => new
            {
                CharacterName = c.Name,
                PlayersName = c.UsersGames.Select(ug => ug.User.Username)
            }).ToList();

            var jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(charactersWithPlayers);
            File.WriteAllText("characters.json", json);
            Console.WriteLine("File characters.json exported");
        }
    }
}
