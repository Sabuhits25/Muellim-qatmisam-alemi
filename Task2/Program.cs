
using Task2.Model;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IPersonService, PersonService>();


            builder.Services.AddDirectoryBrowser();


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Persons.AddRange(
                    new Person { Id = 1, Firstname = "John", Lastname = "Doe", Age = 30 },
                    new Person { Id = 2, Firstname = "Jane", Lastname = "Smith", Age = 25 }
                );
                dbContext.SaveChanges();
            }

            app.Run();
        }
    }
}
