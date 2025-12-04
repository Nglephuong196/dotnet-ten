using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ononlaw_api.Models;

namespace ononlaw_api.Data
{
    public class OnOnDbContext : IdentityDbContext<User>
    {
        public OnOnDbContext(DbContextOptions<OnOnDbContext> options) : base(options)
        {

        }
    }
}
