using System;

namespace SimpleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doingSomething = true;
            while (doingSomething){
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("create, update, delete, view");
                string whatToDo = Console.ReadLine();
                
                    if (whatToDo == "create"){
                        DbConnector.Create();
                    }
                    else if (whatToDo == "update"){
                        DbConnector.Update();
                    }
                    else if (whatToDo == "delete"){
                        DbConnector.Delete();
                    }
                    else if (whatToDo == "view"){
                        DbConnector.Read();
                    }
                    else{
                        continue;
                    }
            }
        }
    }
}
