using NUnit.Framework;

namespace GeoTagger.Models.Test
{
    class AddressTests
    {
        private Address sut;

        [SetUp]
        public void Setup()
        {
            sut = new Address()
            {
                Country = "Country",
                City = new GeoObject()
                {
                    Type = new GeoType() { Name = "CityType" },
                    Name = "City"
                },
                Street = new GeoObject()
                {
                    Type = new GeoType() { Name = "StreetType" },
                    Name = "Street"
                },
                House = new GeoObject()
                {
                    Type = new GeoType() { Name = "HouseType" },
                    Name = "House"
                }
            };
        }

        [Test]
        public void Model_Show_Street_And_House()
        {
            Assert.AreEqual("StreetType Street, HouseType House", sut.ToString());
        }

        [Test]
        public void Model_Show_Street_House_And_Block()
        {
            sut.Block = new GeoObject()
            {
                Type = new GeoType() { Name = "BlockType" },
                Name = "Block"
            };

            Assert.AreEqual("StreetType Street, HouseType House BlockType Block", sut.ToString());
        }

        [Test]
        public void Model_Show_Street_House_And_Room()
        {
            sut.Room = new GeoObject()
            {
                Type = new GeoType() { Name = "RoomType" },
                Name = "Room"
            };

            Assert.AreEqual("StreetType Street, HouseType House RoomType Room", sut.ToString());
        }

        [Test]
        public void Model_Show_Street_House_Block_And_Room()
        {
            sut.Room = new GeoObject()
            {
                Type = new GeoType() { Name = "RoomType" },
                Name = "Room"
            };
            sut.Block = new GeoObject()
            {
                Type = new GeoType() { Name = "BlockType" },
                Name = "Block"
            };

            Assert.AreEqual(
                "StreetType Street, HouseType House BlockType Block RoomType Room", 
                sut.ToString()
                );
        }
    }
}
