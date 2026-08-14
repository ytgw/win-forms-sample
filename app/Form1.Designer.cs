using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        countLabel = new Label();
        countLabel.Name = "countLabel";
        countLabel.Text = "Count";
        countLabel.Location = new Point(50, 10);
        countLabel.Size = new Size(200, 30);

        countInput = new NumericUpDown();
        countInput.Name = "countInput";
        countInput.Minimum = 0;
        countInput.Maximum = 1000;
        countInput.Value = 0;
        countInput.Location = new Point(260, 10);
        countInput.Size = new Size(100, 30);

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 500);
        Text = "Form1";
    }

    #endregion

    private Label countLabel;
    private NumericUpDown countInput;
}
