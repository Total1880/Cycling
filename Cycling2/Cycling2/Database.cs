using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    public class Database
    {
        private readonly int _numberOfCyclist;
        private List<Cyclist> _allCyclist = new List<Cyclist>();
        private GenerateName _generateName = new GenerateName();
        private Random random = new Random();

        public Database()
        {
            string input;

            Console.WriteLine("How many cyclist do you want to have (4 or more)");
            input = Console.ReadLine();

            if (input == "")
            {
                _numberOfCyclist = 10;
            }
            else
            {
                if (Convert.ToInt32(input) < 4)
                {
                    input = "4";
                }
                _numberOfCyclist = Convert.ToInt32(input);
            }

            Console.Clear();

            for (int i = 0; i < _numberOfCyclist; i++)
            {
                var cyclist = new Cyclist(_allCyclist.Count+1,random);

                _allCyclist.Add(cyclist);
                Console.Clear();
            }
        }
        public void AddCyclist()
        {
            var cyclist = new Cyclist(_allCyclist.Count + 1,random);

            _allCyclist.Add(cyclist);
            Console.Clear();
        }

        public List<Cyclist> getDatabase
        {
            get
            {
                var bufferList = new List<Cyclist>();

                foreach (var cyclist in _allCyclist)
                    bufferList.Add(cyclist);
                return bufferList;
            }
        }

        public void UpgradeCyclists(List<Cyclist> ranking,Cyclist winner, bool sprint)
        {
            var max = Math.Round(Convert.ToDouble(_allCyclist.Count / 3));
            int maxPotential;
            var upgradedCyclist = random.Next(0, 4);

            ranking[0].Points += 3;
            ranking[1].Points += 2;
            ranking[2].Points += 1;

            if (upgradedCyclist < 3)
            {
                foreach (var cyclist in _allCyclist)
                {
                    if (ranking[upgradedCyclist].GetId == cyclist.GetId)
                    {
                        maxPotential = cyclist.Strength + cyclist.GetSprint;
                        if (sprint)
                        {
                            if (cyclist.GetSprint <= max && cyclist.GetPotential > maxPotential)
                                cyclist.GetSprint += 1;
                        }
                        else
                        {
                            if (cyclist.Strength <= max && cyclist.GetPotential > maxPotential)
                                cyclist.Strength += 1;
                        }
                    }
                }
            }
            else
            {
                foreach (var cyclist in _allCyclist)
                {
                    if (winner.GetId == cyclist.GetId)
                    {
                        maxPotential = cyclist.Strength + cyclist.GetSprint;
                        if (sprint)
                        {
                            if (cyclist.GetSprint <= max && cyclist.GetPotential > maxPotential)
                                cyclist.GetSprint += 1;
                        }
                        else
                        {
                            if (cyclist.Strength <= max && cyclist.GetPotential > maxPotential)
                                cyclist.Strength += 1;
                        }
                    }
                }
            }
        }

        public void UpgradeRandomCyclists()
        {
            var max = Math.Round(Convert.ToDouble(_allCyclist.Count / 3));
            var cyclistPlus = new Cyclist();
            int maxPotential;

            cyclistPlus = _allCyclist[random.Next(0, _allCyclist.Count)];

            foreach (var cyclist in _allCyclist)
            {
                if (cyclistPlus.GetId == cyclist.GetId)
                {
                    maxPotential = cyclist.Strength + cyclist.GetSprint;
                    int sprint = random.Next(0,2);
                    if (sprint == 0)
                    {
                        if (cyclist.GetSprint <= max && cyclist.GetPotential > maxPotential)
                            cyclist.GetSprint += 1;
                    }
                    else
                    {
                        if (cyclist.Strength <= max && cyclist.GetPotential > maxPotential)
                            cyclist.Strength += 1;
                    }
                }
            }
        }

        public void DowngradeCyclists(Cyclist cyclistMin)
        {
            foreach (var cyclist in _allCyclist)
            {
                if (cyclistMin.GetId == cyclist.GetId)
                {
                    int sprint = random.Next(0, 2);
                    if (sprint == 0)
                    {
                        if (cyclist.GetSprint >0)
                            cyclist.GetSprint -= 1;
                    }
                    else
                    {
                        if (cyclist.Strength >0)
                            cyclist.Strength -= 1;
                    }
                }
            }
        }

        public void ShowWinners()
        {
            Console.Clear();
            foreach (var cyclist in _allCyclist)
            {
                Console.WriteLine("{0} - wins: {1}", cyclist.Name, cyclist.Points);
            }
            Console.ReadLine();
        }

        public void RankWinners()
        {

            var ranking = new List<Cyclist>();
            var bufferRanking = new List<Cyclist>();

            bufferRanking = _allCyclist;

            while (bufferRanking.Count > 0)
            {
                var first = bufferRanking[0];
                foreach (var cyclist in bufferRanking)
                {
                    if (cyclist.Points > first.Points)
                        first = cyclist;
                }
                ranking.Add(first);
                bufferRanking.Remove(first);
            }
            _allCyclist = ranking;

            foreach (var cyclist in ranking)
            {
                cyclist.first = false;
            }
            ranking[0].first = true;
        }
    }
}
