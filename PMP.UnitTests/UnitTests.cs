using NUnit.Framework;
using ProjectManagmenPortal.API;
using ProjectManagmenPortal.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PMP.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void GetProjects_Test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetProjects();
            var contentResult = actionResult as OkNegotiatedContentResult<List<Project>>;
            Assert.IsTrue(contentResult.Content.Count>0);
        }
        [Test]
        public void GetUsers_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetUsers();
            var contentResult = actionResult as OkNegotiatedContentResult<List<User>>;
            Assert.IsTrue(contentResult.Content.Count>=0);
        }
        [Test]
        public void GetParentTasks_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetParentTasks();
            var contentResult = actionResult as OkNegotiatedContentResult<List<ParentTask>>;
            Assert.IsTrue(contentResult.Content.Count >= 0);
        }

        [Test]
        public void GetTasks_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetTasks();
            var contentResult = actionResult as OkNegotiatedContentResult<List<ProjectManagmenPortal.API.Task>>;
            Assert.IsTrue(contentResult.Content.Count >= 0);
        }
            
        [Test]
        public void GetTaskById_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetTaskById(1);
            var contentResult = actionResult as OkNegotiatedContentResult<List<ProjectManagmenPortal.API.Task>>;
            Assert.IsNull(contentResult);
        }
        [Test]
        public void GetProjById_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetProjById(1);
            var contentResult = actionResult as OkNegotiatedContentResult<List<ProjectManagmenPortal.API.Task>>;
            Assert.IsNull(contentResult);
        }

        [Test]
        public void GetUserById_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.GetUserById(1);
            var contentResult = actionResult as OkNegotiatedContentResult<List<ProjectManagmenPortal.API.Task>>;
            Assert.IsNull(contentResult);
        }

    }
}
