using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;


namespace _04ImportUsersAndGamesFromXML
{
    class ImportFromXML
    {
        static void Main()
        {
            var inputXml = XDocument.Load("../../users-and-games.xml");
            var xUsers = inputXml.XPathSelectElements("/users/user");
            var xGames = inputXml.XPathSelectElements("/users/user/games/game");
            var context = new DiabloEntities();
            int usersCount = 0;
            foreach (var xUser in xUsers)
            {
                Console.WriteLine("Processing user #{0} ...", ++usersCount);
                // I don't have any time left to try to fix the task
                User user = CreateUser(context, xUser);
                CreateGame(context, xGames, user);
                Console.WriteLine();
            }
        }

        private static void CreateGame(DiabloEntities context, IEnumerable<XElement> xGames, User user)
        {
            foreach (var xGame in xGames)
            {
                // Find the team by team name and country name (if exists)
                var gameName = xGame.Element("game-name").Value;
                var charName = xGame.Element("character").Attribute("name").Value;
                var cash = xGame.Element("character").Attribute("cash").Value;
                var level = xGame.Element("character").Attribute("level").Value;
                var joinedOn = xGame.Element("joined-on").Value;

                decimal parsedCash = decimal.Parse(cash);
                int parsedLvl = int.Parse(level);
                DateTime newJoinedOnDate = DateTime.ParseExact(joinedOn, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                var game = context.Games.FirstOrDefault(g => g.Name == gameName);

                // Create the team if it does not exists
                if (game != null)
                {
                    Console.WriteLine("Existing game: {0}",
                        game.Name);
                }
                else
                {
                    // Create a new team in the DB
                    game = new Game()
                    {
                        Name = gameName
                    };
                    var character = new Character()
                    {
                        Name = charName
                        
                    };
                    var usersGame = new UsersGame()
                    {
                        Cash = parsedCash,
                        Level = parsedLvl,
                        JoinedOn = newJoinedOnDate
                    };

                    context.Games.Add(game);
                    context.Characters.Add(character);
                    context.UsersGames.Add(usersGame);
                    context.SaveChanges();
                    Console.WriteLine("Created game: {0}",
                        game.Name);
                }
                
            }
        }

        private static User CreateUser(DiabloEntities context, XElement xUsers)
        {
            User user = null;
            var xAttributeFirstName = xUsers.Attribute("first-name");
            var xAttributeLastName = xUsers.Attribute("last-name");
            var xAttributeUsername = xUsers.Attribute("username");
            var xAttributeIsDeleted = xUsers.Attribute("is-deleted");
            var xAttributeIpAddress = xUsers.Attribute("ip-address");
            var xAttributeRegDate = xUsers.Attribute("registration-date");

            if (xAttributeFirstName != null)
            {
                string firstName = xAttributeFirstName.Value;
                string LastName = xAttributeLastName.Value;
                string username = xAttributeUsername.Value;
                var isDeleted = xAttributeIsDeleted.Value;
                string ipAddress = xAttributeIpAddress.Value;
                string regDate = xAttributeRegDate.Value;
                
                user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    Console.WriteLine("User {0} already exists", username);
                   // Console.WriteLine("{0} {1} {2} {3} {4}", LastName, firstName, isDeleted, ipAddress, regDate);
                }
                else
                {
                    // Create a new league in the DB
                    DateTime newRegDate = DateTime.ParseExact(regDate, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    user = new User() 
                    { 
                        FirstName = firstName,
                        LastName = LastName,
                        Username = username,
                        IpAddress = ipAddress,
                        RegistrationDate = newRegDate
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    Console.WriteLine("Added user: {0}", firstName);
                }
            }
            return user;
        }

    }
}
