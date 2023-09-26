using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_DataAccess
{
	public class Employee
	{
        public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string MiddletName { get; set; }
		public string LastName { get; set; }
		[Required]
		public string Code { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string PhoneNo { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsDeleted { get; set; }
		[ForeignKey("Department")]
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
