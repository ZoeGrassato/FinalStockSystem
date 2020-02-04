using FinalSystem.Data;
using FinalSystem.Generics;
using FinalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Repositories
{
    public class EventRepository : GenericRepository<EventModel>, IEventRepository
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
