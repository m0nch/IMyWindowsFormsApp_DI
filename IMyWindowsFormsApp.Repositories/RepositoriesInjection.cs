using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    public static class RepositoriesInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<ITeacherRepository, TeacherRepository>();
            service.AddScoped<IAddressRepository, AddressRepository>();
            return service;
        }
    }
}
