using PacketAndPrice.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPriceTests
{
    public class PackageTests
    {
        [Theory]
        [InlineData(1F, 2F, 3F)]
        [InlineData(2F, 1F, 3F)]
        [InlineData(3F, 2F, 1F)]
        public void ShouldReturnLowestNumber_When_DifferentNumbers(double length, double width, double height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            double expected = 1;

            //Act
            double actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 2, 1)]
        public void Should_ReturnLowestNumber_When_TwoNumbersAreSame(double length, double width, double height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            double expected = 1;

            //Act
            double actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnLowestNumber_When_AllNumbersAreSame()
        {
            //Arrange
            var sut = new Package(1, 15, 1, 1);
            double expected = 1;

            //Act
            double actual = sut.ShortestSide(sut.Length, sut.Width, sut.Height);


            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 2, 1)]
        public void ShouldReturnHighestNumber_When_DifferentNumbers(double length, double width, double height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            double expected = 3;

            //Act
            double actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 2, 1)]
        public void Should_ReturnHighestNumber_When_TwoNumbersAreSame(double length, double width, double height)
        {
            //Arrange
            var sut = new Package(length, 15, width, height);
            double expected = 2;

            //Act
            double actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnHighestNumber_When_AllNumbersAreSame()
        {
            //Arrange
            var sut = new Package(1, 15, 1, 1);
            double expected = 1;

            //Act
            double actual = sut.LongestSide(sut.Length, sut.Width, sut.Height);


            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_CalculateCorrectPackagePrice_When_PackageIsCreated()
        {
            //Arrange
            var sut = new Package(1, 15, 1, 1);
            decimal expected = 115;

            //Act
            decimal actual = sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 0.1F, 1)]
        [InlineData(0.1F, 1, 1)]
        [InlineData(1, 1, 0.1F)]
        public void Should_CalculcateCorrectPackagePrice_When_UsingNumbersBelowOne(double a, double b, double c)
        {
            //Arrange
            var sut = new Package(a, 15, b, c);
            decimal expected = 101.5M;

            //Act
            decimal actual = Math.Round(sut.CalculatePrice(), 1); //added rounding up in order to not miss 0.000000002 and then crash.

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_UseSpecialPrice_When_WithinValuesForLengthAndBelowTwoKG()
        {
            //Arrange
            var sut = new Package(0.29F, 1, 0.29F, 0.29F);
            decimal expected = 29;

            //Act
            decimal actual = sut.CalculatePrice();

            //Assert    
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9.9)]
        [InlineData(9)]
        [InlineData(2.1)]
        public void Should_UseSpecialPrice_When_WithinValuesForLengthAndBelowTenKG(double weight)
        {
            //Arrange
            var sut = new Package(0.29F, weight, 0.29F, 0.29F);
            decimal expected = 49;

            //Act
            decimal actual = sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10.1)]
        [InlineData(19.1)]
        [InlineData(11)]
        [InlineData(20)]
        public void Should_UseSpecialPrice_When_WithinValuesForLengthAndBelowTwentyKG(double weight)
        {
            //Arrange
            var sut = new Package(0.29F, weight, 0.29F, 0.29F);
            decimal expected = 79;

            //Act
            decimal actual = sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnZero_When_NumberIsNegative()
        {
            //Arrange
            var sut = new Package(-1, 1, 1, 1);
            decimal expected = 0;

            //Act
            decimal actual = sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnCorrectVolume_When_used()
        {
            //Arrange
            var sut = new Package(1, 1, 1, 1);
            double expected = 1;

            //Act
            double actual = sut.CalculateVolume();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnZero_When_Negative()
        {
            //Arrange
            var sut = new Package(1, 1, 1, -1);
            double expected = 0;

            //Act
            double actual = sut.CalculateVolume();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 10, 1.5F)]
        [InlineData(1.5F, 5, 10)]
        [InlineData(10, 1.5F, 5)]
        public void Should_ReturnCorrectVolume_When_UsingDecimals(double a, double b, double c)
        {
            //Arrange
            var sut = new Package(a, 1, b, c);
            double expected = 75;

            //Act
            double actual = sut.CalculateVolume();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnTrue_When_CreatingPackage()
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = Package.CreatePackage(1, 1, 1, 1);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 1, 0)]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 0 , 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(-1, 1, 1, 1)]
        [InlineData(1, -1, 1, 1)]
        [InlineData(1, 1, -1, 1)]
        [InlineData(1, 1, 1, -1)]
        public void Should_ReturnFalse_When_ANumberIsZeroOrBelow(double length, double weight, double width, double height)
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = Package.CreatePackage(length, weight, width, height);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
