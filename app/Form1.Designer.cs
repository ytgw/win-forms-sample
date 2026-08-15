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

        headerBodySplitter = new SplitContainer
        {
            Dock = DockStyle.Fill,
            IsSplitterFixed = true,
            Name = "headerBodySplitter",
            Orientation = Orientation.Horizontal,
            SplitterDistance = 50,
            Panel1MinSize = 50,
        };
        headerBodySplitter.Panel1.BackColor = Color.LightGray;

        bodySplitter = new SplitContainer
        {
            Dock = DockStyle.Fill,
            IsSplitterFixed = true,
            Name = "bodySplitter",
            Orientation = Orientation.Vertical,
        };

        leftPanel = new FlowLayoutPanel
        {
            AutoScroll = true,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(10),
            WrapContents = true,
        };

        rightPanel = new FlowLayoutPanel
        {
            AutoScroll = true,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(10),
            WrapContents = true,
        };

        countLabel = new Label()
        {
            Location = new Point(50, 10),
            Name = "countLabel",
            Size = new Size(200, 30),
            Text = "Count",
        };

        countInput = new NumericUpDown()
        {
            Location = new Point(260, 10),
            Minimum = 0,
            Maximum = 1000,
            Name = "countInput",
            Size = new Size(100, 30),
            Value = 0,
        };

        Controls.Add(headerBodySplitter);

        headerBodySplitter.Panel1.Controls.Add(countLabel);
        headerBodySplitter.Panel1.Controls.Add(countInput);
        headerBodySplitter.Panel2.Controls.Add(bodySplitter);

        bodySplitter.Panel1.Controls.Add(leftPanel);
        bodySplitter.Panel2.Controls.Add(rightPanel);

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 500);
        Text = "Form1";
    }

    #endregion

    private SplitContainer headerBodySplitter;
    private SplitContainer bodySplitter;
    private FlowLayoutPanel leftPanel ;
    private FlowLayoutPanel rightPanel;
    private Label countLabel;
    private NumericUpDown countInput;
}
