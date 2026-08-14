using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace test;


public class WinAppDriverFixture : IDisposable
{
    private const string WinAppDriverUrl = "http://127.0.0.1:4723";
    public WindowsDriver<WindowsElement> Driver { get; }

    public WinAppDriverFixture()
    {
        // 相対パスで exe を特定（ローカル / CI 環境の両方でそのまま動く構造）
        string appPath = Path.GetFullPath(Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\..\app\bin\Debug\net10.0-windows\win-x64\app.exe"
        ));

        if (!File.Exists(appPath))
        {
            throw new FileNotFoundException($"Not found: {appPath}");
        }

        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", appPath);
        options.AddAdditionalCapability("deviceName", "WindowsPC");

        try
        {
            Driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        catch (OpenQA.Selenium.WebDriverException ex)
        {
            throw new InvalidOperationException("Please ensure WinAppDriver is running before executing tests.", ex);
        }
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}
