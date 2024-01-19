using API_PhucLongOnline.Data;
using API_PhucLongOnline.Interface;
using API_PhucLongOnline.Repository;
using API1.VnPay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PhucLongOnlineContext>();
builder.Services.AddTransient<IQuanLiRepository, QuanLiRepository>();
builder.Services.AddTransient<IDatHangRepository, DatHangRepository>();
builder.Services.AddSingleton<IVnPayServices, VnPayService>();
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
