using SOOSite.Data.Entities;
using System.Collections.Generic;

namespace SOOSite.Models.ViewModels
{
    public class AuthorizedDMVM
    {
        public List<DMRoleDomain> AvailableRoles { get; set; }
        public List<AuthorizedDM> AuthorizedDMs { get; set; }
    }
}
