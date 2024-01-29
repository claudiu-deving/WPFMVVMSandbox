using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Infrastructure.ExceptionHandling.Tests;


public class TestFilesProvider : ITestFilesProvider
{
    public void AddFile(string name, string content)
    {
        File.WriteAllText(name, content);
    }

    public void DeleteFile(string name)
    {
        File.Delete(name);
    }

    public bool FileExists(string name)
    {
        return File.Exists(name);
    }

    public string ReadFile(string name)
    {
        return File.ReadAllText(name);
    }
}


[TestClass()]
public class ExceptionHandlerProviderTests
{
    private TestFilesProvider _testFileProvider;
    private TestMessageNotificationProvider _infoPopupProvider;
    private TestApplicationLogger _testAppLogger;

    [TestInitialize]
    public void Setup()
    {
        _testFileProvider = new TestFilesProvider();
        _infoPopupProvider = new TestMessageNotificationProvider(_testFileProvider);
        _testAppLogger = new TestApplicationLogger();
    }

    [TestMethod()]
    public void ReturnsUnexpectedErrorForNonAppException()
    {
        //Arrange
        var exceptionHandler = new ExceptionHandlerProvider()
            .HasMessageNotificationProvider(_infoPopupProvider)
            .Build();
        Exception testException = new("Test Exception");

        //Act
        exceptionHandler.Handle(testException);
        var fileContent = _testFileProvider.ReadFile("test");

        //Assert
        Assert.IsTrue(fileContent.StartsWith("An unexpected error occurred"));
    }

    [TestMethod()]
    public void ReturnsAppExceptionMessageForAppException()
    {
        //Arrange
        var displayMessage = "This is an exception test";
        var exceptionHandler = new ExceptionHandlerProvider()
            .HasMessageNotificationProvider(_infoPopupProvider)
            .Build();
        Exception testException = new AppExceptionBuilder()
            .WithMessage("Test Exception")
            .WithDisplayMessage(displayMessage)
            .Build();

        //Act
        exceptionHandler.Handle(testException);
        var fileContent = _testFileProvider.ReadFile("warning");

        //Assert
        Assert.IsTrue(fileContent.StartsWith(displayMessage));
    }

    [TestCleanup]
    public void Cleanup()
    {
        _testFileProvider.DeleteFile("test");
    }
}

public class TestMessageNotificationProvider(ITestFilesProvider testFilesProvider) : IMessageNotificationProvider
{
    private readonly ITestFilesProvider _testFilesProvider = testFilesProvider;

    public void ShowError(string message)
    {
        _testFilesProvider.AddFile("test", message);
    }

    public void ShowInformation(string message)
    {
        throw new NotImplementedException();
    }

    public void ShowWarning(string message)
    {
        _testFilesProvider.AddFile("warning", message);
    }
}

public class TestApplicationLogger : IApplicationLogger
{
    public void Error(Exception exception)
    {
        throw new NotImplementedException();
    }

    public void Information(Exception message)
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }

    public void Warning(Exception message)
    {
        throw new NotImplementedException();
    }
}