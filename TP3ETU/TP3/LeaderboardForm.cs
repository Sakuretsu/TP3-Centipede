/* Formulaire représentant un tableau gradant en mémoire les dix meilleurs scores
 * 
 * Créer par Charles Lachance et Tommy Bouffard
 */
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

    //<Charles Lachance>
    //Est-ce que le joueur a déjà sauvegarder son record
    private bool hasEnteredScore = false;
    //</Charles Lachance>

    /// <summary>
    /// Cette fonction initialise l'interface du leaderboard
    /// </summary>
    /// <param name="score">Pointage lors de l'appel du leaderboard</param>
    public LeaderboardForm()
    {
      InitializeComponent();
      hasEnteredScore = false;
      //<Tommy Bouffard>
      //Le chargement du fichier peut lever une exception.
      try
      {
        texteFichier = File.ReadAllText("Leaderboard.txt");
      }
      catch (Exception ex)
      {
        Logger.GetInstance().Log("Highscores:" + ex.Message);
      }
      currentScores = texteFichier.Split(';');
      for (int i = 0; i != currentScores.Length; i++)
      {
        currentScoresWithNewScore[i] = currentScores[i];
        string[] division = currentScores[i].Split(',');
        leaderBoardScoresNumbers[i] = int.Parse(division[0]);
      }
    }
    
    /// <summary>
    /// Propriété permettant de modifier le score du joueur
    /// </summary>
    public int Score
    {
      get
      {
        return score;
      }

      set
      {
        score = value;
      }
    }
    //Cette propriété c# est nécéssaire pour les teste unitaires
    public int ScoreTester
    {
      get
      {
        return 50;
      }
      set
      {
        leaderBoardScoresNumbers[10] = value;
      }
    }
    /// <summary>
    /// Cette fonction trie les valeurs du leaderboard.
    /// En triant le tableau des pointages du leaderboard, il trie en parallèle le tableau des scores.
    /// </summary>
    public void SortScores()
    {
      for (int i = 0; i != currentScoresWithNewScore.Length; i++)
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

    public int[] GetLeaderBoard()
    {
      return leaderBoardScoresNumbers;
    }
    //</Tommy Bouffard>

    /// <summary>
    /// Évènement appelé lors d'un clique sur le bouton "Nouvelle partie"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNouvellePartie_Click(object sender, EventArgs e)
    {
      //Le joueur a le potentiel de faire un nouveau record
      hasEnteredScore = false;
      //On ferme le formulaire
      this.Close();
    }

    /// <summary>
    /// Évènement appelé lors d'un clique sur le bouton "Valider"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnValider_Click(object sender, EventArgs e)
    {
      //On enlève les espaces de début et de fin de ligne
      txtbNom.Text = txtbNom.Text.Trim();

      //Si le champ n'est pas vide...
      if (txtbNom.Text != "")
      {
        //<Tommy Bouffard>
        currentScoresWithNewScore[10] = score + "," + txtbNom.Text;
        SortScores();
        //</Tommy Bouffard>

        //On cache la partie permettant d'entrer son nom
        pnlEntrerNom.Visible = false;
        //Le joueur a entré un nouveau record
        hasEnteredScore = true;
        //On journalise le nouveau record
        Logger.GetInstance().Log("New leaderboard entry : " + txtbNom.Text + " with " + score + " points");
        //<Tommy Bouffard>
        AfficherScores();
        EcrireScores();
        //</Tommy Bouffard>
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

    /// <summary>
    /// Évènement appelé lors du clique sur un élément de la liste des records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trvMeilleursScores_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
      //On annule l'évènement
      e.Cancel = true;
    }

    /// <summary>
    /// Évènement appelé lorsque la valeur du champ permettant d'entrer son nom change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtbNom_TextChanged(object sender, EventArgs e)
    {
      //Si la longueur du champ est strictement positive et que le dernier caractère entré est une lettre ou un chiffre...
      if (txtbNom.Text.Length > 0 && Char.IsLetterOrDigit(txtbNom.Text[txtbNom.Text.Length - 1]))
      {
        //On active le boutton pour valider son nom
        btnValider.Enabled = true;
      }
      else
      {
        //On désactive le boutton pour valider son nom
        btnValider.Enabled = false;
      }
    }

    /// <summary>
    /// Évènement appelé lors du premier affichage du leaderboard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LeaderboardForm_Shown(object sender, EventArgs e)
    {
      //<Tommy Bouffard>
      leaderBoardScoresNumbers[10] = score;
      //<Charles Lachance>
      //On affiche le score du joueur
      lblNbPoints.Text = "Votre score : " + score;
      //</Charles Lachance>
      if (score > leaderBoardScoresNumbers[9] && !hasEnteredScore)
      {
        pnlEntrerNom.Visible = true;
      }
      AfficherScores();
      //</Tommy Bouffard>
    }
  }
}
//</Charles Lachance>