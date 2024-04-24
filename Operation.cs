using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudentApplication
{
    //static class
    public static class Operation
    {
        //Local/Global Object Creation
        static StudentDetails currentLoggedInStudent;

        //Static list Creation
       public static List<StudentDetails> studentList=new List<StudentDetails>();
       public  static List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
       public static List<AdmissionDetails> admissionList=new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("******************Welcome to syncfusion College******************");
            string mainChoice = "yes";
            do
            {
                //Need to show main menu option
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Department Seat Availability\n4. Exit");
                //Need to get an input from user and validate.
                Console.Write("Select an option: ");
                int mainOption = int.Parse(Console.ReadLine());
               
                //need to create mainmennu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**************Student Registration*******************");
                            Operation.StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******************Login****************");
                            Operation.Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("****************Department wise seat Availability******************");
                            Operation.DepartmentwaieSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited successfully");
                            mainChoice="no";
                            break;
                        }
                }
                //need to iterate until the option is exist.

            } while (mainChoice=="yes");

        }//Main Menu ending

        //Student registration
        public static void StudentRegistration()
        {
            //need to gget required details
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Your FatherName: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Date Of Birrth: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your gender fale/Female: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your physics mark");
            int physicsMark=int.Parse(Console.ReadLine());
            Console.Write("Enter your Chemistry mark");
            int chemistryMark=int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark");
            int mathsMark=int.Parse(Console.ReadLine());
            //need to get an object
            StudentDetails student=new StudentDetails(name,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            //need to add in list
            studentList.Add(student); 
            //display confimation message and ID


        }//student registration ends


        //Login

        public static void Login()
        {
            // Need to get ID input
            Console.Write("Enter your Studentn ID: ");
            string loginID=Console.ReadLine().ToUpper();
            //validate by its presence in the list
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //Assigning curent user to global variable
                    currentLoggedInStudent=student;
                    Console.WriteLine("Logged in Successfully");
                    SubMenu();
                    break;
                    //Need to call submenu
                }
            }
            if(flag)
            {
                Console.WriteLine("Invali ID or ID is not present");
            }
            // if not invalid
        }//Login ends here

        //submenu

        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                Console.WriteLine("***********Sub Menu***************");
                //Need to show sub menu option
                Console.WriteLine("Select an Option \n1. Check Eligibility \n2.Show details\n3. Take Admission\n4. Cancel Admission\n5. Show admission Details\n6. Exit");
                //Getting user Option
                Console.WriteLine("Enter your Choice");
                int subOption=int.Parse(Console.ReadLine());
                //Need to create sub menu structure
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*************Check Eligibility*****************");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****************Show Details*****************");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*****************Take Admission*******************");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*****************Cancel Admission*******************");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("*****************Show Admission Details*******************");
                        ShowAdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("Taking back to main menu");
                        subChoice="no";
                        break;
                    }
                }
                //Iterate till option exit
            }while(subChoice=="yes");
        }//Sub menu ends here

        //Check Eligibility

        public static void CheckEligibility()
        {
            //get Cutoff value as input
            Console.Write("Enter the cut Off Value: ");
            double cutOff=double.Parse(Console.ReadLine());
            //check eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is eligible");
            }
            else
            {
                Console.WriteLine("Student is not eligible");
            }
        }//Check eligibility ends here

        //Show Details

        public static void ShowDetails()
        {
            //Need to show current student's details
            Console.WriteLine("|Student ID |Student Name|Fther Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark");
           Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}");
               
        }//Show Deatils ends here

        //Take Admission

        public static void TakeAdmission()
        {
            //Take Admission
            DepartmentwaieSeatAvailability();
            //Ask department ID from user
            Console.Write("Select a department ID: ");
            string departmentID=Console.ReadLine().ToUpper();
            bool flag=true;
            //check the ID is present or not
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartMentID))
                {
                    flag=false;
                    //CheckEligible the student or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat availability
                        if(department.NumberOfSeats>0)
                        
                        {
                            int count=0;
                            //check student already taken admission
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }

                            if(count==0)
                            {
                                //create admission object
                                AdmissionDetails admissionTake=new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartMentID,DateTime.Now,AdmissionStatus.Admitted);
                                //reduce seat count
                                department.NumberOfSeats--;
                                //add to the admission list
                                admissionList.Add(admissionTake);
                                //Display admission successful message
                                Console.WriteLine($"you have take admission successfully admission ID: {admissionTake.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("You have already taken an admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible");
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }
            
        }//Take admission ends here

        //Cancel Admission

        public static void CancelAdmission()
        {
            //Check the student is taken any admission and display it.
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList){
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Booked))
                {
                     //cancel the found admission
                     admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartMentID.Equals(department.DepartMentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have no admission to cancel");
            }
           
        }//CancelAdmission ends here

        //Show Admission Details

        public static void ShowAdmissionDetails ()
        {
            //Need to show current logged in admisiion details
            Console.WriteLine("Admission ID|Student ID |Department ID|Admission DATE|Admission status|");
            foreach (AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                 Console.WriteLine($"{admission.AdmissionID}|{admission.StudentID}|{admission.StudentID}|{admission.DOB}|{admission.AdmissionStatus}");
          
                }
            }

        }//Show Admission details ends here

        //Department wise seat availability

        public static void DepartmentwaieSeatAvailability()
        {
            //Need to show all department details
            Console.WriteLine("DepartmentID |DepartmentName |NumberOfSeats");
             foreach(DepartmentDetails department in departmentList)
           {
            Console.WriteLine($"{department.DepartMentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            Console.WriteLine();
           }
        }

        //Adding Default Data
        public static void AddDefaultData()
        {
            StudentDetails student1=new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.Add(student1);
            studentList.Add(student2);
           // studentList.AddRange(new List<StudentDetails>{student1,student2});
           DepartmentDetails departmentEee=new DepartmentDetails("DID101","EEE",29);
           DepartmentDetails departmentCse=new DepartmentDetails("DID102","CSE",29);
           DepartmentDetails departmentMech=new DepartmentDetails("DID103","MEch",30);
           DepartmentDetails departmentEce=new DepartmentDetails("DID104","ECE",30);
           departmentList.AddRange(new List<DepartmentDetails>(){departmentEee,departmentCse,departmentMech,departmentEce});
           AdmissionDetails admission1=new AdmissionDetails("SF3001","DID101",new DateTime(2011,05,11),AdmissionStatus.Admitted);
           AdmissionDetails admission2=new AdmissionDetails("SF3002","DID102",new DateTime(2011,05,12),AdmissionStatus.Admitted);           
           admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});

           //Printing the data
        
          
           
        }//ends add default data
    }
}