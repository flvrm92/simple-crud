using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class DatabaseInitializer
    {
        private readonly MainDataContext _context;

        public DatabaseInitializer(MainDataContext context)
        {
            _context = context;
        }

        public async Task ApplyMigration()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
