using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _22___WCF_Assignment___2_DOTNET
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        List<Employee> RetreiveEmployees();
        [OperationContract]
        Employee RetreiveEmployeeByID(string CustomerID);
        [OperationContract]
        string DeleteEmployee(string  Empid);
        [OperationContract]
        string UpdateEmployee(Employee objEmployee);
        [OperationContract]
        string AddEmployee(Employee objEmployee);
    }
    [DataContract]
    public class Employee
    {[DataMember]
        public int emp_no { get; set; }
        [DataMember]
        public string emp_fname { get; set; }
        [DataMember]
        public string emp_lname { get; set; }
        [DataMember]
        public string dept_no { get; set; }
        [DataMember]
        public int Salary { get; set; }
    }
}
