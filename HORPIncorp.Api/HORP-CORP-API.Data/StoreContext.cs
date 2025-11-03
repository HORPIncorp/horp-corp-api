using HORPIncorp.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace HORP_CORP_API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }


        public DbSet<Item> Items { get; set; }

    }
}
