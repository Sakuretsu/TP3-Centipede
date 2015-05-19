
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
      if ((txtbNom.Text = txtbNom.Text.Trim()).Length != 0)
      {
        pnlEntrerNom.Visible = false;
        trvMeilleursScores.Nodes.Add("exemple");
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