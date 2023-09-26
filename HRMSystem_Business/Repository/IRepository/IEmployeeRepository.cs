using HRMSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Business.Repository.IRepository
{
	public interface IEmployeeRepository
	{
		public EmployeeDto Create(EmployeeDto employee);
		public EmployeeDto Update(EmployeeDto employee);
		public int Delete(int id);
		public EmployeeDto Get(int id);
		public IEnumerable<EmployeeDto> GetAll();
	}
}
