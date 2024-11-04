using Azure;
using EmployeeDetailsEntity.Data;
using EmployeeDetailsEntity.Models.Details;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsEntity.Models.emp
{
    public class SqlEmployee : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public SqlEmployee(ApplicationDbContext context)
        {
            _context = context;
        }
        public string DeleteEmployee(int id)
        {
            if (id > 0)
            {
                var employee = _context.employees.Find(id);
                if (employee != null)
                {
                    _context.employees.Remove(employee);
                    _context.SaveChanges();
                    return "Delete Successfully";
                }
                else
                {
                    return "Can't find record please enter valid id";
                }
            }
            else
            {
                return "Can't find record please enter valid id";
            }
        }

        public Employee GetEmployee(int id)
        {
            var employee = _context.employees.Include(e => e.EmployeeDetails).FirstOrDefault(e => e.id == id);

            return employee;
        }

        public Employee InsertEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public string UpdateEmployee(Employee employee)
        {
            var existEmployee = _context.employees.Include(e => e.EmployeeDetails).FirstOrDefault(e => e.id == employee.id);

            if (existEmployee != null)
            {
                // لا حاجة لتحديث الـ id
                existEmployee.fName = employee.fName;
                existEmployee.lName = employee.lName;
                existEmployee.age = employee.age;
                existEmployee.salary = employee.salary;
                existEmployee.state = employee.state;
                existEmployee.email = employee.email;
                existEmployee.phone = employee.phone;
                existEmployee.gender = employee.gender;
                existEmployee.country = employee.country;

                // تحديث EmployeeDetails
                var details = existEmployee.EmployeeDetails;

                if (details == null)
                {
                    details = new List<EmployeeDetails>();
                    existEmployee.EmployeeDetails = details;
                }
                else
                {

                    foreach (var detail in employee.EmployeeDetails)
                    {
                        if (detail != null)
                        {
                            // تحديث أو إضافة التفاصيل
                            var existDetail = details.FirstOrDefault(d => d.id == detail.id);

                            if (existDetail != null)
                            {
                                // تحديث الخصائص إذا كانت موجودة
                                existDetail.jobTitle = detail.jobTitle;
                                existDetail.city = detail.city;
                                existDetail.experience = detail.experience;
                            }
                            else
                            {
                                // إضافة كائن جديد إذا لم يكن موجودًا
                                details.Add(new EmployeeDetails
                                {
                                    jobTitle = detail.jobTitle,
                                    city = detail.city,
                                    experience = detail.experience
                                });
                            }
                        }
                    }
                }
                // حفظ التغييرات
                _context.SaveChanges();
                return "Update Successfully";
            }
            else
            {
                return "Can't Update";
            }
        }
    }
}
