using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public ICollection<Issue> Issues { get; } = new List<Issue>();


    }
}
