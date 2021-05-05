using sprout.data.Entity;
using sprout.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprout.service.Interface
{
    public interface IEmployeeService
    {
        EmployeeModel GetAll();
        Employee GetById(string id);
        void CreateEmployee(Employee employee);
        void EditDetails(Employee employee);
        double Calculate(string id, double days);
    }
}
