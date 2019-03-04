using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    class Race
    //Go()
    //DrawCyclists()
    //MakeGroup()
    //Move()
    //Slipstream()
    //bool Finished
    //Sprint()
    //List<Cyclist> GetRanking(2 arg)
    //ShowRanking()
    //ShowStats()
    //resetPositions()
    //GetWinner
    //GetSprintBool
    {
        private List<Cyclist> _allCyclist = new List<Cyclist>();
        private char[] _raceGround;
        private Cyclist _winner = new Cyclist();
        private List<Cyclist> _sprinters = new List<Cyclist>();
        private bool _sprint = false;
        private bool _debug = false;
        

        public Race(RaceDatabase raceDatabase)
        {
            Console.Clear();
            _allCyclist = raceDatabase.getCyclistList;
            _raceGround = raceDatabase.getRaceground;
            Console.WriteLine("Debug?(y)");
            if (Console.ReadLine() == "y")
                _debug = true;
        }

        public void Go()
        {
            this.DrawCyclists();
            do
            {
                this.Move();
                this.DrawCyclists();
                this.ShowRanking();
                Console.WriteLine("");
                if (_debug == true)
                    this.ShowStats();
            } while (this.Finished == false);
            this.ResetPositions();
        }

        private void DrawCyclists()
        {
            int yellow = 0;
            int j = 0;
            this.MakeGroup();
            Console.Clear();
            Array.Clear(_raceGround, 0, _raceGround.Length);
            _raceGround[_raceGround.Length - 1] = 'F';

            foreach (Cyclist cyclist in _allCyclist)
            {
                _raceGround[cyclist.Position] = Convert.ToChar(cyclist.Name.Substring(0, 1));
                if (cyclist.first == true)
                {
                    yellow = cyclist.Position;
                }
            }

            foreach (Cyclist cyclist in _allCyclist)
            {
                foreach (Cyclist otherCyclist in _allCyclist)
                {
                    if (cyclist.GetId != otherCyclist.GetId)
                    {
                        if (cyclist.Position == otherCyclist.Position)
                        {
                            _raceGround[cyclist.Position] = Convert.ToChar(Convert.ToString(cyclist.Group).Substring(0,1));
                        }
                    }
                }
            }
            foreach (var i in _raceGround)
            {
                if (j== yellow)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(i);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write(i);
                }
                j++;
            }
            Console.WriteLine("");
        }

        private void MakeGroup()
        {
            int y = 1;
            _allCyclist[0].Group = y;
            for (var i = 0; i < _allCyclist.Count-1; i++)
            {
                if (_allCyclist[i].Position != _allCyclist[i + 1].Position)
                {
                    y++;                 
                }
                _allCyclist[i + 1].Group = y;
            }
        }

        private void Move()
        {
            Random random = new Random();

            foreach (var cyclist in _allCyclist)
            {
                cyclist.Position += random.Next(0, (3 + cyclist.Strength));
                if (cyclist.Position >= _raceGround.Length)
                    cyclist.Position = _raceGround.Length - 1;
            }
            this.Slipstream();
           
        }

        public void Slipstream()
        {
            _allCyclist = this.GetRanking(_allCyclist,false);
            bool slipCheck = false;

            do
            {
                slipCheck = false;
                for (var i = _allCyclist.Count - 1; i > 0; i--)
                {
                    if ((_allCyclist[i - 1].Position - _allCyclist[i].Position) <= (_allCyclist[i].Strength+1) && (_allCyclist[i - 1].Position - _allCyclist[i].Position)>0)
                    {
                        _allCyclist[i].Position = _allCyclist[i - 1].Position;
                        slipCheck = true;
                        foreach (var cyclist in _allCyclist)
                        {
                            if (_allCyclist[i].GetId == cyclist.GetId)
                            {
                                cyclist.Position = _allCyclist[i].Position;
                                
                            }
                        }
                    }
                }
            } while (slipCheck == true);
        }

        private bool Finished
        {
            get
            {
                bool finished = false;
                int first = 0;

                foreach (var cyclist in _allCyclist)
                {
                    if (cyclist.Position == _raceGround.Length - 1)
                    {
                        first += 1;
                    }
                }
                if (first > 1)
                {
                    Console.Clear();
                    this.Sprint();
                    finished = true;
                    _sprint = true;
                    this.ShowRanking();
                }
                else if (first == 1)
                {
                    finished = true;
                    _winner = _allCyclist[0];
                    Console.WriteLine("The winner is {0}.",_allCyclist[0].Name);     
                 }

                Console.ReadLine();
                return finished;
            }
            set
            {

            }
        }

        private void Sprint()
        {
            Random random = new Random();
            Cyclist winner = new Cyclist();
            var sprintranking = new List<Cyclist>();
            int j = 0;

            foreach (var cyclist in _allCyclist)
            {
                if (cyclist.Position == _allCyclist[0].Position)
                    _sprinters.Add(cyclist);
            }

            foreach (var cyclist in _sprinters)
            {
                for(int i = 0; i < 10; i++)
                {
                    cyclist.SprintPosition += random.Next(0, (3 + cyclist.GetSprint));
                }
            }

            sprintranking = this.GetRanking(_sprinters, true);
            _winner = sprintranking[0];

            foreach(var cyclist in sprintranking)
            {
                _allCyclist[j] = cyclist;
                j++;
            }
            Console.WriteLine("The winner in the sprint is {0}.",_winner.Name);
        }

        private List<Cyclist> GetRanking(List<Cyclist> bufferRanking,bool checkSprint)
        {
            var ranking = new List<Cyclist>();

            while (bufferRanking.Count > 0)
            {
                var first = bufferRanking[0];
                foreach (var cyclist in bufferRanking)
                {
                    if (checkSprint)
                    {
                        if (cyclist.SprintPosition > first.SprintPosition)
                            first = cyclist;
                    }
                    else
                    {
                        if (cyclist.Position > first.Position)
                            first = cyclist;
                    }
                }
                ranking.Add(first);
                bufferRanking.Remove(first);
            }
            return ranking;
        }

        private void ShowRanking()
        {
            foreach (var cyclist in _allCyclist)
            {
                if (_allCyclist[0].GetId == cyclist.GetId)
                {
                    Console.WriteLine("- {0} ({1}) {2}", cyclist.Position,cyclist.Group, cyclist.Name);
                }
                else
                {
                    Console.WriteLine("- -{0} ({1}) {2}", _allCyclist[0].Position - cyclist.Position,cyclist.Group, cyclist.Name);
                }
            }
        }

        private void ShowStats()
        {
            foreach (var cyclist in _allCyclist)
            {
                Console.WriteLine("Name: {0} Sprint: {1} Strength: {2}({3})",cyclist.Name,cyclist.GetSprint,cyclist.Strength,cyclist.GetPotential);
            }
        }

        private void ResetPositions()
        {
            foreach (var cyclist in _allCyclist)
            {
                cyclist.Position = 0;
                cyclist.SprintPosition = 0;
            }
        }

        public Cyclist GetWinner
        {
            get
            {
                return _winner;
            }
            set
            {

            }
        }

        public bool GetSprintBool
        {
            get
            {
                return _sprint;
            }
            set
            {

            }
        }

        public Cyclist GetLoser
        {
            get
            {
                return _allCyclist[_allCyclist.Count-1];
            }
            set
            {

            }
        }

        public List<Cyclist> GetFinalRanking
        {
            get
            {
                return _allCyclist;
            }
            set
            {

            }
        }
    }
}
