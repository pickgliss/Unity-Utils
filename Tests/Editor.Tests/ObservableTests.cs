using NUnit.Framework;

public class ObservableTests
{
    [Test]
    public void Observable_create_test()
    {
        // Arrange
        var observable = new Observable<int>(0);
        var expectedValue = 5;
        var actualValue = 0;
        observable.ValueChanged += value => actualValue = value;
        
        // Act
        observable.Value = expectedValue;
        
        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }
}