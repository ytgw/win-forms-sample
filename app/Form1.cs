using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


public class ConditionalButton: IDisposable
{
    public readonly Button Button;
    public readonly Func<int, bool> ShouldBeVisible;

    private int count = 0;
    private readonly string text;

    public ConditionalButton(string text, Func<int, bool> shouldBeVisible)
    {
        this.text = text;
        this.Button = new Button { Text = text, Size = new Size(100, 40), Margin = new Padding(5) };
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


public class Form1Util
{
    public Func<int, bool> CreateVisibilityCondition(int denominator)
    {
        return (int num) => num % denominator == 0;
    }

    public ConditionalButton[] CreateButtons()
    {
        ConditionalButton[] buttons = {
            new ConditionalButton("2", this.CreateVisibilityCondition(2)),
            new ConditionalButton("3", this.CreateVisibilityCondition(3)),
            new ConditionalButton("5", this.CreateVisibilityCondition(5)),
            new ConditionalButton("7", this.CreateVisibilityCondition(7)),
            new ConditionalButton("9", this.CreateVisibilityCondition(9)),

            new ConditionalButton("12", this.CreateVisibilityCondition(2)),
            new ConditionalButton("13", this.CreateVisibilityCondition(3)),
            new ConditionalButton("15", this.CreateVisibilityCondition(5)),
            new ConditionalButton("17", this.CreateVisibilityCondition(7)),
            new ConditionalButton("19", this.CreateVisibilityCondition(9)),

            new ConditionalButton("22", this.CreateVisibilityCondition(2)),
            new ConditionalButton("23", this.CreateVisibilityCondition(3)),
            new ConditionalButton("25", this.CreateVisibilityCondition(5)),
            new ConditionalButton("27", this.CreateVisibilityCondition(7)),
            new ConditionalButton("29", this.CreateVisibilityCondition(9)),

            new ConditionalButton("32", this.CreateVisibilityCondition(2)),
            new ConditionalButton("33", this.CreateVisibilityCondition(3)),
            new ConditionalButton("35", this.CreateVisibilityCondition(5)),
            new ConditionalButton("37", this.CreateVisibilityCondition(7)),
            new ConditionalButton("39", this.CreateVisibilityCondition(9)),

            new ConditionalButton("42", this.CreateVisibilityCondition(2)),
            new ConditionalButton("43", this.CreateVisibilityCondition(3)),
            new ConditionalButton("45", this.CreateVisibilityCondition(5)),
            new ConditionalButton("47", this.CreateVisibilityCondition(7)),
            new ConditionalButton("49", this.CreateVisibilityCondition(9)),

            new ConditionalButton("52", this.CreateVisibilityCondition(2)),
            new ConditionalButton("53", this.CreateVisibilityCondition(3)),
            new ConditionalButton("55", this.CreateVisibilityCondition(5)),
            new ConditionalButton("57", this.CreateVisibilityCondition(7)),
            new ConditionalButton("59", this.CreateVisibilityCondition(9)),
        };

        return buttons;
    }
}


public partial class Form1 : Form
{
    private readonly FlowLayoutPanel buttonPanel = new FlowLayoutPanel
    {
        Dock = DockStyle.Fill,
        FlowDirection = FlowDirection.LeftToRight,
        WrapContents = true,
        Padding = new Padding(10),
        AutoScroll = true,
    };
    private readonly ConditionalButton[] buttons = new Form1Util().CreateButtons();

    public Form1()
    {
        InitializeComponent();
        this.Padding = new Padding(20, 50, 20, 20);
        this.Controls.Add(buttonPanel);
        foreach (ConditionalButton button in this.buttons)
        {
            this.buttonPanel.Controls.Add(button.Button);
        }

        this.countInput.ValueChanged += CountInput_ValueChanged;
    }

    private void CountInput_ValueChanged(object _sender, EventArgs _e)
    {
        int count = (int)countInput.Value;
        foreach (ConditionalButton button in buttons)
        {
            button.SetButtonVisible(count);
        }
    }
}
