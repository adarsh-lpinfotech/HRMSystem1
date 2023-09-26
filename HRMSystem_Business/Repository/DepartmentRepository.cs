using AutoMapper;
using HRMSystem_Business.Repository.IRepository;
using HRMSystem_DataAccess;
using HRMSystem_DataAccess.Data;
using HRMSystem_Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Business.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public DepartmentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public DepartmentDto Create(DepartmentDto depObj)
        {
            var department = _mapper.Map<DepartmentDto,Department>(depObj);
            department.Created = DateTime.Now;
            var obj = _db.Add(department);
            _db.SaveChanges();
            return _mapper.Map<Department,DepartmentDto>(obj.Entity);
        }

        public int Delete(int id)
        {
            var department = _db.deparments.FirstOrDefault(u=>u.DepartmentId == id);
            if(department != null)
            {
                _db.deparments.Remove(department);
                return _db.SaveChanges();
            }
            return 0;  
        }

        public DepartmentDto Get(int id)
        {
            var department = _db.deparments.FirstOrDefault(u=>u.DepartmentId==id);
            
            if(department != null)
            {
                 return _mapper.Map<Department,DepartmentDto>(department);
            }
            return new DepartmentDto();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            //List<Department> department = new List<Department>();
            //department = _db.deparments.ToList();
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(_db.deparments);
        }

        public DepartmentDto Update(DepartmentDto depObj)
        {
            var obj = _db.deparments.FirstOrDefault(u => u.DepartmentId == depObj.DepartmentId);
            if (obj != null)
            {
                obj.Name = depObj.Name;
                obj.Code = depObj.Code;
                _db.deparments.Update(obj);
                _db.SaveChanges();
                return _mapper.Map<Department, DepartmentDto>(obj);
            }
            return depObj;
		}
    }
}
