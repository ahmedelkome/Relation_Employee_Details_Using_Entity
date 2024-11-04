
using EmployeeDetailsEntity.Models.emp;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDetailsEntity.Models.Details
{
    public class EmployeeDetails
    {
        public int id { get; set; }

        public string? city { get; set; }

        public int? experience { get; set; }

        public string? jobTitle { get; set; }

       

    }
}
