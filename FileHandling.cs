using System;
using System.IO;

namespace StudentApplication
{
    public partial class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("StudentApplication"))
            {
                Console.WriteLine("Creating Folder...");
                Directory.CreateDirectory("StudentApplication");
            }

            //StudentInfo creation
            if(!File.Exists("StudentApplication/StudentInfo.csv"))
            {
                Console.WriteLine("Creating studentInfo.csv file....");
                File.Create("StudentApplication/StudentInfo.csv").Close();
            }

            //Admission Info creation
            if(!File.Exists("StudentApplication/AdmissionInfo.csv"))
            {
                Console.WriteLine("Creating Admissioninfo.csv file.....");
                File.Create("StudentApplication/AdmissionInfo.csv").Close();
            }

            //DepartmentInfo Creation
            if(!File.Exists("StudentApplication/DepartmentInfo.csv"))
            {
                Console.WriteLine("Creating departmentInfo.csv bfile......");
                File.Create("StudentApplication/DepartmentInfo.csv").Close();
            }


        }

        public static void WriteToCSV()
        {
            string [] students=new string[Operation.studentList.Count];
            for(int i=0;i<Operation.studentList.Count;i++)
            {
                students[i]=Operation.studentList[i].StudentID+","+Operation.studentList[i].StudentName+","+Operation.studentList[i].FatherName+","+Operation.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operation.studentList[i].Gender+","+Operation.studentList[i].PhysicsMark+","+Operation.studentList[i].ChemistryMark+","+Operation.studentList[i].MathsMark;
            }
            File.WriteAllLines("StudentApplication/StudentInfo.csv",students);

            //Departmenst
            string[] departments=new string[Operation.departmentList.Count];
            for(int i=0;i<Operation.departmentList.Count;i++)
            {
                departments[i]=Operation.departmentList[i].DepartMentID+","+Operation.departmentList[i].DepartmentName+","+Operation.departmentList[i].NumberOfSeats;

            }
            File.WriteAllLines("StudentApplication/DepartmentInfo.csv",departments);

            //Admision
            string [] admissions=new string [Operation.admissionList.Count];
            for(int i=0;i<Operation.admissionList.Count;i++)
            {
                admissions[i]=Operation.admissionList[i].AdmissionID+","+Operation.admissionList[i].StudentID+","+Operation.admissionList[i].DepartMentID+","+Operation.admissionList[i].DOB.ToString("dd/MM/yyyy")+","+Operation.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("StudentApplication/AdmissionInfo.csv",admissions);
        }

        public static void ReadFromCSV()
        {
            string[] students=File.ReadAllLines("StudentApplication/StudentInfo.csv");
            foreach(string student in students)
            {
                StudentDetails student1=new StudentDetails(student);
                Operation.studentList.Add(student1);
            }

            string[] departments=File.ReadAllLines("StudentApplication/DepartmentInfo.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1=new DepartmentDetails(department);
                Operation.departmentList.Add(department1);
            }

            string[] admissions=File.ReadAllLines("StudentApplication/AdmissionInfo.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1=new AdmissionDetails(admission);
                Operation.admissionList.Add(admission1);
            }
        }
    }
}