namespace TP3
{
  partial class LeaderboardForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pnlEntrerNom = new System.Windows.Forms.Panel();
      this.pnlLeaderboard = new System.Windows.Forms.Panel();
      this.flpWrapper = new System.Windows.Forms.FlowLayoutPanel();
      this.pnl = new System.Windows.Forms.Panel();
      this.flpWrapper.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlEntrerNom
      // 
      this.pnlEntrerNom.BackColor = System.Drawing.Color.Silver;
      this.pnlEntrerNom.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlEntrerNom.Location = new System.Drawing.Point(3, 3);
      this.pnlEntrerNom.Name = "pnlEntrerNom";
      this.pnlEntrerNom.Size = new System.Drawing.Size(237, 258);
      this.pnlEntrerNom.TabIndex = 0;
      this.pnlEntrerNom.Visible = false;
      // 
      // pnlLeaderboard
      // 
      this.pnlLeaderboard.BackColor = System.Drawing.Color.DarkRed;
      this.flpWrapper.SetFlowBreak(this.pnlLeaderboard, true);
      this.pnlLeaderboard.Location = new System.Drawing.Point(246, 3);
      this.pnlLeaderboard.Name = "pnlLeaderboard";
      this.pnlLeaderboard.Size = new System.Drawing.Size(357, 258);
      this.pnlLeaderboard.TabIndex = 1;
      // 
      // flpWrapper
      // 
      this.flpWrapper.AutoSize = true;
      this.flpWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flpWrapper.Controls.Add(this.pnlEntrerNom);
      this.flpWrapper.Controls.Add(this.pnlLeaderboard);
      this.flpWrapper.Controls.Add(this.pnl);
      this.flpWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flpWrapper.Location = new System.Drawing.Point(0, 0);
      this.flpWrapper.MinimumSize = new System.Drawing.Size(357, 258);
      this.flpWrapper.Name = "flpWrapper";
      this.flpWrapper.Size = new System.Drawing.Size(607, 345);
      this.flpWrapper.TabIndex = 2;
      // 
      // pnl
      // 
      this.pnl.BackColor = System.Drawing.Color.Maroon;
      this.pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnl.Location = new System.Drawing.Point(3, 267);
      this.pnl.Name = "pnl";
      this.pnl.Size = new System.Drawing.Size(600, 73);
      this.pnl.TabIndex = 2;
      // 
      // LeaderboardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(607, 345);
      this.ControlBox = false;
      this.Controls.Add(this.flpWrapper);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "LeaderboardForm";
      this.Text = "Leaderboard";
      this.flpWrapper.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlEntrerNom;
    private System.Windows.Forms.Panel pnlLeaderboard;
    private System.Windows.Forms.FlowLayoutPanel flpWrapper;
    private System.Windows.Forms.Panel pnl;

  }
}