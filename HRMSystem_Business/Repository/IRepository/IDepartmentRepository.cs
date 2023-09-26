using HRMSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Business.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        public DepartmentDto Create(DepartmentDto depObj);
        public DepartmentDto Update(DepartmentDto depObj);
        public int Delete(int id);
        public DepartmentDto Get(int id);
        public IEnumerable<DepartmentDto> GetAll();
    }
}
