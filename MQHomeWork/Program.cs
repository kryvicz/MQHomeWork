var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string filePath = builder.Configuration["db"];
builder.Services.AddTransient<MQHomeWork.DB.Repository>();
builder.Services.AddSingleton<MQHomeWork.DB.Database>(new MQHomeWork.DB.Parser(
            new MQHomeWork.DB.FileLoader(filePath).Load()
        ).Parse());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.Run();
