using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;

namespace SOOSite.Services
{
    public class ModuleEditorService: IModuleEditorService
    {
        private IModuleEditorRepository _repo;

        public ModuleEditorService(IModuleEditorRepository repo)
        {
            _repo = repo;
        }

        public ModuleEditorVM CreateModuleEditorVM()
        {
            ModuleEditorVM vm = new ModuleEditorVM();


            return vm;
        }

    }
}
