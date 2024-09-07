using Microsoft.EntityFrameworkCore;
using RiraTask.Data;
using RiraTask.Dto;
using RiraTask.Entities;

namespace RiraTask.Repos
{
   
    public class PersonBusiness : IPersonRepo
    {
        private readonly AppDbContext appDb;

        public PersonBusiness(AppDbContext appDb)
        {
            this.appDb = appDb;
        }
        public async Task<Person> Create(AddPersonDto Person, CancellationToken cancellationToken)
        {
            var result = appDb.People.Add((Person)Person);
            await appDb.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var person = await appDb.People.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
            var result = appDb.People.Remove(person);
            await appDb.SaveChangesAsync(cancellationToken);
            return result != null ? true : false;
        }

        public async Task<Person> Get(int id, CancellationToken cancellationToken)
        {
            return await appDb.People.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Person> Update(Person Person, CancellationToken cancellationToken)
        {
            var result = appDb.People.Update(Person);
            await appDb.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }
    }
}
