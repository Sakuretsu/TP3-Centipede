/* Classe représentant la fenêtre principale du jeu. S'occupe de mettre à
 * jour le jeu, d'afficher le formulaire de fin de partie et d'afficher la boite
 * de dialogue de comfirmation pour quitter le jeu.
 * 
 * Créer par Charles Lachance et Tommy Bouffard
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class MillipedeGameForm : Form
  {
    //Le jeu du Millipede
    private MillipedeGame game = null;
    //La fenêtre de fin de partie
    LeaderboardForm leaderboard = null;

    /// <summary>
    /// Initialise la fenêtre du jeu
    /// </summary>
    public MillipedeGameForm( )
    {
      InitializeComponent( );
      //<Charles Lachance>
      //On journalise le démarage du jeu
      Logger.GetInstance().Log("Program started");
      //On crée une nouvelle partie
      game = new MillipedeGame();
      //On crée le tableau de records
      leaderboard = new LeaderboardForm();
      //<Charles Lachance>
    }

    /// <summary>
    /// Évènement appelé lors du chargement du formulaire
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLoad( object sender, EventArgs e )
    {
      //On redimentionne la fenêtre de jeu
      this.ClientSize = new Size( MillipedeGame.GAME_WIDTH, MillipedeGame.GAME_HEIGHT );
    }

    /// <summary>
    /// Évènement appelé lors de chaque affichage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDraw( object sender, PaintEventArgs e )
    {
      //On dessine le jeu
      game.Draw( e.Graphics );
    }

    /// <summary>
    /// Évènement appelé à chaque mis à jour du jeu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTimer( object sender, EventArgs e )
    {
      //On affiche le score du joueur
      labelScore.Text = "Score : " + game.Score;

      //<Charles Lachance>
      //On met à jour le jeu et on récupère le résultat
      EndGameResult result = game.Update( );

      //On affiche le nombre de vies restantes au joueur
      lblVies.Text = "Vies : " + game.Player.NbLives;
      //On affiche le nombre de munitions restantes au joueur
      lblMunitions.Text = "Munitions : " + game.Player.Ammo;

      //Si la partie est finie...
      if (result == EndGameResult.GAME_LOST)
      {
        //On arrête le jeu
        mainTimer.Enabled = false;
        //<Tommy Bouffard>
        //On arrete la musique lorsque la partie se termine.
        MillipedeGame.sndTrack.Stop();
        //</Tommy Bouffard>

        //On passe le score du joueur au tableau des records
        leaderboard.Score = game.Score;
        //Si le joueur ne clique pas sur le bouton quitter...
        if(leaderboard.ShowDialog() != DialogResult.Abort)
        {
          //On crée une nouvelle partie
          game = new MillipedeGame();
          //On reprend le jeu
          mainTimer.Enabled = true;
        }
        else
        {
          //On quitte le programme
          Application.Exit();
        }
      }

      Invalidate( );
    }

    /// <summary>
    /// Évènement appelé à chaque fois que l'on essaie de fermer le programme
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MillipedeGameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      //On arrête le jeu
      mainTimer.Enabled = false;
      //On arrête le son
      MillipedeGame.sndTrack.Stop();
      //On affiche une boite de dialogue demandant à l'utilisateur s'il souhaite quitter et on récupère le résultat
      DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter?", "Quitter?", MessageBoxButtons.YesNo);

      //Si l'utilisateur souhaite quitter...
      if (result == DialogResult.Yes)
      {
        //On le journalise
        Logger.GetInstance().Log("Program stopped");
      }
      else
      {
        //On ne quitte pas
        e.Cancel = true;
        //On reprend le jeu
        mainTimer.Enabled = true;
        //Si le joueur n'est pas mort...
        if (game.Player.NbLives > 0)
          MillipedeGame.sndTrack.PlayLooping(); //On reprend la musique
      }
    }
    //</Charles Lachance>
  }
}
