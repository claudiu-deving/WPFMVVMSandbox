using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Infrastructure.ExceptionHandling.Tests;

[TestClass()]
public class AppExceptionBuilderTests
{
    [TestMethod()]
    public void WithMessageTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = "Test Message";

        // Act
        var actual = appExceptionBuilder.WithMessage(expected).Build().Message;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void WithDisplayMessageTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = "Test Display Message";

        // Act
        var actual = appExceptionBuilder.WithDisplayMessage(expected).Build().DisplayMessage;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void WithSeverityTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = ExceptionSeverity.ERROR;

        // Act
        var actual = appExceptionBuilder.WithSeverity(expected).Build().Severity;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void AsNonVisibleTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = ExceptionVisibility.NOT_SHOWN_TO_USER;

        // Act
        var actual = appExceptionBuilder.AsNonVisible().Build().IsShownToUser;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void AsRecoverableTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = ExceptionType.RECOVERABLE;

        // Act
        var actual = appExceptionBuilder.AsRecoverable().Build().IsRecoverable;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void WithInnerExceptionTest()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = new Exception("Test Inner Exception");

        // Act
        var actual = appExceptionBuilder.WithInnerException(expected).Build().InnerException;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod()]
    public void ReturnsExceptionWithMessageAsTheInnerExceptionMessage()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var exception = new Exception("Test Inner Exception");
        var expected = new AppException(
            "Test Message",
            "Test Display Message",
            ExceptionType.RECOVERABLE,
            ExceptionVisibility.SHOWN_TO_USER,
            ExceptionSeverity.ERROR,
            exception);

        // Act
        var actual = appExceptionBuilder
                    .WithMessage("Test Message")
                    .WithDisplayMessage("Test Display Message")
                    .WithSeverity(ExceptionSeverity.ERROR)
                    .AsRecoverable()
                    .WithInnerException(exception).Build();

        // Assert
        Assert.AreEqual(expected.InnerException.Message, actual.Message);
        Assert.AreEqual(expected.DisplayMessage, actual.DisplayMessage);
        Assert.AreEqual(expected.IsRecoverable, actual.IsRecoverable);
        Assert.AreEqual(expected.IsShownToUser, actual.IsShownToUser);
        Assert.AreEqual(expected.Severity, actual.Severity);
        Assert.AreEqual(expected.InnerException, actual.InnerException);
    }

    [TestMethod()]
    public void ReturnsExceptionWithMessageAsTheInnerExceptionMessageAndEmptyDisplayMessage()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var exception = new Exception("Test Inner Exception");
        var expected = new AppException(
                           "Test Message",
                            string.Empty,
                            ExceptionType.RECOVERABLE,
                            ExceptionVisibility.NOT_SHOWN_TO_USER,
                            ExceptionSeverity.ERROR,
                            exception);

        // Act
        var actual = appExceptionBuilder
            .WithMessage("Test Message")
            .WithSeverity(ExceptionSeverity.ERROR)
            .AsRecoverable()
            .AsNonVisible()
            .WithInnerException(exception)
            .Build();

        // Assert
        Assert.AreEqual(expected.InnerException.Message, actual.Message);
        Assert.AreEqual(expected.DisplayMessage, actual.DisplayMessage);
        Assert.AreEqual(expected.IsRecoverable, actual.IsRecoverable);
        Assert.AreEqual(expected.IsShownToUser, actual.IsShownToUser);
        Assert.AreEqual(expected.Severity, actual.Severity);
        Assert.AreEqual(expected.InnerException, actual.InnerException);
    }

    [TestMethod()]
    public void ReturnsExceptionWithSetMessageWhenSetAfterInnerException()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var exception = new Exception("Test Inner Exception");
        var expected = new AppException("Test Message",
                                        string.Empty,
                                        ExceptionType.RECOVERABLE,
                                        ExceptionVisibility.NOT_SHOWN_TO_USER,
                                        ExceptionSeverity.ERROR,
                                        exception);

        // Act
        var actual = appExceptionBuilder
            .WithSeverity(ExceptionSeverity.ERROR)
            .AsRecoverable()
            .AsNonVisible()
            .WithInnerException(exception)
            .WithMessage("Test Message")
            .Build();

        // Assert
        Assert.AreEqual(expected.Message, actual.Message);
        Assert.AreEqual(expected.DisplayMessage, actual.DisplayMessage);
        Assert.AreEqual(expected.IsRecoverable, actual.IsRecoverable);
        Assert.AreEqual(expected.IsShownToUser, actual.IsShownToUser);
        Assert.AreEqual(expected.Severity, actual.Severity);
        Assert.AreEqual(expected.InnerException, actual.InnerException);
    }


    [TestMethod()]
    public void ReturnsTheDefaultVisibleNonRecoverableWarningException()
    {
        // Arrange
        var appExceptionBuilder = new AppExceptionBuilder();
        var expected = new AppException(string.Empty,
                                        string.Empty,
                                        ExceptionType.UNRECOVERABLE,
                                        ExceptionVisibility.SHOWN_TO_USER,
                                        ExceptionSeverity.WARNING,
                                        null);

        // Act
        var actual = appExceptionBuilder.Build();

        // Assert
        Assert.AreEqual(expected.Message, actual.Message);
        Assert.AreEqual(expected.DisplayMessage, actual.DisplayMessage);
        Assert.AreEqual(expected.IsRecoverable, actual.IsRecoverable);
        Assert.AreEqual(expected.IsShownToUser, actual.IsShownToUser);
        Assert.AreEqual(expected.Severity, actual.Severity);
        Assert.AreEqual(expected.InnerException, actual.InnerException);
    }
}