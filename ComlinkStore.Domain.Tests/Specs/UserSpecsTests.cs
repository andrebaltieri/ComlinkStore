using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ComlinkStore.Domain.Entities;
using System.Linq;
using ComlinkStore.Domain.Specs;

namespace ComlinkStore.Domain.Tests.Specs
{
    [TestClass]
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();
            _users.Add(new User("1234567", "1234567"));
            _users.Add(new User("2234567", "2234567"));
            _users.Add(new User("3234567", "3234567"));
            _users.Add(new User("4234567", "4234567"));
            _users.Add(new User("5234567", "5234567"));
            _users.Add(new User("6234567", "6234567"));
        }

        [TestMethod]
        [TestCategory("Specs - User")]
        public void DeveRetornarUmUsuarioQuandoBuscarPeloUsername()
        {
            var result = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("3234567"))
                .FirstOrDefault();

            Assert.AreNotEqual(null, result);
        }
    }
}
