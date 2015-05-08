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
  public partial class Form1 : Form
  {
    private MillipedeGame game = new MillipedeGame( );
    public Form1( )
    {
      InitializeComponent( );
    }

    private void OnLoad( object sender, EventArgs e )
    {
      //this.ClientSize = new Size( MillipedeGame.WIDTH, MillipedeGame.HEIGHT );
    }

    private void OnDraw( object sender, PaintEventArgs e )
    {
      game.Draw( e.Graphics );
    }

    private void OnTimer( object sender, EventArgs e )
    {
      // ppoulin
      // Certainement du code à ajouter ici ou dans le OnDraw
      game.Update( );
      Invalidate( );

    }
  }
}
