using PacketAndPrice.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPriceTests
{
    public class PackageTests
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 2, 1)]
        public void ShouldReturnLowestNumber_When_DifferentNumbers(int length, int width, int height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            int expected = 1;

            //Act
            int actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 2, 1)]
        public void Should_ReturnLowestNumber_When_TwoNumbersAreSame(int length, int width, int height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            int expected = 1;

            //Act
            int actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnLowestNumber_When_AllNumbersAreSame()
        {
            //Arrange
            var sut = new Package(1, 15, 1, 1);
            int expected = 1;

            //Act
            int actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);


            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 2, 1)]
        public void ShouldReturnHighestNumber_When_DifferentNumbers(int length, int width, int height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            int expected = 3;

            //Act
            int actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 2, 1)]
        public void Should_ReturnHighestNumber_When_TwoNumbersAreSame(int length, int width, int height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            int expected = 2;

            //Act
            int actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnHighestNumber_When_AllNumbersAreSame()
        {
            //Arrange
            var sut = new Package(1, 15, 1, 1);
            int expected = 1;

            //Act
            int actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);


            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
