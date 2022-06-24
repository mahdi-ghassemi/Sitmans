using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class Events
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string LevelId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string LastValue { get; set; }
        public string CurrentValue { get; set; }
        public string SubjectId { get; set; }
        public string AgentId { get; set; }
        public string EventId { get; set; } 
        public string Shown { get; set; }       
    }
}
