using SOOSite.Data.Entities;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Repositories
{
    public interface IAuthorizedDMRepository
    {
        IEnumerable<AuthorizedDM> GetActiveAuthorizedDMs();
        IEnumerable<DMRoleDomain> GetActiveDMRoles();
    }
}
