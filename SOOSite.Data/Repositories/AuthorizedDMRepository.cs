using SOOSite.Data.Contexts;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SOOSite.Data.Repositories
{
    public class AuthorizedDMRepository: IAuthorizedDMRepository
    {
        private SOOContext _context;

        public AuthorizedDMRepository(SOOContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthorizedDM> GetActiveAuthorizedDMs()
        {
            return _context.AuthorizedDMs.Where(x => x.IsActive);
        }

        public IEnumerable<DMRoleDomain> GetActiveDMRoles()
        {
            return _context.DMRoleDomains.ToList();
        }
    }
}
