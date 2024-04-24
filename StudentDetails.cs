using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication
{
    //Enum Dclaration
   public enum Gender {select,Male,Female}
    public class StudentDetails
    {
    //Field
    //Static field
    /// <summary>
    /// studentId 
    /// </summary> <summary>
    /// 
    /// </summary>
    private static int s_studentID=3000;

    //Properties
    public string StudentName { get; set; }
    public string StudentID { get;  } //Read only
    public string FatherName { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
    public int PhysicsMark { get; set; }
    public int ChemistryMark { get; set; }
    public int MathsMark { get; set; }

    //Constructor
    
    public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physicsMark,int chemistryMark,int mathsMark){
        //Auto Incrementation
        s_studentID++;
        StudentID="SF"+s_studentID;
        StudentName=studentName;
        FatherName=fatherName;
        DOB=dob;
        Gender=gender;
        PhysicsMark=physicsMark;
        ChemistryMark=chemistryMark;
        MathsMark=mathsMark;
    }

    public StudentDetails(string students){      //Auto Incrementation
       string[] studentDetails=students.Split(",");
       StudentID=studentDetails[0];
       s_studentID=int.Parse(studentDetails[0].Remove(0,2));        // this is to next person student id starting
        StudentName=studentDetails[1];
        FatherName=studentDetails[2];
        DOB=DateTime.ParseExact(studentDetails[3],"dd/MM/yyyy",null);
        Gender=Enum.Parse<Gender>(studentDetails[4]);
        PhysicsMark=int.Parse(studentDetails[5]);
        ChemistryMark=int.Parse(studentDetails[6]);
        MathsMark=int.Parse(studentDetails[7]);
    }

    //Methods
    public double Average(){
        int total=PhysicsMark+ChemistryMark+MathsMark;
        double average=(double)total/3;
        return average;
    }
    public bool CheckEligibility(double cutOff){
        if(cutOff>=75.0){
            return true;
        }
        return false;
    }


    }
}