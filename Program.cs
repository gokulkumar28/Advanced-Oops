using System;
using System.Buffers;
namespace StudentApplication{
    class Program{
        public static void Main(string[] args)
        {
            FileHandling.Create();
           // Operation.AddDefaultData();
           FileHandling.ReadFromCSV();
            //Calling main menu
            Operation.MainMenu();
            FileHandling.WriteToCSV();
        }
    }
}
