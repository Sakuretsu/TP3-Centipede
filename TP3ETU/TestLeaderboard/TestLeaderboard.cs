using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3;

namespace TestLeaderboard
{
  [TestClass]
  public class TestLeaderboard
  {
    [TestMethod]
    [ExpectedException(typeof(Exception),
    "Une exception a été levée")]
    //Test du chargement du fichier: On s'attend à ne pas avoir d'exception d'aucun genre.
    //(Le test devrait échouer car il n'y devrait pas avoir d'exception)
    public void TestChargementFichier()
    {
      LeaderboardForm board = new LeaderboardForm();
    }
    [TestMethod]
    //Vérification de la capacité à intégrer un score au milieu du tableau (on suppose que le tableau est à l'état initial
    //10e place = 2 et 9e place = 23)
    public void TestEntreeAuMilieu()
    {
      LeaderboardForm board = new LeaderboardForm();
      board.ScoreTester = 50;
      board.SortScores();
      Assert.AreEqual(board.GetLeaderBoard()[7], 50);
    }
    [TestMethod]
    //Vérifie si un score inférieur à la derniere entrée peut se retrouver dans le tableau
    public void TestMiddleScore()
    {
      LeaderboardForm board = new LeaderboardForm();
      board.ScoreTester = -1;
      //L'algorithme ne touchera pas au fichier en écriture si il n'est pas plus grand que le dixième élément.
      Assert.AreEqual(board.GetLeaderBoard()[10], -1);
    }
    [TestMethod]
    //Vérifie si un pointage peut être le meilleur
    public void TestBestScore()
    {
      LeaderboardForm board = new LeaderboardForm();
      board.ScoreTester = 666;
      board.SortScores();
      Assert.AreEqual(board.GetLeaderBoard()[0], 666);
    }
    //Vérifie si un pointage peut être le dixième (dernier).
    [TestMethod]
    public void TestLastScore()
    {
      LeaderboardForm board = new LeaderboardForm();
      board.ScoreTester = 1;
      board.SortScores();
      Assert.AreEqual(board.GetLeaderBoard()[9], 1);
    }

    //<Charles Lachance>
    //Vérifie si le leaderboard sauvegarde dans le bon format
    [TestMethod]
    public void TestScoreSaveFormat()
    {
      LeaderboardForm board = new LeaderboardForm();
      board.PlayerName = "René";
      board.ScoreTester = 999;
      board.SortScores();
      board.ScoreTester = 998;
      board.SortScores();
      board.ScoreTester = 997;
      board.SortScores();
      board.ScoreTester = 996;
      board.SortScores();
      board.PlayerName = "Descartes";
      board.ScoreTester = 995;
      board.SortScores();
      board.ScoreTester = 994;
      board.SortScores();
      board.ScoreTester = 993;
      board.SortScores();
      board.ScoreTester = 992;
      board.SortScores();
      board.ScoreTester = 991;
      board.SortScores();
      board.ScoreTester = 990;
      board.SortScores();
      board.EcrireScores();

      Assert.AreEqual("999,René;\n" +
                      "998,René;\n" +
                      "997,René;\n" +
                      "996,René;\n" +
                      "995,Descartes;\n" +
                      "994,Descartes;\n" +
                      "993,Descartes;\n" +
                      "992,Descartes;\n" +
                      "991,Descartes;\n" +
                      "990,Descartes;\n", File.ReadAllText("Leaderboard.txt"));
    }

    //Vérifie si le leaderboard crash lors de l'ouverture d'un fichier inexistant
    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException), "Fichier inexistant")]
    public void TestScoreSaveFormat()
    {
      if (File.Exists("Leaderboard.txt"))
      {
        File.Delete("Leaderboard.txt");
      }

      LeaderboardForm board = new LeaderboardForm();
    }

    //Vérifie si le leaderboard crash lors de l'écriture dans un fichier inexistant
    [TestMethod]
    public void TestScoreSaveFormat()
    {
      LeaderboardForm board = new LeaderboardForm();

      if (File.Exists("Leaderboard.txt"))
      {
        File.Delete("Leaderboard.txt");
      }

      try
      {
        board.EcrireScores();
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
    }
    //</Charles Lachance>
  }
}
