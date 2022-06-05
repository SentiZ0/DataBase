using DataBase.Models;

namespace DataBase.Services.Interfaces
{
    public interface IPersonService
    {
        public void AddEntry(Person person);

        public List<Person> GetAllEntries();

        public List<Person> GetEntriesFromToday();
    }
}
