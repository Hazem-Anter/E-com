
namespace Ecom.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Database Context Configuration
            //var connectionString = builder.Configuration.GetConnectionString("TemplateConnection");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            // In-Memory database for testing and development
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MyDB"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Modular DAL and BLL Services
            builder.Services.AddBusinessInDAL();
            builder.Services.AddBusinessInBLL();

            // Add CORS Policy
            var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins(allowedOrigins);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use CORS Middleware
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


            //// Seeding initial data
            //using (var scope = app.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    context.Database.EnsureCreated();

            //    if (!context.Departments.Any() && !context.Employees.Any())
            //    {
            //        var hr = new Department("HR", "Cairo", "Fady");
            //        var it = new Department("IT", "Alex", "Ahmed");

            //        context.Departments.AddRange(hr, it);
            //        context.SaveChanges();

            //        context.Employees.AddRange(
            //        new Employee("Fady", 20000, 30, "testpic.png", hr.Id, "Admin"),
            //        new Employee("Ahmed", 46000, 28, "testpic2.JPG", it.Id, "Admin2"),
            //        new Employee("Sara", 88000, 26, "testpic.png", hr.Id, "Admin")
            //        );
            //        context.SaveChanges();
            //    }
            //}

            app.Run();
        }
    }
}
