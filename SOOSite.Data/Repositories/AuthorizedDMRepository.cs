using SOOSite.Data.Contexts;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace SOOSite.Data.Repositories
{
    public class AuthorizedDMRepository: IAuthorizedDMRepository
    {
        private readonly SOOContext _context;

        public AuthorizedDMRepository(SOOContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthorizedDM> GetAuthorizedDMs()
        {
            return _context.AuthorizedDMs.ToList();
        }

        public IEnumerable<DMRoleDomain> GetActiveDMRoles()
        {
            return _context.DMRoleDomains.ToList();
        }

        public IEnumerable<AuthorizedDM> SaveChanges(IEnumerable<AuthorizedDM> dms)
        {
            _context.AuthorizedDMs.AddOrUpdate(dms.ToArray());
            _context.SaveChanges();

            return dms;
        }
    }
}
