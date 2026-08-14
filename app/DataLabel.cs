using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


public class DataStore
{
    public int Count { get; set; } = 0;
}


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
    private readonly DataStore dataStore;

    public DataLabel(string text, Func<int, bool> shouldBeVisible, DataStore dataStore)
    {
        this.ShouldBeVisible = shouldBeVisible;
        this.dataStore = dataStore;

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
            Text = "null",
            Size = new Size(100, 30),
            Margin = new Padding(5),
            Location = new Point(100, 0),
            TextAlign = ContentAlignment.MiddleCenter
        };
        this.LabelPanel.Controls.Add(this.NameLabel);
        this.LabelPanel.Controls.Add(this.ValueLabel);
    }

    public void Update()
    {
        this.LabelPanel.Visible = this.ShouldBeVisible(dataStore.Count);
        this.ValueLabel.Text = $"{dataStore.Count}";
    }

    public void Dispose()
    {
        this.LabelPanel.Dispose();
    }
}
