using sprout.data.Entity;
using sprout.service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace sprout.service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private string path = @"..\..\..\..\sprout_solutions\sprout_solutions_BE\sprout_solutions\sprout.data\Data\employees.json";
        private string jsonString = File.ReadAllText(@"..\..\..\..\sprout_solutions\sprout_solutions_BE\sprout_solutions\sprout.data\Data\employees.json");

        public double Calculate(string id, double days)
        {
            var list = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            var employee = list.FirstOrDefault(x => x.Id == id);
            var numOfWorkingDays = 23 - days;
            if (employee.EmployeeType == 0)
            {
                //regular
                var netSalary = employee.BasicSalary - (employee.BasicSalary / numOfWorkingDays) - (employee.BasicSalary * 0.12);

                list.Remove(employee);
                list.Add(new Employee()
                {
                    Id = employee.Id,
                    BasicSalary = employee.BasicSalary,
                    Birthday = employee.Birthday,
                    EmployeeType = employee.EmployeeType,
                    Name = employee.Name,
                    TIN = employee.TIN,
                    NetSalary = Math.Round(netSalary, 2) 
                });
                string json = JsonSerializer.Serialize(list);
                File.WriteAllText(path, json);
                return netSalary;
            }
            else
            {
                //contractor
                var netSalary = employee.BasicSalary * days;

                list.Remove(employee);
                list.Add(new Employee()
                {
                    Id = employee.Id,
                    BasicSalary = employee.BasicSalary,
                    Birthday = employee.Birthday,
                    EmployeeType = employee.EmployeeType,
                    Name = employee.Name,
                    TIN = employee.TIN,
                    NetSalary = Math.Round(netSalary, 2)
                });
                string json = JsonSerializer.Serialize(list);
                File.WriteAllText(path, json);
                return netSalary;
            }
        }

        public void CreateEmployee(Employee employee)
        {
            var list = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            list.Add(new Employee()
            {
                Id = employee.Id,
                BasicSalary = employee.BasicSalary,
                Birthday = employee.Birthday,
                EmployeeType = employee.EmployeeType,
                Name = employee.Name,
                TIN = employee.TIN,
                NetSalary = 0
            });

            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(path, json);
        }

        public void EditDetails(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            var employees = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            return employees;
        }

        public Employee GetById(string id)
        {
            var employees = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            var employee = employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }
    }
}
