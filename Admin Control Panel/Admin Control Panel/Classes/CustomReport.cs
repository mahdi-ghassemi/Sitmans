using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class CustomReport
    {
        public string Id { get; set; }
        public string ReportId { get; set; }
        public string ReportName { get; set; }
        public string Value { get; set; }
        public string ItemText { get; set; }
        public string ItemId { get; set; }
        public string Oprator { get; set; }
        public string NextOprator { get; set; }
        public int ACL { get; set; }

        public CustomReport()
        {

        }
    }
}
