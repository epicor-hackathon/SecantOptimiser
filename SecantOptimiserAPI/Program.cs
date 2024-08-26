using SecantOptimiserAPI.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += EventLogger.CurrentDomain_UnhandledException;
        TaskScheduler.UnobservedTaskException += EventLogger.TaskScheduler_UnobservedTaskException;
        AppDomain.CurrentDomain.FirstChanceException += EventLogger.CurrentDomain_FirstChanceException;



        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddSecantGroup();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        await app.RunAsync();
    }
}