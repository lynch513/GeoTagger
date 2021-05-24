using NUnit.Framework;

namespace GeoTagger.Models.Test
{
    public class GeoTypeTests
    {
        [Test]
        public void Model_With_Name_Show_Only_Name()
        {
            var sut = new GeoType() { Name = "Name" };
            Assert.AreEqual("Name", sut.ToString());
        }

        [Test]
        public void Model_With_Reduction_Show_Only_Reduction()
        {
            var sut = new GeoType() { Name = "Name", Reduction = "Reduction" };
            Assert.AreEqual("Reduction", sut.ToString());
        }
    }
}