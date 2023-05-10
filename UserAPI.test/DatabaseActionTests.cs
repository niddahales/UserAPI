using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.test
{
    public class DatabaseActionTests
    {
        [Fact]
        public void DatabaseAction_AddUser_ReturnBool()
        {
            //AAA Pattern
            //Arrange
            User user = new User();
            user.Name = "xxxx"; 
            user.Email = "xxxx@gmail.com";
            user.Password = 1234;
            user.ConfirmPassword = 1234;
            user.Birthday = "01/01/2000";
            user.Age = 23;
            var IsSucceed = new DatabaseAction();
            //Act
            IsSucceed.AddUser(user);
            //Assert
            Assert.Equal(true, IsSucceed.control);
        }
        [Fact]
        public void DatabaseAction_GetUsers_ReturnList()
        {
            //AAA Pattern
            //Arrange
            var GettingUsers = new DatabaseAction();
            //Act
            var result = GettingUsers.GetUsers();
            //Assert
            Assert.Equal(true, result.Count>=0);
        }
    }
}
