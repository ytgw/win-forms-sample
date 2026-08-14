using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


public class ConditionalButton : IDisposable
{
    public readonly Button Button;
    public readonly Func<int, bool> ShouldBeVisible;

    private int count = 0;
    private readonly string text;

    public ConditionalButton(string text, Func<int, bool> shouldBeVisible)
    {
        this.text = text;
        this.Button = new Button { Text = text, Size = new Size(100, 40), Margin = new Padding(5), Name = $"ConditionalButton_{text}" };
        this.ShouldBeVisible = shouldBeVisible;
        this.Button.Click += this.Button_Click;
    }

    private void Button_Click(object _sender, EventArgs _e)
    {
        this.count++;
        this.Button.Text = $"{this.text}-{this.count}";
    }

    public void SetButtonVisible(int num)
    {
        this.Button.Visible = this.ShouldBeVisible(num);
    }

    public void Dispose()
    {
        this.Button.Click -= this.Button_Click;
        this.Button.Dispose();
    }
}
