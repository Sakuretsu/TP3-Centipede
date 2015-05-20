using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class MillipedeGameForm : Form
  {
    private MillipedeGame game = null;
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
      lblVie.Text = "Vie : " + game.Player.NbLives;
      if (result == EndGameResult.GAME_LOST)
      {
        mainTimer.Enabled = false;
        //<Tommy Bouffard>
        //On arrete la musique lorsque la partie se termine.
        MillipedeGame.sndTrack.Stop();
        ///Tommy Bouffard
        LeaderboardForm leaderboard = new LeaderboardForm(game.Score);
        if(DialogResult.Abort!=leaderboard.ShowDialog())
        {
          game = new MillipedeGame();
          mainTimer.Enabled = true;
        }
        else
        {
          Application.Exit();
        }
      }
      //</Charles Lachance>

      Invalidate( );
    }

    private void MillipedeGameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Logger.GetInstance().EndLog("Program stopped");
    }
  }
}
