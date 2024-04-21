namespace ASPWebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //builder.Services.AddMvcCore();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            //app.MapGet("/", () => "Hello World!");

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
