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

        [Test]
        public void DeleteProject_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.DeleteProject(1);
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void DeleteUser_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.DeleteUser(1);
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }

        [Test]
        public void AddUser_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.AddUser(new User { Task_ID = "1", Employee_ID="1", FirstName= "AB",Lastname="CD", project_ID="1" });
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }

        [Test]
        public void AddTask_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.AddTask(new ProjectManagmenPortal.API.Task { parent_id = "1", project_ID ="1", TaskName = "TestCase", Start_Date = DateTime.Now, End_Date = DateTime.Now.AddDays(1), priority = 15 });
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void AddParentTask_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.AddParentTask(new ParentTask { parent_task = "ParentTest" });
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void AddProject_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.AddProject(new Project { ProjectName = "TestProj", priority = 0, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) });
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void UpdateStatusOfTask_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            IHttpActionResult actionResult = ic.UpdateStatusOfTask(1);
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void UpdateProject_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            Project proj = new Project{ ProjectName = "TestProj", priority = 0, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
            IHttpActionResult actionResult = ic.UpdateProject(proj);
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }
        [Test]
        public void UpdateUser_test()
        {
            ProjectManagmentController ic = new ProjectManagmentController();
            User proj = new User { Task_ID = "1", Employee_ID = "1", FirstName = "AB", Lastname = "EF", project_ID = "1" };
            IHttpActionResult actionResult = ic.UpdateUser(proj);
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

        }

    }
}
