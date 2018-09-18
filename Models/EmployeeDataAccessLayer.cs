using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class EmployeeDataAccessLayer
    {
        myDBContext db = new myDBContext();
        public IEnumerable<EmployeeMaster> GetAllEmployees()
        {
            try
            {
                return db.EmployeeMaster
                    .Select(n => new EmployeeMaster
                    {
                        Name = n.Name,
                        Surname = n.Surname,
                        Address = n.Address,
                        Qualification = n.Qualification,
                        ContactNumber = n.ContactNumber,
                        DepartmentName = n.DepartmentMaster.DepartmentName,
                        Id = n.Id
                    }).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddEmployee(EmployeeMaster employee)
        {
            try
            {
                db.EmployeeMaster.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee  
        public int UpdateEmployee(EmployeeMaster employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public EmployeeMaster GetEmployeeData(int id)
        {
            try
            {
                EmployeeMaster employee = db.EmployeeMaster.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                EmployeeMaster emp = db.EmployeeMaster.Find(id);
                db.EmployeeMaster.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Department  
        public List<DepartmentMaster> Getdepartments()
        {
            List<DepartmentMaster> lstDepartment = new List<DepartmentMaster>();
            lstDepartment = db.DepartmentMaster.ToList();

            return lstDepartment;
        }
    }
}
