using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PARC_Web_App.Areas.Identity.Data;

namespace PARC_Web_App.Data;

public class PARC_Web_AppContext : IdentityDbContext<PARC_Web_AppUser>
{
    public PARC_Web_AppContext(DbContextOptions<PARC_Web_AppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<PARC_Web_AppUser>()
            .Property(u => u.RegistrationNumber)
            .HasColumnName("RegistrationNumber");
    }
}
