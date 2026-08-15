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

    public DataLabel[] CreateLabels(DataStore dataStore)
    {
        DataLabel[] labels = {
            new DataLabel("Label2", this.CreateVisibilityCondition(2), dataStore),
            new DataLabel("Label3", this.CreateVisibilityCondition(3), dataStore),
            new DataLabel("Label5", this.CreateVisibilityCondition(5), dataStore),
            new DataLabel("Label7", this.CreateVisibilityCondition(7), dataStore),
            new DataLabel("Label9", this.CreateVisibilityCondition(9), dataStore),
        };

        return labels;
    }
}


public partial class Form1 : Form
{
    private readonly DataStore dataStore = new DataStore();
    private readonly ConditionalButton[] buttons = new Form1Util().CreateButtons();
    private readonly DataLabel[] labels;

    public Form1()
    {
        InitializeComponent();

        // leftPanel にボタン追加
        foreach (ConditionalButton button in this.buttons)
        {
            this.leftPanel.Controls.Add(button.Button);
        }

        // rightPanel にラベル追加
        labels = new Form1Util().CreateLabels(this.dataStore);
        foreach (DataLabel label in this.labels)
        {
            this.rightPanel.Controls.Add(label.LabelPanel);
        }

        // イベントハンドラ
        this.countInput.ValueChanged += CountInput_ValueChanged;
        this.Resize += Form1_Resize;
        this.Load += Form1_Resize;
    }

    private void Form1_Resize(object _sender, EventArgs _e)
    {
        // ヘッダーとボディの分割位置を設定
        this.headerBodySplitter.SplitterDistance = 10;
        // 左右を半分に分割
        this.bodySplitter.SplitterDistance = this.bodySplitter.ClientSize.Width / 2;
    }

    private void CountInput_ValueChanged(object _sender, EventArgs _e)
    {
        this.dataStore.Count = (int)countInput.Value;
        foreach (ConditionalButton button in buttons)
        {
            button.SetButtonVisible(this.dataStore.Count);
        }
        foreach (DataLabel label in labels)
        {
            label.Update();
        }
    }
}
