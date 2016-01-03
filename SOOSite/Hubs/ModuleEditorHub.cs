using Microsoft.AspNet.SignalR;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;

namespace SOOSite.Hubs
{
    public class ModuleEditorHub: Hub
    {
        private readonly IModuleEditorService _service;

        public ModuleEditorHub(IModuleEditorService service)
        {
            _service = service;
        }

        public ModuleEditorVM InitializeVM()
        {
            return _service.CreateModuleEditorVM();
        }

        public void OpenModule()
        {
            
        }
    }
}