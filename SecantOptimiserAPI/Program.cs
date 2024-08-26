using SecantOptimiserAPI;
using SecantOptimiserAPI.Models;
using SecantWrapper;
using System.Reflection;
using System.Text;

AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    if (e != null)
    {
        Exception exp = (Exception)e.ExceptionObject;
        WriteLog(exp);
    }
}



void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
{
    WriteLog(e.Exception);
}



void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
{
    foreach (var exp in ((AggregateException)e.Exception).InnerExceptions)
    {
        WriteLog(exp);
    }
}

void WriteLog(Exception exp)
{
    try
    {
        StringBuilder builder1 = new StringBuilder();
        if (exp != null)
        {
            builder1.AppendLine(exp.Message);
            Exception? innerExp = exp.InnerException;
            while (innerExp != null)
            {
                builder1.AppendLine(innerExp.Message);
                innerExp = innerExp.InnerException;
            }
            using (System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(builder1.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
    catch { }
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapPost("/optimise", (RequestModel inputModel) =>
{
    var executingAsmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location ?? Environment.CurrentDirectory)
        .Replace("\\", "/").TrimEnd('/') + "/";
    //NativeMethods.Optimise(IntPtr.Zero, executingAsmDir, "Test", executingAsmDir, 101, IntPtr.Zero);

    //var tempDir = Path.Combine(Path.GetTempPath(), "EpicorSecant\\").Replace("\\", "/");
    string tempDir = Directory.GetCurrentDirectory() + @"\EpicorSecant\";
    if(!Directory.Exists(tempDir))
    {
        Directory.CreateDirectory(tempDir);
    }
    //Directory.CreateDirectory(tempDir);
    var tempFile = Path.Combine(tempDir, Guid.NewGuid().ToString("N") + ".sec");
    OptimiserRequest request = new OptimiserRequest();
    var secFile = request.ToSecFile(inputModel);
    
    secFile.WriteToFile(tempFile);
    var success = InvokeSecant.Call(tempDir, Path.GetFileNameWithoutExtension(tempFile));
    //var success = NativeMethods.Optimise(IntPtr.Zero, tempDir.TrimEnd('\\', '/') + '/', Path.GetFileNameWithoutExtension(tempFile), "./Secant/", 101, IntPtr.Zero);
    if (success)
    {
        secFile = SecFile.ReadFromFile(tempFile);
        //if (File.Exists(tempFile))
        //{
        //    File.Delete(tempFile);
        //}
        return new OptimiserResponse(secFile);
    }
    else
    {
        if (File.Exists(tempFile))
        {
            File.Delete(tempFile);
        }
        return null;
    }
}).WithName("Optimise")
.WithOpenApi();


await app.RunAsync();

