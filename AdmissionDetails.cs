using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication
{

    //Enum declaration
    /// <summary>
    /// 
    /// </summary>
    public enum AdmissionStatus{select,Booked,Admitted,Cancelled}
    public class AdmissionDetails
    {
        /*a.	AdmissionID – (Auto Increment ID - AID1001)
b.	StudentID
c.	DepartmentID
d.	AdmissionDate
e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
*/

    //field
    //static field
    private static int s_admissionID=1000;


    //property

    public string  AdmissionID { get; set; }
    public string StudentID { get; set; }
    public string DepartMentID { get; set; }
    public DateTime DOB { get; set; }
    public AdmissionStatus AdmissionStatus { get; set; }

    //Constructor method

    public AdmissionDetails(string studentID,string departMentID,DateTime admissionDate,AdmissionStatus admissionStatus){
       AdmissionID="AID"+s_admissionID;
       StudentID=studentID;
       DepartMentID=departMentID;
       DOB=admissionDate;
       AdmissionStatus=admissionStatus;
    }

    public AdmissionDetails(string admission)
    {
        string[] admisiionDetails=admission.Split(",");
        AdmissionID=admisiionDetails[0];
        s_admissionID=int.Parse(admisiionDetails[0].Remove(0,3));
       StudentID=admisiionDetails[1];
       DepartMentID=admisiionDetails[2];
       DOB=DateTime.ParseExact(admisiionDetails[3],"dd/MM/yyyy",null);
       AdmissionStatus=Enum.Parse<AdmissionStatus>(admisiionDetails[4]);
    }
       
    }
}