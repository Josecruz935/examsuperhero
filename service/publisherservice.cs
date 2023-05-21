using System;
using superheores.models;

namespace superheores.Service
{
    public class publisherService : IpublisherService
    {
        context context;
        public publisherService(context _context)
        {
            context = _context;
        }

        //CRUD
        public async Task CreateAsync(publisher newpublisher)
        {
            newpublisher.id = Guid.NewGuid();
            await context.AddAsync<publisher>(newpublisher);
            await context.SaveChangesAsync();
        }

        public IEnumerable<publisher> Get()
        {
            return context.publisher;
        }

        public async Task Update(Guid id, publisher updpublisher)
        {
            var publisher = context.publisher.Find(id);
            if (publisher != null)
            {
                publisher.publisher_name = updpublisher.publisher_name;
                context.Update(publisher);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var publisher = context.publisher.Find(id);
            if (publisher!= null)
            {
                context.Remove(publisher);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IpublisherService
{
    Task CreateAsync(publisher newpublisher);
    IEnumerable<publisher> Get();
    Task Update(Guid id, publisher upd);
    Task Delete(Guid id);
}