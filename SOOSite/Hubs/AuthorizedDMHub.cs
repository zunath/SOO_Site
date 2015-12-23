using Microsoft.AspNet.SignalR;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;

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

    }
}