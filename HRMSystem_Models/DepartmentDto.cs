using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Models
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Code field is required")]
		public string Code { get; set; }
    }
}
