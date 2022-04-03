#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBase.Data;
using DataBase.Models;

namespace DataBase.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly DataBase.Data.PeopleContext _context;

        public IndexModel(DataBase.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.OrderByDescending(a => a.DataUpdateTime).Take(20).ToListAsync();
        }
    }
}
