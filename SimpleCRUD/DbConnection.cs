using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System;
 
namespace SimpleCRUD
{
    public class DbConnector
    {
        static string server = "localhost";
        static string db = "consoleDB"; //Change to your schema name
        static string port = "8889"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public static List<Dictionary<string, object>> Query(string queryString)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }
                      return result;
                                      }
                }
            }
        }
        //This method run a query and returns no values
        public static void Execute(string queryString)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Read(){
            List<Dictionary<string,object>> users = DbConnector.Query("SELECT * FROM users");
            foreach (Dictionary<string,object> person in users){
                Console.WriteLine(person["FirstName"]+" "+person["LastName"]+", favorite number: "+person["FavoriteNumber"]+" (User ID is "+person["idusers"]+")");

            }
        }

        public static void Create(){
            Console.WriteLine("Enter new user's first name:");
            string fn = Console.ReadLine();
            Console.WriteLine("Enter new user's last name:");
            string ln = Console.ReadLine();
            Console.WriteLine("Enter new user's favorite number:");
            string favenum = Console.ReadLine();
            DbConnector.Execute("INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES('"+fn+"', '"+ln+"', '"+favenum+"')");
            DbConnector.Read();
        }

        public static void Update(){
            Console.WriteLine("Enter the User ID of the user you'd like to update:");
            string id = Console.ReadLine();
            int updateID = Int32.Parse(id);
            System.Console.WriteLine("New First Name:");
            string nfn = Console.ReadLine();
            System.Console.WriteLine("New Last Name:");
            string nln = Console.ReadLine();
            System.Console.WriteLine("New Favorite Number:");
            string nfavenum = Console.ReadLine();
            DbConnector.Execute("UPDATE users SET FirstName = '"+nfn+"', LastName = '"+nln+"', FavoriteNumber = '"+nfavenum+"' WHERE idusers = '"+updateID+"'");
            DbConnector.Read();
        }

        public static void Delete(){
            Console.WriteLine("Enter the User ID of the user you'd like to delete from the database:");
            string id = Console.ReadLine();
            int deleteID = Int32.Parse(id);
            List<Dictionary<string,object>> sucker = DbConnector.Query("SELECT * FROM users WHERE idusers = '"+deleteID+"'");
            Console.WriteLine("Are you sure you want to delete "+sucker[0]["FirstName"]+" "+sucker[0]["LastName"]+" from the database? y/n");
            string wannaDelete = Console.ReadLine();
            bool stop = true;
            while (stop){
                if (wannaDelete == "y"){
                    DbConnector.Execute("DELETE FROM users WHERE idusers = '"+deleteID+"'");
                    DbConnector.Read();
                    stop = false;
                }
                else if (wannaDelete == "n"){
                    DbConnector.Read();
                    stop = false;
                }
                else{
                    wannaDelete = Console.ReadLine();
                }
               
            }
        }
    }
}
