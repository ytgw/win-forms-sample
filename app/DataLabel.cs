using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


public class DataLabel : IDisposable
{
    public readonly Panel LabelPanel = new Panel
    {
        Size = new Size(200, 40),
        Margin = new Padding(5),
        BackColor = Color.White,
        BorderStyle = BorderStyle.FixedSingle,
    };
    public readonly Func<int, bool> ShouldBeVisible;

    private readonly Label NameLabel;
    private readonly Label ValueLabel;
    private int count = 0;

    public DataLabel(string text, Func<int, bool> shouldBeVisible)
    {
        this.ShouldBeVisible = shouldBeVisible;

        this.NameLabel = new Label
        {
            Text = text,
            Size = new Size(100, 30),
            Margin = new Padding(5),
            Location = new Point(0, 0),
            TextAlign = ContentAlignment.MiddleCenter
        };
        this.ValueLabel = new Label
        {
            Text = $"{count}",
            Size = new Size(100, 30),
            Margin = new Padding(5),
            Location = new Point(100, 0),
            TextAlign = ContentAlignment.MiddleCenter
        };
        this.LabelPanel.Controls.Add(this.NameLabel);
        this.LabelPanel.Controls.Add(this.ValueLabel);

        this.NameLabel.Click += this.NameLabel_Click;
    }

    private void NameLabel_Click(object _sender, EventArgs _e)
    {
        this.count++;
        this.ValueLabel.Text = $"{this.count}";
    }

    public void SetVisible(int num)
    {
        this.LabelPanel.Visible = this.ShouldBeVisible(num);
    }

    public void Dispose()
    {
        this.LabelPanel.Dispose();
    }
}
