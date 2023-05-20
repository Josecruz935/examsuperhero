using System;
using superheores.models;

namespace superheores.Service
{
    public class genderService: IgenderService
    {
        context context;
        public genderService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(gender newgender)
        {
            newgender.id = Guid.NewGuid();
            await context.AddAsync<gender>(newgender);
            await context.SaveChangesAsync();
        }

        public IEnumerable<gender> Get()
        {
            return context.gender;
        }

        public async Task Update(Guid id, gender updgender)
        {
            var gender = context.gender.Find(id);
            if (gender != null)
            {
                gender gender_name = updgender.gender_name;
                context.Update(gender);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var gender = context.gender.Find(id);
            if (gender!= null)
            {
                context.Remove(gender);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IgenderService
{
    Task CreateAsync(gender newgender);
    IEnumerable<gender> Get();
    Task Update(Guid id, gender updgender);
    Task Delete(Guid id);
}