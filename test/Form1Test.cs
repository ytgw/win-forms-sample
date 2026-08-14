using System;
using System.Linq;

namespace src;


public class Form1UtilTest
{
    [Fact]
    public void CreateButtonsは30個のボタンを返す()
    {
        // Act
        var buttons = new Form1Util().CreateButtons();

        // Assert
        Assert.Equal(30, buttons.Length);

        // Clean up
        foreach (var button in buttons)
        {
            button.Dispose();
        }
    }

    [Theory]
    [InlineData(new string[] { "2", "12", "22", "32", "42", "52" }, 2)]
    [InlineData(new string[] { "3", "13", "23", "33", "43", "53" }, 3)]
    [InlineData(new string[] { "5", "15", "25", "35", "45", "55" }, 5)]
    [InlineData(new string[] { "7", "17", "27", "37", "47", "57" }, 7)]
    [InlineData(new string[] { "9", "19", "29", "39", "49", "59" }, 9)]
    public void CreateButtonsのテキスト数字の下一桁で割り切れる場合に表示される(string[] buttonTexts, int num)
    {
        // Act
        ConditionalButton[] buttons = new Form1Util().CreateButtons();

        // Assert
        ConditionalButton[] visibleButtons = buttons.Where(b => buttonTexts.Contains(b.Button.Text)).ToArray();
        foreach (var button in visibleButtons)
        {
            Assert.True(button.ShouldBeVisible(num));
        }

        // Clean up
        foreach (var button in buttons)
        {
            button.Dispose();
        }
    }

    [Fact]
    public void CreateLabelsは5個のラベルを返す()
    {
        // Act
        var labels = new Form1Util().CreateLabels();

        // Assert
        Assert.Equal(5, labels.Length);

        // Clean up
        foreach (var label in labels)
        {
            label.Dispose();
        }
    }

    [Fact]
    public void CreateLabelsのテキストと非表示条件は関係している()
    {
        // Act
        DataLabel[] labels = new Form1Util().CreateLabels();

        // Assert
        foreach (var label in labels)
        {
            if (label.LabelPanel.Controls[0].Text == "Label2") { Assert.True(label.ShouldBeVisible(2)); }
            else if (label.LabelPanel.Controls[0].Text == "Label3") { Assert.True(label.ShouldBeVisible(3)); }
            else if (label.LabelPanel.Controls[0].Text == "Label5") { Assert.True(label.ShouldBeVisible(5)); }
            else if (label.LabelPanel.Controls[0].Text == "Label7") { Assert.True(label.ShouldBeVisible(7)); }
            else if (label.LabelPanel.Controls[0].Text == "Label9") { Assert.True(label.ShouldBeVisible(9)); }
            else { Assert.Fail($"Unexpected label text: {label.LabelPanel.Controls[0].Text}"); }
        }

        // Clean up
        foreach (var label in labels)
        {
            label.Dispose();
        }
    }
}
