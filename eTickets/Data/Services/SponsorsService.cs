using eTickets.Data.Base;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class SponsorsService: EntityBaseRepository<Sponsor>, ISponsorsService
    {
        public SponsorsService(AppDbContext context) : base(context)
        {
        }
    }
}
