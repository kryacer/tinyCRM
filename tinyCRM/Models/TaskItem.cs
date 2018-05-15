using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tinyCRM.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; } //public ApplicationUser User{get;set;}
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public double Progress { get; set; }
    }
}