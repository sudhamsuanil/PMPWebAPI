using ProjectManagmenPortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagmenPortal.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagmentController : ApiController
    {
        [HttpGet]
        [Route("api/ProjectManagment/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                using (
                    var fsd= new FSDEntities())
                {
                    List<User> items = fsd.Set<User>().ToList();
                    return Ok(items);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/ProjectManagment/GetProjects")]
        public IHttpActionResult GetProjects()
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<Project> items = fsd.Set<Project>().ToList();
                    return Ok(items);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/ProjectManagment/GetParentTasks")]
        public IHttpActionResult GetParentTasks()
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<ParentTask> items = fsd.Set<ParentTask>().ToList();
                    return Ok(items);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/ProjectManagment/GetTasks")]
        public IHttpActionResult GetTasks()
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<Task> items = fsd.Set<Task>().ToList();
                    return Ok(items);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpGet]
        [Route("api/ProjectManagment/GetUserById/{identity}")]
        public IHttpActionResult GetUserById(int identity)
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<User> items = fsd.Set<User>().ToList();
                    return Ok(items.Where(x=>x.user_id==identity).First());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/ProjectManagment/GetProjById/{identity}")]
        public IHttpActionResult GetProjById(int identity)
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<Project> items = fsd.Set<Project>().ToList();
                    return Ok(items.Where(x => x.Project_ID == identity).First());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/ProjectManagment/GetTaskById/{identity}")]
        public IHttpActionResult GetTaskById(int identity)
        {
            try
            {
                using (
                    var fsd = new FSDEntities())
                {
                    List<Task> items = fsd.Set<Task>().ToList();
                    return Ok(items.Where(x => x.task_id == identity));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/AddUser")]
        public IHttpActionResult AddUser(User usr)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<User>();
                    insertItem.Add(new User { FirstName = usr.FirstName.TrimEnd(), Lastname = usr.Lastname.TrimEnd(),Employee_ID=usr.Employee_ID.TrimEnd() });
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/AddProject")]
        public IHttpActionResult AddProject(Project proj)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Project>();
                    insertItem.Add(new Project { ProjectName = proj.ProjectName, StartDate = proj.StartDate, EndDate = proj.EndDate,priority=proj.priority });
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/AddParentTask")]
        public IHttpActionResult AddParentTask(ParentTask proj)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<ParentTask>();
                    insertItem.Add(new ParentTask { parent_task = proj.parent_task});
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/AddTask")]
        public IHttpActionResult AddTask(Task proj)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Task>();
                    insertItem.Add(new Task { parent_id=proj.parent_id, project_ID=proj.project_ID, TaskName=proj.TaskName,Start_Date=proj.Start_Date,End_Date=proj.End_Date,priority=proj.priority });
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/UpdateUser")]
        public IHttpActionResult UpdateUser(User usr)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<User>();
                    User present = new User();
                    present = insertItem.Where(x => x.user_id == usr.user_id).First();
                    present.FirstName = usr.FirstName;
                    present.Lastname = usr.Lastname;
                    present.Employee_ID = usr.Employee_ID;                  
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/UpdateProject")]
        public IHttpActionResult UpdateProject(Project proj)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Project>();
                    Project present = new Project();
                    present = insertItem.Where(x => x.Project_ID == proj.Project_ID).First();
                    present.ProjectName = proj.ProjectName;
                    present.StartDate = proj.StartDate;
                    present.EndDate = proj.EndDate;
                    present.priority = proj.priority;
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/UpdateStatusOfTask/{taskId}")]
        public IHttpActionResult UpdateStatusOfTask(int taskId)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Task>();
                    Task present = new Task();
                    present = insertItem.Where(x => x.task_id == taskId).First();
                    present.Status = "Completed";
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ProjectManagment/UpdateStatusOfTask/{taskId}")]
        public IHttpActionResult UpdateTask(Task task)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Task>();
                    Task present = new Task();
                    present = insertItem.Where(x => x.task_id == task.task_id).First();
                    
                    present.Start_Date = task.Start_Date;
                    present.End_Date = task.End_Date;
                    present.TaskName = task.TaskName;
                    present.Status = task.Status;

                    present.Status = "Completed";
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("api/ProjectManagment/DeleteUser/{identity}")]
        public IHttpActionResult DeleteUser(int identity)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<User>();
                    insertItem.Remove(insertItem.Where(x => x.user_id == identity).First());
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("api/ProjectManagment/DeleteProject/{identity}")]
        public IHttpActionResult DeleteProject(int identity)
        {
            try
            {
                using (var fsd = new FSDEntities())
                {

                    var insertItem = fsd.Set<Project>();
                    insertItem.Remove(insertItem.Where(x => x.Project_ID == identity).First());
                    fsd.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
