using Microsoft.AspNetCore.Mvc;
using UFSIN.Controllers;
using UFSIN.Models;

namespace UFSIN.Tests.Controllers
{
    public class ViolationControllerTests
    {
        [Test]
        public void GetAll_ShouldNotReturnMockData_OnFirstCall()
        {
            // arrange
            var controller = new ViolationController();

            // act
            var items = controller.GetAll();

            // assert
            Assert.That(items.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfViolations_OnCall()
        {
            // arrange
            var controller = new ViolationController();

            // act
            var violationsCount = controller.GetAll().Count();
            controller.Post(new Violation());
            var updatedViolationsCount = controller.GetAll().Count();

            // assert
            Assert.That(updatedViolationsCount, Is.GreaterThan(violationsCount));
        }

        [Test]
        public void Post_ShouldIncreaseCountOfConvictsBy2_WhenCalledTwoTimes()
        {
            // arrange
            var controller = new ViolationController();

            // act
            var initialViolationsCount = controller.GetAll().Count();
            controller.Post(new Violation());
            controller.Post(new Violation());
            var updatedViolationsCount = controller.GetAll().Count();

            // assert
            var addedCount = updatedViolationsCount - initialViolationsCount;
            Assert.That(addedCount, Is.EqualTo(2));
        }

        [Test]
        public void Post_ShouldReturnStatusCode201_OnCorrectCall()
        {
            // arrange
            var controller = new ViolationController();

            // act
            var actionResult = controller.Post(new Violation());

            // assert
            Assert.That(actionResult is CreatedResult, Is.True);
        }
    }
}
