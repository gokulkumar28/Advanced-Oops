using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication
{
    public class DepartmentDetails
    {
     
     //Field
     //static field
     private static int s_departmentID=100;

     //ptoperty
     public string  DepartMentID { get;  }  //read only
     public string DepartmentName { get; set; }
    public int NumberOfSeats { get; set; }

    //Constructor

    public DepartmentDetails(string departmentName,string departmentID,int numberOfSeats){
        s_departmentID++;
        DepartMentID="DID"+s_departmentID;
        DepartmentName=departmentName;
        NumberOfSeats=numberOfSeats;
    }
    public DepartmentDetails(string department){
        string[] departmentDetails=department.Split(",");
        DepartMentID=departmentDetails[0];
        s_departmentID=int.Parse(departmentDetails[0].Remove(0,3));
        DepartmentName=departmentDetails[1];
        NumberOfSeats=int.Parse(departmentDetails[2]);
    }
    }
}