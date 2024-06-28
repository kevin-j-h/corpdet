using Employees.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.data
{
    public class applicationdbcontext: DbContext
    {
        public applicationdbcontext(DbContextOptions<applicationdbcontext> options): base(options)
        {
        }

        public DbSet<employees> emps{ get; set; }


    }
}
