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
      this.SuspendLayout();
      // 
      // mainTimer
      // 
      this.mainTimer.Enabled = true;
      this.mainTimer.Interval = 30;
      this.mainTimer.Tick += new System.EventHandler(this.OnTimer);
      // 
      // MillipedeGameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MillipedeGameForm";
      this.Text = "Millipede";
      this.Load += new System.EventHandler(this.OnLoad);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer mainTimer;
  }
}