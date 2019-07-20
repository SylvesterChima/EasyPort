using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyPort.Data;
using EasyPort.Models.Abstract;
using EasyPort.Models.Contract;
using EasyPort.ObjectMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace EasyPort.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void IntallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ISalesMasterRepository, EFSalesMasterRepository>();
            services.AddScoped<ISalesItemRepository, EFSalesItemRepository>();
            services.AddScoped<ICompanyRepository, EFCompanyRepository>();
            services.AddScoped<IAspNetUserRepository, EFAspNetUserRepository>();
            services.AddScoped<IDailySalesRepository, EFDailySalesRepository>();
            services.AddScoped<IIncomeExpensesRepository, EFIncomeExpensesRepositroy>();

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFiles")));

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                //By default the below will be set to whatever the server culture is. 
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-GB") };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            var config = new MapperConfiguration(c => c.AddProfile(new AppliccationProfile()));
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
