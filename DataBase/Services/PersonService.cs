using DataBase.Services.Interfaces;
using DataBase.Models;
using DataBase.Data;

namespace DataBase.Services
{
    public class PersonService : IPersonService
    {
        private readonly PeopleContext _context;

        public PersonService(PeopleContext context)
        {
            _context = context;
        }

        public void AddEntry(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> GetAllEntries()
        {
            return _context.Person.OrderBy(a=>a.DataUpdateTime).ToList();
        }

        public List<Person> GetEntriesFromToday()
        {
            return _context.Person.Where(p => p.DataUpdateTime.Date == DateTime.Now.Date).ToList();
        }
    }
}
