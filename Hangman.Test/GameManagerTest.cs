using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL;
using Hangman.BLL.Enum;
using Hangman.BLL.Implementations;
using Hangman.BLL.Interfaces;
using Hangman.BLL.Management;
using NUnit.Framework;


namespace Hangman.Test
{
    [TestFixture]
    public class GameManagerTest
    {
        [Test]
        public void TestWin()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            var result = gm.ValidateGuess(player1.GetGuess("Apple"), player1, player2);

            Assert.That(result, Is.EqualTo(GuessResponse.Win));
        }
        [Test]
        public void TestLoss()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("c"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("d"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("f"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("g"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("z"), player1, player2);
            var result = gm.ValidateGuess(player1.GetGuess("h"), player1, player2);

            Assert.That(result, Is.EqualTo(GuessResponse.Loss));
        }
        [Test]
        public void TestDuplicate()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("c"), player1, player2);
            var result = gm.ValidateGuess(player1.GetGuess("c"), player1, player2);
            Assert.That(result, Is.EqualTo(GuessResponse.Duplicate));
        }
        [Test]
        public void TestCorrect()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            var result = gm.ValidateGuess(player1.GetGuess("p"), player1, player2);
            Assert.That(result, Is.EqualTo(GuessResponse.Correct));
        }
        [Test]
        public void TestInCorrect()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            var result = gm.ValidateGuess(player1.GetGuess("z"), player1, player2);
            Assert.That(result, Is.EqualTo(GuessResponse.Incorrect));
        }
        [Test]
        public void TestWordState()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("z"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("A"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("z"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("l"), player1, player2);
            //wordState should be A,_,_,l,_ so assert that gm.WordState is that
            List<string> testWord = new List<string>
            {
                "A","_","_","l","_"
            };
            Assert.That(gm.wordStatus, Is.EqualTo(testWord));
            gm.WordToGuess = "Plastic";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("P"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("a"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("i"), player1, player2);
            List<string> testWord2 = new List<string>
            {
                "P","_","a","_","_", "i", "_"
            };
            Assert.That(gm.wordStatus, Is.EqualTo(testWord2));
            gm.WordToGuess = "Bottlecap";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("B"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("t"), player1, player2);
            gm.ValidateGuess(player1.GetGuess("a"), player1, player2);
            List<string> testWord3 = new List<string>
            {
                "B","_","t","t","_", "_", "_", "a", "_"
            };
            Assert.That(gm.wordStatus, Is.EqualTo(testWord3));
        }
        [Test]
        public void TestWinCount()
        {
            TestPlayer player1 = new TestPlayer();
            TestPlayer player2 = new TestPlayer();
            GameManager gm = new GameManager();
            gm.WordToGuess = "Apple";
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("Apple"), player1, player2);
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("Apple"), player1, player2);
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("Apple"), player1, player2);
            gm.StartRound();
            gm.ValidateGuess(player1.GetGuess("Apple"), player1, player2);
            Assert.That(player1.Wins, Is.EqualTo(4));
            Assert.That(player2.Losses, Is.EqualTo(4));
        }
    }
}
