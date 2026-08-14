using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace test;


public class EndToEndTest : IClassFixture<WinAppDriverFixture>
{
    // テスト実行前にWinAppDriverを以下のコマンドで実行する必要がある。
    //  & "C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"

    private readonly WinAppDriverFixture _fixture;

    public EndToEndTest(WinAppDriverFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void サンプルのE2Eテスト()
    {
        WindowsDriver<WindowsElement> driver = _fixture.Driver;

        try
        {
            // Act
            var countInput = driver.FindElementByAccessibilityId("countInput");
            // Clear + SendKeysだと、クリア後の0と送信した5で50になるので、Ctrl+A + Backspaceでクリアする
            countInput.SendKeys(Keys.Control + "a");
            countInput.SendKeys(Keys.Backspace);
            countInput.SendKeys("5");
            countInput.SendKeys(Keys.Tab);  // 確定

            // Assert
            // 5 のボタンとラベルが表示されることを確認
            Assert.True(driver.FindElementByAccessibilityId("ConditionalButton_5").Displayed);
            Assert.True(driver.FindElementByAccessibilityId("DataLabelNameLabel_Label5").Displayed);

            // 2 のボタンとラベルが非表示であることを確認
            Assert.Throws<OpenQA.Selenium.WebDriverException>(() => driver.FindElementByAccessibilityId("ConditionalButton_2"));
            Assert.Throws<OpenQA.Selenium.WebDriverException>(() => driver.FindElementByAccessibilityId("DataLabelNameLabel_Label2"));

            // ラベルの値が 5 であることを確認
            Assert.Equal("5", driver.FindElementByAccessibilityId("DataLabelValueLabel_Label5").Text);
        }
        catch (Exception)
        {
            // 失敗時にキャプチャを撮影
            var screenshot = driver.GetScreenshot();
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            Directory.CreateDirectory(dir);
            screenshot.SaveAsFile(Path.Combine(dir, "Failure_NavigationTest.png"));
            throw;
        }
    }
}
