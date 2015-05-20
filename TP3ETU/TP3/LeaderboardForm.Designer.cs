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
      this.btnValider = new System.Windows.Forms.Button();
      this.txtbNom = new System.Windows.Forms.TextBox();
      this.lblNouveauRecord = new System.Windows.Forms.Label();
      this.lblVeuillezEntrerNom = new System.Windows.Forms.Label();
      this.pnlLeaderboard = new System.Windows.Forms.Panel();
      this.tlpMeilleursScores = new System.Windows.Forms.TableLayoutPanel();
      this.trvMeilleursScores = new System.Windows.Forms.TreeView();
      this.lblMeilleursScores = new System.Windows.Forms.Label();
      this.flpWrapper = new System.Windows.Forms.FlowLayoutPanel();
      this.pnl = new System.Windows.Forms.Panel();
      this.btnQuitter = new System.Windows.Forms.Button();
      this.btnNouvellePartie = new System.Windows.Forms.Button();
      this.pnlEntrerNom.SuspendLayout();
      this.pnlLeaderboard.SuspendLayout();
      this.tlpMeilleursScores.SuspendLayout();
      this.flpWrapper.SuspendLayout();
      this.pnl.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlEntrerNom
      // 
      this.pnlEntrerNom.BackColor = System.Drawing.Color.Black;
      this.pnlEntrerNom.Controls.Add(this.btnValider);
      this.pnlEntrerNom.Controls.Add(this.txtbNom);
      this.pnlEntrerNom.Controls.Add(this.lblNouveauRecord);
      this.pnlEntrerNom.Controls.Add(this.lblVeuillezEntrerNom);
      this.pnlEntrerNom.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlEntrerNom.Location = new System.Drawing.Point(3, 3);
      this.pnlEntrerNom.Name = "pnlEntrerNom";
      this.pnlEntrerNom.Size = new System.Drawing.Size(237, 258);
      this.pnlEntrerNom.TabIndex = 0;
      this.pnlEntrerNom.Visible = false;
      // 
      // btnValider
      // 
      this.btnValider.Location = new System.Drawing.Point(147, 86);
      this.btnValider.Name = "btnValider";
      this.btnValider.Size = new System.Drawing.Size(75, 23);
      this.btnValider.TabIndex = 3;
      this.btnValider.Text = "Valider";
      this.btnValider.UseVisualStyleBackColor = true;
      this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
      // 
      // txtbNom
      // 
      this.txtbNom.Location = new System.Drawing.Point(14, 89);
      this.txtbNom.Name = "txtbNom";
      this.txtbNom.Size = new System.Drawing.Size(127, 20);
      this.txtbNom.TabIndex = 2;
      // 
      // lblNouveauRecord
      // 
      this.lblNouveauRecord.AutoSize = true;
      this.lblNouveauRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNouveauRecord.ForeColor = System.Drawing.Color.White;
      this.lblNouveauRecord.Location = new System.Drawing.Point(9, 6);
      this.lblNouveauRecord.Name = "lblNouveauRecord";
      this.lblNouveauRecord.Size = new System.Drawing.Size(186, 25);
      this.lblNouveauRecord.TabIndex = 1;
      this.lblNouveauRecord.Text = "Nouveau record!";
      // 
      // lblVeuillezEntrerNom
      // 
      this.lblVeuillezEntrerNom.AutoSize = true;
      this.lblVeuillezEntrerNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblVeuillezEntrerNom.ForeColor = System.Drawing.Color.White;
      this.lblVeuillezEntrerNom.Location = new System.Drawing.Point(10, 66);
      this.lblVeuillezEntrerNom.Name = "lblVeuillezEntrerNom";
      this.lblVeuillezEntrerNom.Size = new System.Drawing.Size(209, 20);
      this.lblVeuillezEntrerNom.TabIndex = 0;
      this.lblVeuillezEntrerNom.Text = "Veuillez entrer votre nom";
      // 
      // pnlLeaderboard
      // 
      this.pnlLeaderboard.BackColor = System.Drawing.Color.Black;
      this.pnlLeaderboard.Controls.Add(this.tlpMeilleursScores);
      this.flpWrapper.SetFlowBreak(this.pnlLeaderboard, true);
      this.pnlLeaderboard.Location = new System.Drawing.Point(246, 3);
      this.pnlLeaderboard.Name = "pnlLeaderboard";
      this.pnlLeaderboard.Size = new System.Drawing.Size(357, 258);
      this.pnlLeaderboard.TabIndex = 1;
      // 
      // tlpMeilleursScores
      // 
      this.tlpMeilleursScores.ColumnCount = 1;
      this.tlpMeilleursScores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpMeilleursScores.Controls.Add(this.trvMeilleursScores, 0, 1);
      this.tlpMeilleursScores.Controls.Add(this.lblMeilleursScores, 0, 0);
      this.tlpMeilleursScores.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpMeilleursScores.Location = new System.Drawing.Point(0, 0);
      this.tlpMeilleursScores.Name = "tlpMeilleursScores";
      this.tlpMeilleursScores.RowCount = 2;
      this.tlpMeilleursScores.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpMeilleursScores.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tlpMeilleursScores.Size = new System.Drawing.Size(357, 258);
      this.tlpMeilleursScores.TabIndex = 2;
      // 
      // trvMeilleursScores
      // 
      this.trvMeilleursScores.BackColor = System.Drawing.Color.Black;
      this.trvMeilleursScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.trvMeilleursScores.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trvMeilleursScores.ForeColor = System.Drawing.Color.White;
      this.trvMeilleursScores.Location = new System.Drawing.Point(3, 27);
      this.trvMeilleursScores.Name = "trvMeilleursScores";
      this.trvMeilleursScores.Scrollable = false;
      this.trvMeilleursScores.ShowLines = false;
      this.trvMeilleursScores.ShowPlusMinus = false;
      this.trvMeilleursScores.ShowRootLines = false;
      this.trvMeilleursScores.Size = new System.Drawing.Size(351, 228);
      this.trvMeilleursScores.TabIndex = 0;
      this.trvMeilleursScores.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvMeilleursScores_BeforeSelect);
      // 
      // lblMeilleursScores
      // 
      this.lblMeilleursScores.BackColor = System.Drawing.Color.Transparent;
      this.lblMeilleursScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMeilleursScores.ForeColor = System.Drawing.Color.White;
      this.lblMeilleursScores.Location = new System.Drawing.Point(3, 0);
      this.lblMeilleursScores.Name = "lblMeilleursScores";
      this.lblMeilleursScores.Size = new System.Drawing.Size(163, 24);
      this.lblMeilleursScores.TabIndex = 1;
      this.lblMeilleursScores.Text = "Meilleurs scores";
      // 
      // flpWrapper
      // 
      this.flpWrapper.AutoSize = true;
      this.flpWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flpWrapper.Controls.Add(this.pnlEntrerNom);
      this.flpWrapper.Controls.Add(this.pnlLeaderboard);
      this.flpWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flpWrapper.Location = new System.Drawing.Point(0, 0);
      this.flpWrapper.MinimumSize = new System.Drawing.Size(357, 258);
      this.flpWrapper.Name = "flpWrapper";
      this.flpWrapper.Size = new System.Drawing.Size(607, 290);
      this.flpWrapper.TabIndex = 2;
      // 
      // pnl
      // 
      this.pnl.BackColor = System.Drawing.Color.Black;
      this.pnl.Controls.Add(this.btnQuitter);
      this.pnl.Controls.Add(this.btnNouvellePartie);
      this.pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnl.Location = new System.Drawing.Point(0, 290);
      this.pnl.Name = "pnl";
      this.pnl.Size = new System.Drawing.Size(607, 55);
      this.pnl.TabIndex = 4;
      // 
      // btnQuitter
      // 
      this.btnQuitter.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.btnQuitter.Location = new System.Drawing.Point(52, 13);
      this.btnQuitter.Name = "btnQuitter";
      this.btnQuitter.Size = new System.Drawing.Size(75, 23);
      this.btnQuitter.TabIndex = 0;
      this.btnQuitter.Text = "Quitter";
      this.btnQuitter.UseVisualStyleBackColor = true;
      // 
      // btnNouvellePartie
      // 
      this.btnNouvellePartie.Location = new System.Drawing.Point(134, 13);
      this.btnNouvellePartie.Name = "btnNouvellePartie";
      this.btnNouvellePartie.Size = new System.Drawing.Size(103, 23);
      this.btnNouvellePartie.TabIndex = 1;
      this.btnNouvellePartie.Text = "Nouvelle partie";
      this.btnNouvellePartie.UseVisualStyleBackColor = true;
      this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
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
      this.Controls.Add(this.pnl);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "LeaderboardForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Game Over!";
      this.pnlEntrerNom.ResumeLayout(false);
      this.pnlEntrerNom.PerformLayout();
      this.pnlLeaderboard.ResumeLayout(false);
      this.tlpMeilleursScores.ResumeLayout(false);
      this.flpWrapper.ResumeLayout(false);
      this.pnl.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlEntrerNom;
    private System.Windows.Forms.Panel pnlLeaderboard;
    private System.Windows.Forms.FlowLayoutPanel flpWrapper;
    private System.Windows.Forms.Panel pnl;
    private System.Windows.Forms.Button btnQuitter;
    private System.Windows.Forms.Button btnNouvellePartie;
    private System.Windows.Forms.Button btnValider;
    private System.Windows.Forms.TextBox txtbNom;
    private System.Windows.Forms.Label lblNouveauRecord;
    private System.Windows.Forms.Label lblVeuillezEntrerNom;
    private System.Windows.Forms.Label lblMeilleursScores;
    private System.Windows.Forms.TreeView trvMeilleursScores;
    private System.Windows.Forms.TableLayoutPanel tlpMeilleursScores;

  }
}