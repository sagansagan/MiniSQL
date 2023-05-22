using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQL.Models
{
    internal class ProjectPerson
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public int Person_Id { get; set; }
        public string? person_name { get; set; }
        public string? project_name { get; set; }
        public int hours { get; set; }
    }
}
