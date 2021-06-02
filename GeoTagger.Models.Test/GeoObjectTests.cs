using NUnit.Framework;

namespace GeoTagger.Models.Test
{
    class GeoObjectTests
    {
        [Test]
        public void Model_Show_Type_And_Name_If_Prefix_Is_True()
        {
            var sut = new GeoObject()
            {
                Type = new GeoType() { Name = "TypeName" },
                Name = "Name",
                Prefix = true
            };

            Assert.AreEqual("TypeName Name", sut.ToString());
        }

        [Test]
        public void Model_Show_Name_And_Type_If_Prefix_Is_False()
        {
            var sut = new GeoObject()
            {
                Type = new GeoType() { Name = "TypeName" },
                Name = "Name",
                Prefix = false
            };

            Assert.AreEqual("Name TypeName", sut.ToString());
        }

        [Test]
        public void Model_Has_Default_Prefix()
        {
            var sut = new GeoObject()
            {
                Type = new GeoType() { Name = "TypeName" },
                Name = "Name"
            };

            Assert.IsTrue(sut.Prefix);
        }

        [Test]
        public void Model_Show_Type_And_Name_With_Dot_If_Has_Type_Reduction()
        {
            var sut = new GeoObject()
            {
                Type = new GeoType() { 
                    Name = "TypeName",
                    Reduction = "TN"
                },
                Name = "Name",
                Prefix = true
            };

            Assert.AreEqual("TN.Name", sut.ToString());

            sut.Prefix = false;
            Assert.AreEqual("TN.Name", sut.ToString());
        }

    }
}
