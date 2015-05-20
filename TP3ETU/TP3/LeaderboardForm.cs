
//<Charles Lachance>
using System;
using System.Windows.Forms;
using System.IO;

namespace TP3
{
  public partial class LeaderboardForm : Form
  {
    //Le texte entier du fichier (mis en public pour tests unitaires)
    public string texteFichier = "";
    //Tableau de scores pour le split
    string[] currentScores = new string[10];
    //Tableau des nombres des scores
    int[] leaderBoardScoresNumbers = new int[11];
    //Tableau des des scores avec leur nom (score,nom)
    string[] currentScoresWithNewScore = new string[11];
    //Score du jeu (il faut s'en servir ailleurs que dans le constructeur).
    int score = 0;
    /// <summary>
    /// Cette fonction initialise l'interface du leaderboard
    /// </summary>
    /// <param name="score">Pointage lors de l'appel du leaderboard</param>
    public LeaderboardForm(int score)
    {
      InitializeComponent();
      //<Tommy Bouffard>
      this.score = score;

      //Le chargement du fichier peut lever une exception.
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
        if (score > leaderBoardScoresNumbers[9])
        {
          //<Charles Lachance>
          pnlEntrerNom.Visible = true;
          //</Charles Lachance>
        }
        AfficherScores();
      }
      catch (Exception ex)
      {
        Logger.GetInstance().Log("Highscores:" + ex.Message);
      }
    }
    

    /// <summary>
    /// Cette finction trie les valeurs du leaderboard.
    /// En triant le tableau des pointages du leaderboard, il trie en parallèle le tableau des scores.
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
    //</Tommy Bouffard>
    public int[] GetLeaderBoard()
    {
      return leaderBoardScoresNumbers;
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
        //<Charles Lachance>
        Logger.GetInstance().Log("New leaderboard entry : " + txtbNom.Text + " with " + score + " points");
        //<Charles Lachance>
        AfficherScores();
        EcrireScores();
      }
    }
    //<Tommy Bouffard>
    /// <summary>
    /// Cette fonction écris les pointages du leaderboard dans le fichier leaderboard en regénérant un nouveau fichier.
    /// </summary>
    public void EcrireScores()
    {
      try
      {
        File.Delete("Leaderboard.txt");
        for (int i = 0; i != 10; i++)
        {
          if (i == 9)
          {
            File.AppendAllText("Leaderboard.txt", "\r\n");
          }
          File.AppendAllText("Leaderboard.txt", currentScoresWithNewScore[i]);
          if (i != 9)
          {
            File.AppendAllText("Leaderboard.txt", ";");
          }
        }
      }
      catch (Exception ex)
      {
        Logger.GetInstance().Log("Erreur lors de l'appel EcrireScores dans LeaderBoardForm.cs:" + ex.Message);
      }
    }
    /// <summary>
    /// Cette fonction fait afficher les scores sur le formulaire.
    /// </summary>
    private void AfficherScores()
    {
      trvMeilleursScores.Nodes.Clear();
      for (int i = 0; i != 10; i++)
      {
        string scoreStr = currentScoresWithNewScore[i].Split(',')[0];
        string nameStr = currentScoresWithNewScore[i].Split(',')[1];
        trvMeilleursScores.Nodes.Add((i + 1) + " - " + nameStr + " (" + scoreStr + ")");
      }
    }
    //</Tommy Bouffard>

    private void trvMeilleursScores_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void txtbNom_TextChanged(object sender, EventArgs e)
    {
      if (txtbNom.Text.Length > 0 && Char.IsLetterOrDigit(txtbNom.Text[txtbNom.Text.Length - 1]))
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