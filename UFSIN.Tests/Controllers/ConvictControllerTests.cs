using Microsoft.AspNetCore.Mvc;
using UFSIN.Controllers;
using UFSIN.Models;

namespace UFSIN.Tests.Controllers
{
    public class ConvictControllerTests
    {
        [Test]
        public void GetAll_ShouldNotReturnMockData_OnFirstCall()
        {
            // arrange
            var controller = new ConvictController();

            // act
            var items = controller.GetAll();

            // assert
            Assert.That(items.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfConvicts_OnCall()
        {
            // arrange
            var controller = new ConvictController();

            // act
            var convictsCount = controller.GetAll().Count();
            controller.Post(new Convict());
            var updatedConvictsCount = controller.GetAll().Count();

            // assert
            Assert.That(updatedConvictsCount, Is.GreaterThan(convictsCount));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfConvictsBy2_WhenCalledTwoTimes()
        {
            // arrange
            var controller = new ConvictController();

            // act
            var initialConvictsCount = controller.GetAll().Count();
            controller.Post(new Convict());
            controller.Post(new Convict());
            var updatedConvictsCount = controller.GetAll().Count();

            // assert
            var addedCount = updatedConvictsCount - initialConvictsCount;
            Assert.That(addedCount, Is.EqualTo(2));
        }

        [Test]
        public void Post_ShouldReturnStatusCode201_OnCorrectCall()
        {
            // arrange
            var controller = new ConvictController();

            // act
            var actionResult = controller.Post(new Convict());

            // assert
            Assert.That(actionResult is CreatedResult, Is.True);
        }
    }
}
