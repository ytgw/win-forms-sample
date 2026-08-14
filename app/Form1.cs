using System;
using System.Drawing;
using System.Windows.Forms;

namespace src;


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
    // ヘッダーパネル（0-50px）
    private readonly Panel headerPanel = new Panel
    {
        Dock = DockStyle.Top,
        Height = 50,
    };

    // ボディパネル（50px以下）
    private readonly Panel bodyPanel = new Panel
    {
        Dock = DockStyle.Fill,
    };

    // SplitContainer（ボディパネル内）
    private readonly SplitContainer splitContainer = new SplitContainer
    {
        Dock = DockStyle.Fill,
        Orientation = Orientation.Vertical,
        IsSplitterFixed = true,
    };

    // buttonPanel（左半分）
    private readonly FlowLayoutPanel buttonPanel = new FlowLayoutPanel
    {
        Dock = DockStyle.Fill,
        FlowDirection = FlowDirection.LeftToRight,
        WrapContents = true,
        Padding = new Padding(10),
        AutoScroll = true,
    };

    // 右半分パネル（今後の拡張用）
    private readonly Panel rightPanel = new Panel
    {
        Dock = DockStyle.Fill,
        BackColor = Color.LightGray,
    };

    private readonly ConditionalButton[] buttons = new Form1Util().CreateButtons();

    public Form1()
    {
        InitializeComponent();

        // ヘッダーパネルにコントロール追加
        headerPanel.Controls.Add(countLabel);
        headerPanel.Controls.Add(countInput);

        // ボディパネルに SplitContainer を追加
        bodyPanel.Controls.Add(splitContainer);

        // SplitContainer のパネルに追加
        splitContainer.Panel1.Controls.Add(buttonPanel);
        splitContainer.Panel2.Controls.Add(rightPanel);

        // フォームにコントロール追加
        this.Controls.Add(headerPanel);
        this.Controls.Add(bodyPanel);

        // buttonPanel にボタン追加
        foreach (ConditionalButton button in this.buttons)
        {
            this.buttonPanel.Controls.Add(button.Button);
        }

        // イベントハンドラ
        this.countInput.ValueChanged += CountInput_ValueChanged;
        this.Resize += Form1_Resize;
        this.Load += Form1_Resize;
    }

    private void Form1_Resize(object _sender, EventArgs _e)
    {
        // 左右を半分に分割
        splitContainer.SplitterDistance = this.splitContainer.ClientSize.Width / 2;
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
