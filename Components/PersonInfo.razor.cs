using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace thepeoplerating.Components
{
    public partial class PersonInfo : ComponentBase
    {
        [Parameter]
        public PersonR Person { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        public async System.Threading.Tasks.Task RateAsync(int personId, int value)
        {
            const string userId = "anonymous";
            var rating = new { PersonID = personId, UserID = userId, Rate = value };
            const string link = "https://peoplerating.azurewebsites.net/api/rating/";

            await Http.PutAsJsonAsync(link, rating);

        }
    }
}
