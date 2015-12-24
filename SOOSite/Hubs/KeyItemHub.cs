using Microsoft.AspNet.SignalR;
using SOOSite.Interfaces.Services;
using SOOSite.Models.BusinessObjects;
using SOOSite.Models.ViewModels;
using System.Collections.Generic;

namespace SOOSite.Hubs
{
    public class KeyItemHub: Hub
    {
        private IKeyItemService _service;

        public KeyItemHub(IKeyItemService service)
        {
            _service = service;
        }

        public KeyItemVM InitializeVM()
        {
            return _service.CreateKeyItemViewModel();
        }

        public void SaveChanges(IEnumerable<KeyItemCategoryBO> categories, 
            IEnumerable<KeyItemBO> keyItems)
        {
            var results = _service.SaveChanges(categories, keyItems);
            categories = results.Item1;
            keyItems = results.Item2;

            Clients.Others.refreshModel(categories, keyItems, false);
            Clients.Caller.refreshModel(categories, keyItems, true);
        }
    }
}