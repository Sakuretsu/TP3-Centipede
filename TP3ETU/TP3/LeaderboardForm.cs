
//<Charles Lachance>
using System;
using System.Windows.Forms;
using System.IO;

namespace TP3
{
  public partial class LeaderboardForm : Form
  {
    string texteFichier = "";
    string[] currentScores = new string[10];
    int[] leaderBoardScoresNumbers = new int[11];
    string[] currentScoresWithNewScore = new string[11];
    int score = 0;
    public LeaderboardForm(int score)
    {
      this.score = score;
      InitializeComponent();
      //<Tommy Bouffard>
      txtbNom.Visible = true;
      btnValider.Visible = true;
      lblMeilleursScores.Visible = true;
      lblNouveauRecord.Text = "Nouveau record!";
      try
      {
        texteFichier = File.ReadAllText("Leaderboard.txt");
        currentScores = texteFichier.Split(';');
        for (int i = 0; i != currentScores.Length; i++)
        {
          currentScoresWithNewScore[i] = currentScores[i];
          string[] division = currentScores[i].Split(',');
          leaderBoardScoresNumbers[i] = int.Parse(division[0]);
        }
        leaderBoardScoresNumbers[10] = score;
        if (score < leaderBoardScoresNumbers[9])
        {
          txtbNom.Visible = false;
          btnValider.Visible = false;
          lblMeilleursScores.Visible = false;
          lblVeuillezEntrerNom.Visible = false;
          lblNouveauRecord.Text = "Game Over!";
        }
        AfficherScores();
      }
      catch (Exception ex)
      {
        Logger.GetInstance().Log("Highscores:" + ex.Message);
      }
      //</Tommy Bouffard>
    }
    /*
     *   
    */
    /// <summary>
    /// Cette finction trie les valeurs du leaderboard.
    /// </summary>
    public void SortScores()
    {
      for (int i = 0; i != currentScoresWithNewScore.Length-1; i++)
      {
        int max = i;
        for (int j = i+1; j!= currentScoresWithNewScore.Length; j++)
        {
          if (leaderBoardScoresNumbers[j]> leaderBoardScoresNumbers[max])
          {
            max = j;
          }
          if (max !=i)
          {
            int exchange = leaderBoardScoresNumbers[i];
            leaderBoardScoresNumbers[i] = leaderBoardScoresNumbers[max];
            leaderBoardScoresNumbers[max] = exchange;
            string exchange2 = currentScoresWithNewScore[i];
            currentScoresWithNewScore[i] = currentScoresWithNewScore[max];
            currentScoresWithNewScore[max] = exchange2;
          }
        }
      }
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
        currentScoresWithNewScore[10] = score + "," + txtbNom.Text;
        SortScores();
        pnlEntrerNom.Visible = false;
        AfficherScores();
        EcrireScores();
      }
    }
    private void EcrireScores()
    {
      File.Delete("Leaderboard.txt");
      for (int i = 0; i != 10; i++)
      {
        File.AppendAllText("Leaderboard.txt", currentScoresWithNewScore[i]);
        if (i !=9)
        {
          File.AppendAllText("Leaderboard.txt", ";");
        }
      }
    }
    private void AfficherScores()
    {
      trvMeilleursScores.Nodes.Clear();
      for (int i = 0; i != 10; i++)
      {
        trvMeilleursScores.Nodes.Add(currentScoresWithNewScore[i]);
      }
    }

    private void trvMeilleursScores_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void txtbNom_TextChanged(object sender, EventArgs e)
    {
      if (Char.IsLetterOrDigit(txtbNom.Text[txtbNom.Text.Length - 1]))
      {
        btnValider.Enabled = true;
      }
      else
      {
        btnValider.Enabled = false;
      }
    }
  }
}
//</Charles Lachance>