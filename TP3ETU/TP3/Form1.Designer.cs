﻿namespace TP3
{
  partial class MillipedeGameForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose( );
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent( )
    {
      this.components = new System.ComponentModel.Container();
      this.mainTimer = new System.Windows.Forms.Timer(this.components);
      this.labelScore = new System.Windows.Forms.Label();
      this.lblVies = new System.Windows.Forms.Label();
      this.lblMunitions = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // mainTimer
      // 
      this.mainTimer.Enabled = true;
      this.mainTimer.Interval = 30;
      this.mainTimer.Tick += new System.EventHandler(this.OnTimer);
      // 
      // labelScore
      // 
      this.labelScore.AutoSize = true;
      this.labelScore.BackColor = System.Drawing.Color.Transparent;
      this.labelScore.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelScore.ForeColor = System.Drawing.Color.Aqua;
      this.labelScore.Location = new System.Drawing.Point(3, 1);
      this.labelScore.Name = "labelScore";
      this.labelScore.Size = new System.Drawing.Size(158, 45);
      this.labelScore.TabIndex = 0;
      this.labelScore.Text = "Score : 0";
      // 
      // lblVies
      // 
      this.lblVies.AutoSize = true;
      this.lblVies.BackColor = System.Drawing.Color.Transparent;
      this.lblVies.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblVies.ForeColor = System.Drawing.Color.Aqua;
      this.lblVies.Location = new System.Drawing.Point(3, 46);
      this.lblVies.Name = "lblVies";
      this.lblVies.Size = new System.Drawing.Size(134, 45);
      this.lblVies.TabIndex = 1;
      this.lblVies.Text = "Vies : 3";
      // 
      // lblMunitions
      // 
      this.lblMunitions.AutoSize = true;
      this.lblMunitions.BackColor = System.Drawing.Color.Transparent;
      this.lblMunitions.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMunitions.ForeColor = System.Drawing.Color.Aqua;
      this.lblMunitions.Location = new System.Drawing.Point(3, 91);
      this.lblMunitions.Name = "lblMunitions";
      this.lblMunitions.Size = new System.Drawing.Size(234, 45);
      this.lblMunitions.TabIndex = 2;
      this.lblMunitions.Text = "Munitions : 20";
      // 
      // MillipedeGameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.lblMunitions);
      this.Controls.Add(this.lblVies);
      this.Controls.Add(this.labelScore);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MillipedeGameForm";
      this.Text = "Millipede";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MillipedeGameForm_FormClosing);
      this.Load += new System.EventHandler(this.OnLoad);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer mainTimer;
    private System.Windows.Forms.Label labelScore;
    private System.Windows.Forms.Label lblVies;
    private System.Windows.Forms.Label lblMunitions;
  }
}