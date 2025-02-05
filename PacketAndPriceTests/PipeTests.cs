﻿using PacketAndPrice.models;
using PacketAndPriceTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPriceTests
{
    public class PipeTests : IClassFixture<PipeFixture>
    {
        private Pipe _sut;
        public PipeTests(PipeFixture pipefixture)
        {
            _sut = pipefixture.pipe;
        }

        [Fact]
        public void Should_ReturnCorrectVolume_When_Used()
        {
            //Arrange
            double expected = 2.25 * Math.PI;

            //Act
            double actual = _sut.CalculateVolume();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(PipeTestData))]
        public void Should_ReturnCorrectPrice_RegardlessOfWeight(double a, double b, double c)
        {
            //Arrange
            var sut = new Pipe(a, b, c);
            decimal expected = Convert.ToDecimal(6 * Math.PI);

            //Act
            decimal actual = _sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnCorrectPrice_When_UsingDecimals()
        {
            //Arrange
            _sut = new Pipe(1.5d, 2.3d, 3.4);
            decimal expected = Convert.ToDecimal(11.73 * Math.PI);

            //Act
            decimal actual = _sut.CalculatePrice();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_ReturnTrue_When_CreatingPipe()
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = Pipe.CreatePipe(1, 1, 1);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_ReturnFalse_When_OneValueIsZeroOrLess(double length, double weight, double diameter)
        {
            //Arrange

            //Act
            bool actual = Pipe.CreatePipe(length, weight, diameter);

            //Assert
            Assert.False(actual);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {-1, 1, 1 },
            new object[] {1, -1, 1 },
            new object[] {1, 1, -1 } 
        };                          
    }                               
}                                   
