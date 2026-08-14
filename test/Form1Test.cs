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
}
