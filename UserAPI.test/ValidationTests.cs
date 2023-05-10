using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI;

namespace UserAPI.test
{
    public class ValidationTests
    {
        [Fact]
        public void Validation_IsValidAge_ReturnBool()
        {
            //AAA Pattern
            //Arrange
            int Age = 23;
            string Birthday = "07/01/2000";
            var validAge = new Validation();
            //Act
            var Result = validAge.IsValidAge(Age, Birthday);
            //Assert
            Assert.Equal(true, Result);
        }
        [Fact]
        public void Validation_IsValidBirthday_ReturnBool()
        {
            //AAA Pattern
            //Arrange
            string Birthday = "07/01/2000";
            var validBirthday = new Validation();
            //Act
            var Result = validBirthday.IsValidBirthday(Birthday);
            //Assert
            Assert.Equal(true, Result);
        }
        [Fact]
        public void Validation_TypeCheckInt_ReturnBool()
        {
            //AAA Pattern
            //Arrange
            string ExampleString = "1907";
            var validString = new Validation();
            //Act
            var Result = validString.TypeCheckInt(ExampleString);
            //Assert
            Assert.Equal(true, Result);
        }
        [Fact]
        public void Validation_IsValidEmail_ReturnBool()
        {
            //AAA Pattern
            //Arrange
            string ExampleString = "xxxx@gmail.com";
            var validEmail = new Validation();
            //Act
            var Result = validEmail.IsValidEmail(ExampleString);
            //Assert
            Assert.Equal(true, Result);
        }
    }
}
