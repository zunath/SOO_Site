using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SOOSite.Services
{
    public class AuthorizedDMService: IAuthorizedDMService
    {
        private IAuthorizedDMRepository _repo;

        public AuthorizedDMService(IAuthorizedDMRepository repo)
        {
            _repo = repo;
        }
        
        public AuthorizedDMVM CreateAuthorizedDMViewModel()
        {
            AuthorizedDMVM vm = new AuthorizedDMVM
            {
                AuthorizedDMs = _repo.GetAuthorizedDMs().ToList(),
                AvailableRoles = _repo.GetActiveDMRoles().ToList()
            };

            return vm;
        }

        public IEnumerable<AuthorizedDM> SaveChanges(IEnumerable<AuthorizedDM> dms)
        {
            return _repo.SaveChanges(dms);
        }
    }
}
