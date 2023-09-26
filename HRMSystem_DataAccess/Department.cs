using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_DataAccess
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
