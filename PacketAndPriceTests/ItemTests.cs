using PacketAndPrice.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPriceTests
{
    public class ItemTests
    {
        [Fact]
        public void ReturnFalseIfOverMaxWeight()
        {
            //Arrange
            var sut = new Item(1, 21);
            bool expected = false;

            //Act
            bool actual = sut.CheckWeight();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
