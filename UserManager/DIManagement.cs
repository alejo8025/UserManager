using Microsoft.Extensions.DependencyInjection;
using UserManager.Domain.Auth;
using UserManager.Domain.DocumentType;
using UserManager.Domain.Login;
using UserManager.Domain.Rol;
using UserManager.Domain.User;
using UserManager.Infrastructure.Auth;
using UserManager.Infrastructure.Repositories.DocumentType;
using UserManager.Infrastructure.Repositories.Login;
using UserManager.Infrastructure.Repositories.Rol;
using UserManager.Infrastructure.Repositories.User;
using UserManager.Model.Common;

namespace UserManager.Web
{
    public static class DIManagement
    {
        public static void UseDependecys(this IServiceCollection services)
        {
            services.AddSingleton<AppSettingGlobal>();
            services.AddScoped<IAuth, AuthRepository>();
            services.AddScoped<ILoginRepo, LoginRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IRol, RolRepository>();
            services.AddScoped<IDocumentType, DocumentTypeRepository>();
        }
    }
}
