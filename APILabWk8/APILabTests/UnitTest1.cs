using System;
using Xunit;
using APILabWk8.Models;

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
    }
}
