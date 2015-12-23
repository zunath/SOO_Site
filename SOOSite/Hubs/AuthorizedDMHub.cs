using Microsoft.AspNet.SignalR;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;
using System.Collections.Generic;

namespace SOOSite.Hubs
{
    public class AuthorizedDMHub : Hub
    {
        private IAuthorizedDMService _authDMService;

        public AuthorizedDMHub(IAuthorizedDMService authDMService)
        {
            _authDMService = authDMService;
        }

        public AuthorizedDMVM InitializeVM()
        {
            return _authDMService.CreateAuthorizedDMViewModel();
        }

        public void SaveChanges(IEnumerable<AuthorizedDM> dms)
        {
            dms = _authDMService.SaveChanges(dms);

            Clients.Others.refreshDMList(dms, false);
            Clients.Caller.refreshDMList(dms, true);
        }
    }
}