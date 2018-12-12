using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TennisTest
{
    public class TennisTest
    {
        private Tennis _tennis = new Tennis("Bob", "Jack");

        [Test]
        public void Love_All()
        {
            ScoreShouldBe("Love All", 0, 0);
        }

        [Test]
        public void Fifteen_Love()
        {
            ScoreShouldBe("Fifteen Love", 1, 0);
        }

        [Test]
        public void Thirty_Love()
        {
            ScoreShouldBe("Thirty Love", 2, 0);
        }
        [Test]
        public void Forty_Love()
        {
            ScoreShouldBe("Forty Love", 3, 0);
        }

        [Test]
        public void Love_Fifteen()
        {
            ScoreShouldBe("Love Fifteen", 0, 1);
        }

        [Test]
        public void Love_Thirty()
        {
            ScoreShouldBe("Love Thirty", 0, 2);
        }

        [Test]
        public void Love_Forty()
        {
            ScoreShouldBe("Love Forty", 0, 3);
        }

        [Test]
        public void Fifteen_All()
        {
            ScoreShouldBe("Fifteen All", 1, 1);
        }

        [Test]
        public void Thirty_All()
        {
            ScoreShouldBe("Thirty All", 2, 2);
        }

        [Test]
        public void Deuce()
        {
            ScoreShouldBe("Deuce", 3, 3);
        }

        [Test]
        public void FirstPlayer_Adv()
        {
            ScoreShouldBe("Bob Adv", 4, 3);
        }

        [Test]
        public void SecondPlayer_Adv()
        {
            ScoreShouldBe("Jack Adv", 3, 4);
        }

        [Test]
        public void FirstPlayer_Win()
        {
            ScoreShouldBe("Bob Win", 5, 3);
        }

        [Test]
        public void SecondPlayer_Win()
        {
            ScoreShouldBe("Jack Win", 3, 5);
        }


        private void ScoreShouldBe(string expected, int firstPlayerScore, int secondPlayerScore)
        {
            NUnit.Framework.Assert.AreEqual(expected, _tennis.Score(firstPlayerScore, secondPlayerScore));
        }
    }
}
