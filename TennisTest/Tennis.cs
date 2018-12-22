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
                if (IsReadyForGamePoint(firstPlayerScore, secondPlayerScore))
                {
                    return AdvStatus(firstPlayerScore, secondPlayerScore);
                }
                return ScoreLookup(firstPlayerScore, secondPlayerScore);
            }
            if (IsDeuce(firstPlayerScore))
            {
                return Deuce();
            }
            return SameScore(firstPlayerScore);
        }

        private string ScoreLookup(int firstPlayerScore, int secondPlayerScore)
        {
            return $"{_scoreLookup[firstPlayerScore]} {_scoreLookup[secondPlayerScore]}";
        }

        private string AdvStatus(int firstPlayerScore, int secondPlayerScore)
        {
            return IsAdv(firstPlayerScore, secondPlayerScore)
                ? $"{AdvPlayer(firstPlayerScore, secondPlayerScore)} Adv"
                : $"{AdvPlayer(firstPlayerScore, secondPlayerScore)} Win";
        }

        private static bool IsAdv(int firstPlayerScore, int secondPlayerScore)
        {
            return Math.Abs(firstPlayerScore - secondPlayerScore) == 1;
        }

        private static bool IsReadyForGamePoint(int firstPlayerScore, int secondPlayerScore)
        {
            return firstPlayerScore > 3 || secondPlayerScore > 3;
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
