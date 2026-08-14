namespace src;


public class DataLabelTest
{
    [Theory]
    [InlineData(true, "0", 0)]
    [InlineData(false, "1", 1)]
    [InlineData(true, "2", 2)]
    public void DataLabelのUpdateはVisibleとDataを更新する(bool expectedVisible, string expectedValue, int count)
    {
        // Arrange
        var dataStore = new DataStore { Count = count };
        var label = new DataLabel("Test", num => num % 2 == 0, dataStore);

        // Act
        label.Update();

        // Assert
        Assert.Equal(expectedVisible, label.LabelPanel.Visible);
        Assert.Equal(expectedValue, label.LabelPanel.Controls[1].Text);

        // Clean up
        label.Dispose();
    }
}
