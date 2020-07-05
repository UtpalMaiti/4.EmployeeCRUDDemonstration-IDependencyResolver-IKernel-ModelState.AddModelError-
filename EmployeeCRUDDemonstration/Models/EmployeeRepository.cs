using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeCRUDDemonstration.Models
{
    public class EmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "select * from EmpInfo";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Employee> empList = new List<Employee>();
            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Employee emp = new Employee
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId = (int)dr[4]
                };

                empList.Add(emp);
            }

            conn.Close();

            return empList;
        }

        public Employee GetEmployeeById(int Id)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "select * from EmpInfo where Id=" + Id;
            SqlCommand cmd = new SqlCommand(query, conn);
            Employee emp = null;
            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                emp = new Employee
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId = (int)dr[4]
                };
            }

            conn.Close();

            return emp;
        }
        public bool Create(Employee emp)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "insert into EmpInfo values(@Id,@Name,@Loc,@Sal,@DeptId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@DeptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }

        public bool Update(Employee emp)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "update EmpInfo set Name=@Name, Location=@Loc, Salary=@Sal, DepartmentId=@DeptId where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@DeptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }

        public bool Delete(int Id)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "delete from EmpInfo where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }
    }
}