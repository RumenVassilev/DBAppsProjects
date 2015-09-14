using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03ExportFinishedGamesAsXML
{
    class ExportToXML
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var games = context.Games
                .Where(g => g.IsFinished == true)
                .Select(g => new
            {
            GameName = g.Name,
            Duration = g.Duration,             
                Username = g.UsersGames.Select(ug => new
                {
                    uu = ug.User.Username,                       
                }),
                IpAddress = g.UsersGames.Select(ug => new
                {
                    ip = ug.User.Username
                })
            }).ToList();

            var resultXml = new XElement("games");

            foreach (var game in games)
            {
                XElement resultGames =
                    new XElement("game",
                        new XAttribute("name", game.GameName),
                        new XElement("users",
                            new XElement("user",
                                new XAttribute("username", game.Username), new XAttribute("ip-address", game.IpAddress)
                                )));

                if (game.Duration != null)
                {
                    resultGames.Add(new XAttribute("duration", game.Duration));
                }
                resultXml.Add(resultGames);

            }
            Console.WriteLine(resultXml);

            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("finished-games.xml");

            Console.WriteLine("Matches exported to international-matches.xml");
        }
    }
}
