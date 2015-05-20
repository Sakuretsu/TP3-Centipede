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
      LeaderboardForm board = new LeaderboardForm(0);
    }
    [TestMethod]
    //Vérification de la capacité à intégrer un score au milieu du tableau (on suppose que le tableau est à l'état initial
    //10e place = 2 et 9e place = 23) 
    public void TestEntreeAuMilieu()
    {
      LeaderboardForm board = new LeaderboardForm(20);
      board.SortScores();
      int[] boardAfterSort = board.GetLeaderBoard();
      Assert.AreEqual(boardAfterSort[9],20);
    }
    [TestMethod]
    //Vérifie si un score inférieur à la derniere entrée peut se retrouver dans le tableau
    public void TestNotBestScore()
    {
      LeaderboardForm board = new LeaderboardForm(-1);
      board.SortScores();
      //L'algorithme ne touchera pas au fichier en écriture si il n'est pas plus grand que le dixième élément.
      int[] sortedBoard = board.GetLeaderBoard();
      Assert.AreEqual(sortedBoard[10], -1);
    }
  }
}
