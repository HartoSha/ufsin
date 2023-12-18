using Microsoft.AspNetCore.Mvc;
using UFSIN.Controllers;
using UFSIN.Models;

namespace UFSIN.Tests.Controllers
{
    public class BalliffControllerTests
    {
        [Test]
        public void GetAll_ShouldReturnMockData_OnFirstCall()
        {
            // arrange
            var controller = new BailiffController();

            // act
            var baliffs = controller.GetAll();

            // assert
            Assert.That(baliffs.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfBallifs_OnCall()
        {
            // arrange
            var controller = new BailiffController();

            // act
            var baliffsCount = controller.GetAll().Count();
            controller.Post(new Bailiff());
            var updatedBallifsCount = controller.GetAll().Count();

            // assert
            Assert.That(updatedBallifsCount, Is.GreaterThan(baliffsCount));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfBallifsBy2_WhenCalledTwoTimes()
        {
            // arrange
            var controller = new BailiffController();

            // act
            var initialBallifsCount = controller.GetAll().Count();
            controller.Post(new Bailiff());
            controller.Post(new Bailiff());
            var updatedBallifsCount = controller.GetAll().Count();

            // assert
            var addedCount = updatedBallifsCount - initialBallifsCount;
            Assert.That(addedCount, Is.EqualTo(2));
        }

        [Test]
        public void Post_ShouldReturnStatusCode201_OnCorrectCall()
        {
            // arrange
            var controller = new BailiffController();

            // act
            var actionResult = controller.Post(new Bailiff());

            // assert
            Assert.That(actionResult is CreatedResult, Is.True);
        }
    }
}
