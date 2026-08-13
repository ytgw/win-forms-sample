namespace src;


public class ConditionalButton
{
    public readonly Button Button;
    public readonly Func<int, bool> ShouldBeVisible;

    private int count = 0;
    private readonly string text;

    public ConditionalButton(string text, Func<int, bool> shouldBeVisible)
    {
        this.text = text;
        this.Button = new Button{Text = text, Size = new Size(100, 40), Margin = new Padding(5)};
        this.ShouldBeVisible = shouldBeVisible;
        this.Button.Click += this.Button_Click;
    }

    private void Button_Click(object? _sender, EventArgs _e)
    {
        this.count++;
        this.Button.Text = $"{this.text}-{this.count}";
    }

    public void SetButtonVisible(int num)
    {
        this.Button.Visible = this.ShouldBeVisible(num);
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
    private readonly ConditionalButton[] buttons = {
        new ConditionalButton("2", (int num) => num % 2 == 0),
        new ConditionalButton("3", (int num) => num % 3 == 0),
        new ConditionalButton("5", (int num) => num % 5 == 0),
        new ConditionalButton("7", (int num) => num % 7 == 0),
        new ConditionalButton("9", (int num) => num % 9 == 0),

        new ConditionalButton("12", (int num) => num % 2 == 0),
        new ConditionalButton("13", (int num) => num % 3 == 0),
        new ConditionalButton("15", (int num) => num % 5 == 0),
        new ConditionalButton("17", (int num) => num % 7 == 0),
        new ConditionalButton("19", (int num) => num % 9 == 0),

        new ConditionalButton("22", (int num) => num % 2 == 0),
        new ConditionalButton("23", (int num) => num % 3 == 0),
        new ConditionalButton("25", (int num) => num % 5 == 0),
        new ConditionalButton("27", (int num) => num % 7 == 0),
        new ConditionalButton("29", (int num) => num % 9 == 0),

        new ConditionalButton("32", (int num) => num % 2 == 0),
        new ConditionalButton("33", (int num) => num % 3 == 0),
        new ConditionalButton("35", (int num) => num % 5 == 0),
        new ConditionalButton("37", (int num) => num % 7 == 0),
        new ConditionalButton("39", (int num) => num % 9 == 0),

        new ConditionalButton("42", (int num) => num % 2 == 0),
        new ConditionalButton("43", (int num) => num % 3 == 0),
        new ConditionalButton("45", (int num) => num % 5 == 0),
        new ConditionalButton("47", (int num) => num % 7 == 0),
        new ConditionalButton("49", (int num) => num % 9 == 0),

        new ConditionalButton("52", (int num) => num % 2 == 0),
        new ConditionalButton("53", (int num) => num % 3 == 0),
        new ConditionalButton("55", (int num) => num % 5 == 0),
        new ConditionalButton("57", (int num) => num % 7 == 0),
        new ConditionalButton("59", (int num) => num % 9 == 0),
    };

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

    private void CountInput_ValueChanged(object? _sender, EventArgs _e)
    {
        int count = (int)countInput.Value;
        foreach (ConditionalButton button in buttons)
        {
            button.SetButtonVisible(count);
        }
    }
}
