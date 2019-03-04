using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    class Program
    {
        static void Main(string[] args)
        {
            // What's next? 
            // Different divisions
            // --> with teams or per cyclist?
            // Unique racegrounds with statistics
            var database = new Database();
            var raceground = new Raceground();
            int raceDay = 0;
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("n - New game");
                Console.WriteLine("l - Load game");
                Console.WriteLine("s - Save game");
                Console.WriteLine("c - New cyclist");
                Console.WriteLine("r - New raceground");
                Console.WriteLine("w - Show by winners");
                Console.WriteLine("q - Quit game");
                Console.WriteLine("");
                Console.WriteLine("enter - Next");
                input = Console.ReadLine();

                switch (input)
                {

                    case "n":
                        database = new Database();
                        break;
                    case "c":
                        database.AddCyclist();
                        break;
                    case "r":
                        raceground = new Raceground();
                        break;
                    case "w":
                        database.ShowWinners();
                        break;
                    case "q":
                        break;
                    default:
                        var raceDatabase = new RaceDatabase(database, raceground);
                        var race = new Race(raceDatabase);

                        race.Go();
                        database.UpgradeCyclists(race.GetFinalRanking, race.GetWinner, race.GetSprintBool);
                        database.UpgradeRandomCyclists();
                        database.DowngradeCyclists(race.GetLoser);
                        database.RankWinners();
                        raceDay++;
                        break;
                }
            }while(input!="q");
            /*var database = new Database();
            
            do
            {
                Console.Clear();
                var raceground = new Raceground();
                var raceDatabase = new RaceDatabase(database, raceground);
                var race = new Race(raceDatabase);

                race.Go();
                database.UpgradeCyclists(race.GetFinalRanking, race.GetWinner, race.GetSprintBool);
                database.UpgradeRandomCyclists();
                database.DowngradeCyclists(race.GetLoser);

                Console.Clear();
                Console.WriteLine("New cyclist? (y)");
                if (Console.ReadLine()=="y")
                    database.AddCyclist();
                                
                Console.Clear();
                Console.WriteLine("To quit, press q");
            } while (Console.ReadLine() != "q");
            */
        }
    }
}
