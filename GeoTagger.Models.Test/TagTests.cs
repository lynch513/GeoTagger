using NUnit.Framework;

namespace GeoTagger.Models.Test
{
    class TagTests
    {
        [Test]
        public void Model_Show_Name()
        {
            var sut = new Tag() { Name = "Tag" };

            Assert.AreEqual("Tag", sut.ToString());
        }
    }
}
