﻿using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailsEntity.Models.emp
{
    public interface IEmployee
    {

        public Employee InsertEmployee(Employee employee);
        public Employee GetEmployee(int id);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int id);
    }
}