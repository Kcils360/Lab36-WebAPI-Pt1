using System;
using Xunit;
using APILabWk8.Models;
using APILabWk8.Controllers;

namespace APILabTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanChangeConfirm()
        {
            //arrange
            var test = new GuestInvites
            {
                Name = "test",
                Confirmed = false
            };

            //act
            test.Confirmed = true;

            //assert
            Assert.Equal(true, test.Confirmed);

        }

        [Fact]
        public void NameIsString()
        {
            //arrange
            var test2 = new GuestInvites
            {
                Name = "test2",
                Confirmed = false
            };

            //act
            var val = test2.Name;

            //assert
            Assert.Equal("test2", val);

        }

        [Fact]
        public void CanChangeName()
        {
            //arrange
            var test3 = new GuestInvites
            {
                Name = "test3",
                Confirmed = true
            };

            //act
            test3.Name = "changed";

            //assert
            Assert.Equal("changed", test3.Name);
        }
    }
}
