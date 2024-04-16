using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModellib
{
   public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Department_Head {  get; set; } 

        public Department()
        {
            Id = 0;
            Name = string.Empty;
            Department_Head = 0;
        }
        public Department(int id,string name, int department_Head)
        {
            Id = id;
            Name = name;
            Department_Head = department_Head;
        }
    }
}
