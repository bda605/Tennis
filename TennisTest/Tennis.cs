using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTest
{
    public class Tennis
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0,"Love" },
            {1,"Fifteen" },
            {2,"Thirty" },
            {3,"Forty" }
        };

        public Tennis(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public string Score(int firstPlayerScore, int secondPlayerScore)
        {
            if (IsScoreDiff(firstPlayerScore, secondPlayerScore))
            {
                if (firstPlayerScore > 3 || secondPlayerScore > 3)
                {
                    if (Math.Abs(firstPlayerScore - secondPlayerScore) == 1)
                    {
                        var advPlayer = AdvPlayer(firstPlayerScore, secondPlayerScore);
                        return $"{advPlayer} Adv";
                    }

                    return $"{AdvPlayer(firstPlayerScore, secondPlayerScore)} Win";
                }

                return $"{_scoreLookup[firstPlayerScore]} {_scoreLookup[secondPlayerScore]}";
            }
            if (IsDeuce(firstPlayerScore))
            {
                return Deuce();
            }
            return SameScore(firstPlayerScore);
        }

        private string AdvPlayer(int _firstPlayerScoreTimes, int _secondPlayerScoreTimes)
        {
            return _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayerName
                : _secondPlayerName;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private static bool IsDeuce(int _firstPlayerScoreTimes)
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private string SameScore(int _firstPlayerScoreTimes)
        {
            return $"{_scoreLookup[_firstPlayerScoreTimes]} All";
        }

        private static bool IsScoreDiff(int _firstPlayerScoreTimes, int _secondPlayerScoreTimes)
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }
    }
}
