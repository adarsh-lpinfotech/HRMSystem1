using AutoMapper;
using HRMSystem_Business.Repository.IRepository;
using HRMSystem_DataAccess;
using HRMSystem_DataAccess.Data;
using HRMSystem_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Business.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;
		public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
		{
			db = _db;
			mapper = _mapper;
		}

		public EmployeeDto Create(EmployeeDto employee)
		{
			var empObj = _mapper.Map<EmployeeDto, Employee>(employee);
			empObj.CreatedDate = DateTime.Now;
			_db.Add(empObj);
			_db.SaveChanges();
			return _mapper.Map<Employee, EmployeeDto>(empObj);
		}

		public int Delete(int id)
		{
			var empObj = _db.employees.FirstOrDefault(u=>u.Id == id);
			if (empObj != null)
			{
				_db.Remove(empObj);
				return _db.SaveChanges();
			}
			return 0;
		}

		public EmployeeDto Get(int id)
		{
			var empObj = _db.employees.Include(u=>u.Department).FirstOrDefault(u => u.Id == id);
			if (empObj != null)
			{
				return _mapper.Map<Employee, EmployeeDto>(empObj);
			}
			return new EmployeeDto();
		}

		public IEnumerable<EmployeeDto> GetAll()
		{
			//var empObj = _db.employees.
			return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_db.employees.Include(u => u.Department));
		}

		public EmployeeDto Update(EmployeeDto employee)
		{
			var empObj = _db.employees.FirstOrDefault(u => u.Id == employee.Id);
			if (empObj != null)
			{
				empObj.FirstName = employee.FirstName;
				empObj.MiddletName = employee.MiddleName;
				empObj.LastName = employee.LastName;
				empObj.Code = employee.Code;
				empObj.Address = employee.Address;
				empObj.City = employee.City;
				empObj.State = employee.State;
				empObj.Country = employee.Country;
				empObj.PostalCode = employee.PostalCode;
				empObj.PhoneNo = employee.PhoneNo;
				empObj.DepartmentId = employee.DepartmentId;
				_db.employees.Update(empObj);
				_db.SaveChanges();
				return _mapper.Map<Employee, EmployeeDto>(empObj);
			}
			return employee;
		}
	}
}
