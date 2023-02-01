using Microsoft.AspNetCore.Mvc;

namespace LMS.UnitTest.Systems.Controllers
{
    [TestFixture]
    public class TestAuthorController
    {
        private Mock<IAuthorService> _service;
        private AuthorController _sut;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IAuthorService>();

            _sut = new AuthorController(_service.Object);
        }

        [Test]
        public async Task Get_OnSuccess_CallGetAsyncMethod()
        {
            // Arrange
            _service
                .Setup(s => s.GetAsync())
                .ReturnsAsync(AuthorFixture.GetListOfAuthors());

            // Act
            var result = await _sut.GetAll();

            // Assert
            _service
                .Verify(
                    service => service.GetAsync(),
                    Times.Once()
                );
        }

        [Test]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            _service
                .Setup(s => s.GetAsync())
                .ReturnsAsync(AuthorFixture.GetListOfAuthors());

            // Act
            var result = (OkObjectResult)await _sut.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Add_WhenCalled_CallAddAsyncMethod()
        {
            // Arrange
            _service
                .Setup(s => s.AddAsync(It.IsAny<AddAuthorViewModel>()))
                .ReturnsAsync(AuthorFixture.Add());

            // Act
            var result = await _sut.Add(It.IsAny<AddAuthorViewModel>());

            // Assert
            _service
                .Verify(
                    service => service.AddAsync(It.IsAny<AddAuthorViewModel>()),
                    Times.Once()
                );
        }

        [Test]
        public async Task Add_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            _service
                .Setup(s => s.AddAsync(It.IsAny<AddAuthorViewModel>()))
                .ReturnsAsync(AuthorFixture.Add());

            // Act
            var result = (OkObjectResult)await _sut.Add(It.IsAny<AddAuthorViewModel>());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public void Add_ModelStateInvalid_ReturnStatusCode400()
        {
            _sut.ModelState.AddModelError("Model State", "Bad request");
        }
    }
}
