
//<Charles Lachance>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3
{
  public partial class LeaderboardForm : Form
  {
    string texteFichier = "";
    string[] currentScores = new string[10];
    int[] leaderBoardScoresNumbers = new int[11];
    public LeaderboardForm()
    {
      InitializeComponent();
      //<Tommy Bouffard>
      try
      {
        texteFichier = File.ReadAllText("Leaderboard.txt");
        currentScores = texteFichier.Split(';');
        for (int i = 0; i != currentScores.Length; i++)
        {
          string[] division = currentScores[i].Split(',');
          leaderBoardScoresNumbers[i] = int.Parse(currentScores[0]);
        }
        if (MillipedeGame.Score < leaderBoardScoresNumbers[9])
        {

        }
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("LeaderBoard: " + ex.Message);
      }
      //</Tommy Bouffard>
    }
    /*
     *   
  procédure tri_selection(tableau t, entier n)
      pour i de 1 à n - 1
          min ← i
          pour j de i + 1 à n
              si t[j] < t[min], alors min ← j
          fin pour
          si min ≠ i, alors échanger t[i] et t[min]
      fin pour
  fin procédure
    */
    /// <summary>
    /// Cette finction trie les valeurs du leaderboard.
    /// </summary>
    /// <returns></returns>
    public int[] SortScores()
    {
      return new int[0];
    }
    public void GetLeaderBoard()
    {

    }

    private void btnQuitter_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnNouvellePartie_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnValider_Click(object sender, EventArgs e)
    {
      txtbNom.Text = txtbNom.Text.Trim();
      if (txtbNom.Text != "")
      {
        pnlEntrerNom.Visible = false;
        trvMeilleursScores.Nodes.Add("exemple");
      }
    }

    private void trvMeilleursScores_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
      e.Cancel = true;
    }
  }
}
//</Charles Lachance>