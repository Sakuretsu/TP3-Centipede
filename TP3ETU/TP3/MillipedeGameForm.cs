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
  public partial class MillipedeGameForm : Form
  {
    private MillipedeGame game = new MillipedeGame( );
    public MillipedeGameForm( )
    {
      InitializeComponent( );
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
      labelScore.Text = "Score : " + MillipedeGame.Score;

      //<Charles Lachance>
      EndGameResult result = game.Update( );
      lblVie.Text = "Vie : " + game.Player.NbLives;
      if (result == EndGameResult.GAME_LOST)
      {
        mainTimer.Enabled = false;
        LeaderboardForm leaderboard = new LeaderboardForm();
        leaderboard.ShowDialog();
        game = new MillipedeGame();
        mainTimer.Enabled = true;
      }
      //</Charles Lachance>

      Invalidate( );
    }
  }
}
