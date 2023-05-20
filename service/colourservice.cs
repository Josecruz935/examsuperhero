using System;
using superheores.models;

namespace superheores.Service
{
    public class colourService : IcolourService
    {
        context context;
        public colourService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(colour newColour)
        {
            newColour.id = Guid.NewGuid();
            await context.AddAsync<colour>(newColour);
            await context.SaveChangesAsync();
        }

        public IEnumerable<colour> Get()
        {
            return context.colour;
        }

        public async Task Update(Guid id, colour updcolour)
        {
            var colour = context.colour.Find(id);
            if (colour != null)
            {
                colour.colour_name = updcolour.colour_name;
                context.Update(colour);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var colour = context.colour.Find(id);
            if (colour!= null)
            {
                context.Remove(colour);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IcolourService
{
    Task CreateAsync(colour newcolour);
    IEnumerable<colour> Get();
    Task Update(Guid id, colour updcolour);
    Task Delete(Guid id);
}