using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController _controller;
        private List<User> _users;

        [SetUp]
        public void Setup()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "Test User 1", Email = "test1@example.com" },
                new User { Id = 2, Name = "Test User 2", Email = "test2@example.com" },
                new User { Id = 3, Name = "Test User 3", Email = "test3@example.com" }
            };

            _controller = new UserController { };
            UserController.userlist = _users;
        }

        [Test]
        public void Index_ReturnsViewWithCorrectModel()
        {
            var result = _controller.Index() as ViewResult;
            var model = result.Model as List<User>;

            Assert.Equals(_users, model);
        }

        [Test]
        public void Details_ValidId_ReturnsViewWithCorrectModel()
        {
            var result = _controller.Details(1) as ViewResult;
            var model = result.Model as User;

            Assert.Equals(_users[0], model);
        }

        [Test]
        public void Details_InvalidId_ReturnsHttpNotFound()
        {
            var result = _controller.Details(999);
            // asser that the result is of type HttpNotFoundResult

            Assert.Equals(typeof(HttpNotFoundResult), result.GetType());

        }

        // Continue with similar tests for Create (GET and POST), Edit (GET and POST), and Delete (GET and POST)
    }
}
