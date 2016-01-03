using SOOSite.Data.Contexts;
using SOOSite.Interfaces.Repositories;

namespace SOOSite.Data.Repositories
{
    public class ModuleEditorRepository: IModuleEditorRepository
    {
        private readonly SOOContext _context;

        public ModuleEditorRepository(SOOContext context)
        {
            _context = context;
        }



    }
}
