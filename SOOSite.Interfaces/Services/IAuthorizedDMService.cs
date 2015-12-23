using SOOSite.Data.Entities;
using SOOSite.Models.ViewModels;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Services
{
    public interface IAuthorizedDMService
    {
        AuthorizedDMVM CreateAuthorizedDMViewModel();
        IEnumerable<AuthorizedDM> SaveChanges(IEnumerable<AuthorizedDM> dms);
    }
}
