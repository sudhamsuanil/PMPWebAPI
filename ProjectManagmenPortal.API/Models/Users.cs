using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagmenPortal.API.Models
{
    public class Users
    {
        [Key]
        public int user_id  {get;set;}
        public string FirstName {get;set;}
        public string Lastname {get;set;}
        public string Employee_ID {get;set;}
        public string project_ID {get;set;}
        public string Task_ID { get; set; }
    }
}