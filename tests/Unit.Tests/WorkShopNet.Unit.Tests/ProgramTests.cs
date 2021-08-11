using System;
using Xunit;
using WorkShopNet.App;
using System.Collections.Generic;

namespace WorkShopNet.Unit.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test1()
        {
            int a = 10;
            int b = 20;
            int c = a +b;

            Assert.Equal(c, 30);
        }
        
        [Fact]
        public void Validator_ValidateStringIf_initial_Capital_Letter_Fail()
        {
            // Arrange 
            string bad_string = "absdasdasd";
            // Act
            List<string> errors = Validator.ValidateStringIf(bad_string);
            // Assert
            Assert.Contains("Should starts with a capital letter",errors);
        }        
        
        [Fact]
        public void Validator_validate_minimum_5_characters_fail()
        {
            // Arrange 
            string too_short_string = "abs";
            // Act
            List<string> errors = Validator.ValidateStringIf(too_short_string);
            // Assert
            Assert.Contains("Should have minimum 5 characters",errors);
        }        





        
    }
}
