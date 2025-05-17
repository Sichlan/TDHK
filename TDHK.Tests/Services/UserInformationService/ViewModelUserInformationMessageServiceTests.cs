using Moq;
using TDHK.Common.Services;
using TDHK.Common.Services.UserInformationService;
using TDHK.Common.ViewModels.Users;

namespace TDHK.Tests.Services.UserInformationService;

[TestFixture]
public class ViewModelUserInformationMessageServiceTests
{
    private CreateUserMessageViewModel _createUserMessageViewModel;
    private Mock<IDispatcherService> _mockDispatcherHelper;
    private ViewModelUserInformationMessageService _service;
    private ManualResetEvent _manualResetEvent;

    [SetUp]
    public void SetUp()
    {
        _manualResetEvent = new ManualResetEvent(false);

        // Mock DispatcherHelper behavior
        _mockDispatcherHelper = new Mock<IDispatcherService>();

        // Setup RunOnMainThread to invoke the action directly
        _mockDispatcherHelper.Setup(d => d.RunOnMainThread(It.IsAny<Action>()))
            .Callback<Action>(action =>
            {
                action();
                _manualResetEvent.Set();
            })
            .Verifiable();

        _createUserMessageViewModel = (message, type, after, details) => new UserMessageViewModel(message, type, after, details, _service);

        // Initialize the service
        _service = new ViewModelUserInformationMessageService(_createUserMessageViewModel, _mockDispatcherHelper.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _manualResetEvent.Dispose();
    }

    [TestCase(false)]
    [TestCase(true)]
    public void AddDisplayMessage_ShouldAddMessageToCollection(bool useTimeSpan)
    {
        // Arrange
        const string messageText = "Test Message";
        const InformationType type = InformationType.Information;
        const int deleteAfter = 1000;
        const string details = "Details";

        // Act
        if (useTimeSpan)
            _service.AddDisplayMessage(messageText, type, new TimeSpan(0,0,0,0,deleteAfter), details);
        else
            _service.AddDisplayMessage(messageText, type, deleteAfter, details);

        // Assert
        var wasCalled = _manualResetEvent.WaitOne(2000);
        Assert.Multiple(() =>
        {
            Assert.That(wasCalled, Is.EqualTo(true));
            Assert.That(_service.UserMessageViewModels, Has.Count.EqualTo(1));
        });
        var message = _service.UserMessageViewModels.First();
        Assert.Multiple(() =>
        {
            Assert.That(message.MessageHeader, Is.EqualTo(messageText));
            Assert.That(message.InformationType, Is.EqualTo(type));
            Assert.That(message.MessageContent, Is.EqualTo(details));
        });
    }

    // [Test]
    // public void RemoveDisplayMessage_ShouldRemoveMessageFromCollection()
    // {
    //     // Arrange
    //     var messageViewModel = new UserMessageViewModel();
    //     _service.UserMessageViewModels.Add(messageViewModel);
    //
    //     // Act
    //     _service.RemoveDisplayMessage(messageViewModel);
    //
    //     // Assert
    //     Assert.That(_service.UserMessageViewModels, Does.Not.Contain(messageViewModel));
    // }

    [Test]
    public async Task ExecuteUpdateTaskLoop_ShouldRemoveExpiredMessages()
    {
        // Arrange
        const int time = 100;
        _service.AddDisplayMessage("Test", InformationType.Information, time);

        // Act
        await Task.Delay(time * 4); // Let the task loop run once.

        // Assert
        Assert.That(_service.UserMessageViewModels, Has.Count.EqualTo(0));
    }

    // [Test]
    // public async Task ExecuteUpdateTaskLoop_ShouldAdvanceTimeForNonExpiredMessages()
    // {
    //     // Arrange
    //     var activeMessage = new Mock<UserMessageViewModel>();
    //     activeMessage.SetupGet(m => m.TimeRemaining).Returns(5000);
    //     activeMessage.SetupGet(m => m.IsPaused).Returns(false);
    //
    //     _service.UserMessageViewModels.Add(activeMessage.Object);
    //
    //     // Act
    //     await Task.Delay(150); // Let the task loop run once.
    //
    //     // Assert
    //     activeMessage.Verify(m => m.AdvanceTimeIfNotPaused(), Times.AtLeastOnce);
    // }
    //
    // [Test]
    // public void AddDisplayMessage_WithTimeSpan_ShouldCallOverloadedMethod()
    // {
    //     // Arrange
    //     var messageText = "Test";
    //     var type = InformationType.Information;
    //     var deleteAfter = TimeSpan.FromSeconds(1);
    //     var details = "Details";
    //
    //     var mockMessageViewModel = new UserMessageViewModel();
    //     _mockCreateUserMessageViewModel
    //         .Setup(f => f(messageText, type, 1000, details))
    //         .Returns(mockMessageViewModel);
    //
    //     // Act
    //     _service.AddDisplayMessage(messageText, type, deleteAfter, details);
    //
    //     // Assert
    //     Assert.That(_service.UserMessageViewModels, Contains.Item(mockMessageViewModel));
    // }
}