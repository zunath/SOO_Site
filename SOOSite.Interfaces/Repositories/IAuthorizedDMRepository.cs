using SOOSite.Data.Entities;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Repositories
{
    public interface IAuthorizedDMRepository
    {
        IEnumerable<AuthorizedDM> GetAuthorizedDMs();
        IEnumerable<DMRoleDomain> GetActiveDMRoles();
        IEnumerable<AuthorizedDM> SaveChanges(IEnumerable<AuthorizedDM> dms);
    }
}
