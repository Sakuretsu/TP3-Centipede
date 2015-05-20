using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class MillipedeGameForm : Form
  {
    private MillipedeGame game = null;
    LeaderboardForm leaderboard = new LeaderboardForm();
    public MillipedeGameForm( )
    {
      InitializeComponent( );
      //<Charles Lachance>
      Logger.GetInstance().Log("Program started");
      game = new MillipedeGame();
      //<Charles Lachance>
    }

    private void OnLoad( object sender, EventArgs e )
    {
      this.ClientSize = new Size( MillipedeGame.GAME_WIDTH, MillipedeGame.GAME_HEIGHT );
    }

    private void OnDraw( object sender, PaintEventArgs e )
    {
      game.Draw( e.Graphics );
    }

    private void OnTimer( object sender, EventArgs e )
    {
      // ppoulin
      // Certainement du code à ajouter ici ou dans le OnDraw
      labelScore.Text = "Score : " + game.Score;

      //<Charles Lachance>
      EndGameResult result = game.Update( );
      lblVies.Text = "Vies : " + game.Player.NbLives;
      lblMunitions.Text = "Munitions : " + game.Player.Ammo;
      if (result == EndGameResult.GAME_LOST)
      {
        mainTimer.Enabled = false;
        //<Tommy Bouffard>
        //On arrete la musique lorsque la partie se termine.
        MillipedeGame.sndTrack.Stop();
        //</Tommy Bouffard>
        leaderboard.Score = game.Score;
        if(leaderboard.ShowDialog() != DialogResult.Abort)
        {
          game = new MillipedeGame();
          mainTimer.Enabled = true;
        }
        else
        {
          Application.Exit();
        }
      }

      Invalidate( );
    }

    private void MillipedeGameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      mainTimer.Enabled = false;
      MillipedeGame.sndTrack.Stop();
      DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter?", "Quitter?", MessageBoxButtons.YesNo);
      if (result == DialogResult.Yes)
      {
        Logger.GetInstance().EndLog("Program stopped");
      }
      else
      {
        e.Cancel = true;
        mainTimer.Enabled = true;
        MillipedeGame.sndTrack.PlayLooping();
      }
    }
    //</Charles Lachance>
  }
}
