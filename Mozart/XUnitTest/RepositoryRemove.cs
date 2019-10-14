using Application.UseCases;
using Domain;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTest2
    {

        public User RmUser { get; set; }
        public User UserId { get; set; }

        public UnitTest2()
        {
            UserId = new User();
           
        }

        [Fact]
        public void Test2()
        {
            UserId = RegisterUser.Execute("Aderaldo", "03/05/1994", "aderaldo@email.com", "senha");
            Guid IdVerificar = UserId.Id;

            RemoveUser.Execute(IdVerificar);
            Assert.True(GetUser.ById(IdVerificar) == null);

        }
    }
}
