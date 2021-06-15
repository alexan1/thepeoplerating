using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using thepeoplerating.Components;
using WikiDataLib;

namespace thepeoplerating.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }
        string _searchName;

        private Collection<WikiPerson> People { get; set; }
        private Collection<PersonR> PeopleR { get; set; } = new Collection<PersonR>();


        private async Task SearchPeople()
        {            
            People = await WikiData.WikiPeopleSearch(_searchName);
            const string linkbase = "https://peoplerating.azurewebsites.net/api/rating/";

            foreach (var pers in People)
            {                
                var link = linkbase + pers.Id.ToString();                
                Console.WriteLine("link  " + link);
                var rating = await Http.GetFromJsonAsync<Components.Rating>(link);
                var averagerate = rating.AverageRate;
                Console.WriteLine("rating  " + averagerate);

                PeopleR.Add(new PersonR(pers, averagerate));
            }
        }
    }
}
