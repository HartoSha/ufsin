using System.Collections.Concurrent;
using UFSIN.Models;

namespace UFSIN.Tests.Models
{
    public class ConvictTests
    {
        [Test]
        public void Convict_ShouldHavePictureSet_ByDefault()
        {
            // arrange 
            var convict = new Convict();

            // act
            // assert
            Assert.That(convict.Photo, Is.EqualTo("user_picture.png"));
        }


        [Test]
        public void Convict_ShouldNotHaveFullNameSet_ByDefault()
        {
            // arrange 
            var convict = new Convict();

            // act
            // assert
            Assert.That(convict.FullName, Is.Empty);
        }

        [Test]
        public async Task Convict_ShouldGetUniqueId_ByDefault()
        {
            // arrange 
            var guids = new ConcurrentDictionary<Guid, int>();
            var convictsCount = 1_000_000;

            // act 
            var guidWasNotUnique = false;
            await Task.WhenAll(Enumerable.Range(0, convictsCount).Select(i => Task.Run(() =>
            {
                var convict = new Convict();
                if (!guids.TryAdd(convict.ID, 1))
                    guidWasNotUnique = true;
            })));

            // assert
            Assert.That(guidWasNotUnique, Is.False);
        }


        [Test]
        public void Convict_IdShouldBeGUID_ByDefault()
        {
            // arrange 
            var convict = new Convict();

            // act
            // assert
            Assert.That(convict.ID, Is.TypeOf<Guid>());
        }
    }
}
