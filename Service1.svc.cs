using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _22___WCF_Assignment___2_DOTNET
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();
            con = new SqlConnection(constr);

        }
        public string AddEmployee(Employee objEmployee)
        {
            connection();
            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("insert into employee (emp_no,emp_fname,emp_lname,dept_no,Salary) values(" + objEmployee.emp_no + ",'" + objEmployee.emp_fname + "','" + objEmployee.emp_lname + "','" + objEmployee.dept_no + "'," + objEmployee.Salary + ")", con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }

            finally
            {
                con.Close();
            }

        }
        public string UpdateEmployee(Employee objEmployee)
        {
            connection();
            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("update employee set emp_fname='" + objEmployee.emp_fname + "',emp_lname='" + objEmployee.emp_lname + "',dept_no='" + objEmployee.dept_no + "',Salary=" + objEmployee.Salary + " where emp_no=" + objEmployee.emp_no, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string DeleteEmployee(string  EmpId)
        {
            connection();
            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Delete Employee where EmpId=" + EmpId + "", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }

            finally
            {
                con.Close();
            }

        }
        public Employee RetreiveEmployeeByID(string EmployeeID)
        {
            connection();
            DataSet ds = null;
            Employee cobj = null;
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Employee where emp_no=" + EmployeeID, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Employee();
                    cobj.emp_no = Convert.ToInt32(ds.Tables[0].Rows[i]["emp_no"].ToString());
                    cobj.emp_fname = ds.Tables[0].Rows[i]["emp_fname"].ToString();
                    cobj.emp_lname = ds.Tables[0].Rows[i]["emp_lname"].ToString();
                    cobj.dept_no = ds.Tables[0].Rows[i]["dept_no"].ToString();
                    cobj.Salary = Convert.ToInt32(ds.Tables[0].Rows[i]["Salary"]);
                }
                return cobj;
            }
            catch
            {
                return cobj;
            }

            finally
            {
                con.Close();
            }
        }
        public List<Employee> RetreiveEmployees()
        {
            connection();
            DataSet ds = null;
            List<Employee> custlist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("Select * From Employee", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Employee>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Employee cobj = new Employee();
                    cobj.emp_no = Convert.ToInt32(ds.Tables[0].Rows[i]["emp_no"].ToString());
                    cobj.emp_fname = ds.Tables[0].Rows[i]["emp_fname"].ToString();
                    cobj.emp_lname = ds.Tables[0].Rows[i]["emp_lname"].ToString();
                    cobj.dept_no = ds.Tables[0].Rows[i]["dept_no"].ToString();
                    cobj.Salary = Convert.ToInt32(ds.Tables[0].Rows[i]["Salary"].ToString());
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch (Exception ex)
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
