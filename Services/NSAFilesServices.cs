using ACDC2019SpiderpigsCovertOPs.Database;

namespace ACDC2019SpiderpigsCovertOPs.Services
{
    #pragma warning disable 1591
    public interface INSAFilesServices
    {
        
    }

    public class NSAFilesServices : INSAFilesServices
    {
        private readonly CovertOPsContext _context;
        
        public NSAFilesServices(CovertOPsContext context)
        {
            _context = context;
        }        
    }
}