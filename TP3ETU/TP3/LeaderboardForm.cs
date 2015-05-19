
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
    public LeaderboardForm()
    {
      InitializeComponent();
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