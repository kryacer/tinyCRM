﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tinyCRM.Models
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public double Progress { get; set; }
    }
}