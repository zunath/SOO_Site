using Microsoft.AspNet.SignalR;
using SOOSite.Common.GFFParser;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;

namespace SOOSite.Hubs
{
    public class ModuleEditorHub: Hub
    {
        private readonly IModuleEditorService _service;
        private readonly ModuleReader _moduleReader;

        public ModuleEditorHub(IModuleEditorService service,
            ModuleReader moduleReader)
        {
            _service = service;
            _moduleReader = moduleReader;
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