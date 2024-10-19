using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreP1Employee.Models
{
    public class Departments
    {
        public int DepartmentId {  get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public  ICollection<Employees> Employees { get; set; }
    }
}
