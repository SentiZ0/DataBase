using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DataBase.Data;

namespace DataBase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PeopleContext _context;

        public IList<Person> People { get; set; }

        public string AlertMessage { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public IndexModel(PeopleContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            var dataList = new List<Person>();

            var sessionData = HttpContext.Session.GetString("Data");
            if (!string.IsNullOrEmpty(sessionData))
            {
                dataList = JsonConvert.DeserializeObject<List<Person>>(sessionData);
            }

            dataList.Add(Person);

            Person.CheckLeapYear();
            Person.DataUpdateTime = DateTime.Now;

            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(dataList));

            _context.Person.Add(Person);
            _context.SaveChanges();

            if (!ModelState.IsValid)
            {
                if(Person.LastName == null)
                {
                    AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                }
                else
                {
                    AlertMessage = $"Wprowadzono niepoprawne dane. {Person.DataUpdateTime}";
                }              
                return Page();
            }
            else
            {
                AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                return Page();
            }

        }
        public void OnGet()
        {            
            People = _context.Person.ToList();
        }
    }
}