using Application.UseCases;
using Domain;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {

        public User RgUser { get; set; }
        public User LastUser { get; set; }

        public UnitTest1()
        {
            this.RgUser = RegisterUser.Execute("Adevaldo", "03/03/1997", "adevaldo@email.com", "senha");
            this.LastUser = GetUser.GetLastUser();
        }

        [Fact]
        public void Test1()
        {
            Assert.True(RgUser.Equals(LastUser));

        }
    }
}
