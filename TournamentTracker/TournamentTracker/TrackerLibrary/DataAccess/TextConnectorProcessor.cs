using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

// * load the text file
// * convert the text to List<PrizeModel>
// * find the max id
// * add the new record wit the new id (max + 1)
// * convert the prizes to a list<string>
// * save the list <string> to the text file
// additional (not used here): Automapper allows for one object to be mapped to another

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        // will pre-pend app.config appsettings using configuration manager
        // 'this' becomes an extension method, so anytime there is a string that means that we are attaching 
        // to this string will bring the full path
        public static string FullFilePath(this string fileName) // PrizeModels.csv
        {
            // C:\data\TournamentTracker\PrizeModels.csv
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new Models.PrizeModel();

                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);
            }
            return output;
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new Models.PersonModel();

                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }
            return output; 
        }
        // the "this" keyword in the parameter represents a hidden parameter in this case the "LoadFile()" extension method
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string personsFile)
        {
            // id, team name, list of ids of each person separated by the pipe
            // 3, Gerry's Team, 1|3|5
            List<TeamModel> output = new List<TeamModel>();
            // gives a list of people
            List<PersonModel> persons = personsFile.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                // takes the third column and splits it with a pipe char
                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    // take the list of people in the text file and search for it through 
                    // where the id in the person in the list equals the person from current id
                    // this will blow up if First() is used and there are no ids             
                
                    t.TeamMembers.Add(persons.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(t);
            }
            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.Id }, { p.PlaceNumber }, { p.PlaceName }, {p.PrizeAmount}, { p.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPersonsFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.Id }, { p.FirstName }, { p.LastName }, { p.EmailAddress }, { p.CellphoneNumber }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                // add the team id, team name, and per each team member add their id (used helper function to do this)
                lines.Add($"{ t.Id }, { t.TeamName }, { ConvertPeopleListToString(t.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        // take list of person model and return a string instead
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            // if there are 0 people in the List and it tries to go 0 - 1 with the substring function below
            // it will crash! so need to check people count ... if 0 return empty
            if (people.Count == 0)
            {
                return "";
            }
            // 2|5|
            foreach (PersonModel p in people)
            {
                output += $"{ p.Id }|";
            }
            // remove trailing pipe
 
            output = output.Substring(0, output.Length - 1);

            return output;
        }




    }

}
