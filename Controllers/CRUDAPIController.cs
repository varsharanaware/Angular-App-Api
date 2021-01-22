using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudAngular.Models;

namespace CrudAngular.Controllers
{
   // [Route("Api/Employee")]
    public class CRUDAPIController : ApiController
    {
        TASKEntities db = new TASKEntities();


        //Get Employee
        [HttpGet]
        [Route("Api/Employee/AllEmployeeDetails")]
        public IQueryable<employee> GetEmployee()
        {
            try
            {
                return db.employees;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Get employee by ID
        [HttpGet]
        [Route("Api/Employee/GetEmployeeDetailsById/{employeeId}")]
        public IHttpActionResult GetEmployeeId(string employeeId)
        {
            employee objEmp = new employee();
            int ID = Convert.ToInt32(employeeId);
            try
            {
                objEmp = db.employees.Find(ID);
                if(objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Ok(objEmp);
        }


        [HttpPost]
        [Route("Api/Employee/InsertEmployeeDetails")]
        public IHttpActionResult PostEmployee(employee emp)
        {
            if (emp.Gender == "true")
            {
                emp.Gender = "Male";
            }
            else
            {
                emp.Gender = "Female";
            }

            if (emp.EmpId > 0)
            {
                db.Entry(emp).State = EntityState.Modified;
            }
            else
            {
              
                db.employees.Add(emp);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Ok("Failed");
            }
            return Ok(emp);
        }



        //Update employee details
        [HttpPut]
        [Route("Api/Employee/UpdateEmployeeDetails")]
        public IHttpActionResult PutEmployeeMaster(employee emp)
        {
            if(!ModelState.IsValid)
            {

            }
            try
            {
                employee objEmp = new employee();
                objEmp = db.employees.Find(emp.EmpId);
                if(objEmp != null)
                {
                    objEmp.EmpName = emp.EmpName;
                    objEmp.Address = emp.Address;
                    objEmp.EmailId = emp.EmailId;
                   
                    objEmp.Gender = emp.Gender;
                    if(objEmp.Gender== "true")
                    {
                        objEmp.Gender = "Male";
                    }
                    else
                    {
                        objEmp.Gender = "Female";
                    }
                  

                }
                int i = this.db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(emp);
        }



        //Delete employee
        [HttpDelete]
        [Route("Api/Employee/DeleteEmployeeDetails/{employeeId}")]
        public IHttpActionResult DeleteEmployeeDelete(string employeeId)
        {
            int ID = Convert.ToInt32(employeeId);
            employee employee = db.employees.Find(ID);
            if(employee == null)
            {
                return NotFound();
            }
            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }
        
    }
}
