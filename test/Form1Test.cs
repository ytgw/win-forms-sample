namespace src;


public class Form1UtilTest
{
    [Fact]
    public void CreateButtonsは30個のボタンを返す()
    {
        // Arrange
        var util = new Form1Util();

        // Act
        var buttons = util.CreateButtons();

        // Assert
        Assert.Equal(30, buttons.Length);
    }

    [Fact]
    public void CreateButtonsのテキスト数字の下一桁を渡した場合に表示される()
    {
        // Arrange
        var util = new Form1Util();

        // Act
        var buttons = util.CreateButtons();

        // Assert
        foreach (var button in buttons)
        {
            if (button.Button.Text is "2" or "12" or "22" or "32" or "42" or "52")
            {
                Assert.True(button.ShouldBeVisible(2));
            }
            else if (button.Button.Text is "3" or "13" or "23" or "33" or "43" or "53")
            {
                Assert.True(button.ShouldBeVisible(3));
            }
            else if (button.Button.Text is "5" or "15" or "25" or "35" or "45" or "55")
            {
                Assert.True(button.ShouldBeVisible(5));
            }
            else if (button.Button.Text is "7" or "17" or "27" or "37" or "47" or "57")
            {
                Assert.True(button.ShouldBeVisible(7));
            }
            else if (button.Button.Text is "9" or "19" or "29" or "39" or "49" or "59")
            {
                Assert.True(button.ShouldBeVisible(9));
            }
            else
            {
                Assert.Fail("Unexpected button text: " + button.Button.Text);
            }
        }

        // Clean up
        foreach (var button in buttons)
        {
            button.Button.Dispose();
        }
    }
}
