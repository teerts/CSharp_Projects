using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PersonsFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // extension methods: only pull in namespaces of extension methods that we need
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            
            // order by ID property
            // find the max id
            int currentId = 1; 

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            currentId += 1;

            // add the new record wit the new id (max + 1)
            prizes.Add(model);

            // convert the prizes to list <string>
            // save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = PersonsFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1; 

            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            currentId += 1;

            persons.Add(model);

            persons.SaveToPersonsFile(PersonsFile);

            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PersonsFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            // two parameters into ConvertToTeamModels: the first is actually the "LoadFile()" function while 
            // the second is the persons file
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonsFile);

            // find the max id
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;

        }
    }
}
