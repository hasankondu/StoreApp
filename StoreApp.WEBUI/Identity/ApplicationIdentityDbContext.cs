using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Identity
{

    // dotnet ef migrations remove --context StoreApp.WEBUI.Identity.ApplicationIdentityDbContext
    // dotnet ef migrations add AddingIdentity --context StoreApp.WEBUI.Identity.ApplicationIdentityDbContext
    // dotnet ef database update --context StoreApp.WEBUI.Identity.ApplicationIdentityDbContext
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options):base(options)
        {

        }
    }
}
