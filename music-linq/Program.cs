using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            //Who is the youngest artist in our collection of artists?

            //Display all artists with 'William' somewhere in their real name

            //Display the 3 oldest artist from Atlanta

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            IEnumerable<Artist> mountVernon =
                from town in Artists
                where town.Hometown == "Mount Vernon"
                orderby town
                select town;

            foreach (Artist info in mountVernon){

                Console.WriteLine("The artist from Mount Vernon is "+info.ArtistName +", and he is "+ info.Age+" years old.");
            }
            // IEnumerable<Artist> youngest = 
            //     from age in Artists
            //     orderby age.Age
            //     select age;

            // foreach (Artist info in youngest){
            //     Console.WriteLine(info.ArtistName + ", " + info.Age + " years old.");

            // }
            // Console.WriteLine(youngest.Age);
            Artist youngest = Artists.OrderBy(young => young.Age).First();
            Console.WriteLine("The youngest artist is "+youngest.ArtistName+", who is "+youngest.Age+" years old.");

            List<Artist> williams = Artists.Where(name => name.RealName.Contains("William")).ToList();
            Console.WriteLine("The artists with William in their real name are:");
            foreach (Artist william in williams){
                Console.WriteLine(william.ArtistName+" : "+william.RealName);
            }

            List<Group> LessThan8 = Groups.Where(name => name.GroupName.Length < 8).ToList();
            Console.WriteLine("The groups with names that have less than 8 characters are:");
            foreach (Group group in LessThan8){
                Console.WriteLine(group.GroupName);
            }

            List<Artist> oldestATL = Artists.Where(old => old.Hometown == "Atlanta").ToList().OrderByDescending(artist =>artist.Age).ToList();
            Console.WriteLine("The oldest artists from Atlanta are:");
            Console.WriteLine(oldestATL[0].ArtistName);
            Console.WriteLine(oldestATL[1].ArtistName);
            Console.WriteLine(oldestATL[2].ArtistName);
        }
    }
}
