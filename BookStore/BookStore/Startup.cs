using BookStore.BLL.Interfaces;
using BookStore.BLL.Mapper;
using BookStore.BLL.Models.Authentication;
using BookStore.BLL.Queries.Book;
using BookStore.BLL.Services;
using BookStore.DAL;
using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using BookStore.Profiles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtOptions>(Configuration.GetSection("Jwt"));
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddEndpointsApiExplorer();
            services.AddDbContext<BookStoreContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString("Database"))
            );
            services.AddIdentity<User,IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<BookStoreContext>();
            services.AddScoped<IBookStoreUW, BookStoreUW>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserService, UserService>();
            services.AddMediatR(typeof(Startup).Assembly, typeof(GetAllBooksQuery).Assembly);
            services.AddAutoMapper(typeof(BookProfile).Assembly ,typeof(LanguageModelProfile).Assembly);
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
