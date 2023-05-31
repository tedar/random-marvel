var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { 
    options.EnableAnnotations();
});
builder.Services.AddTransient<IBioManager, BioManager>();
builder.Services.AddTransient<ITranslatedRandomBio, TranslatedRandomBio>();
builder.Services.AddTransient<ITranslatorManager, TranslatorManager>();
builder.Services.AddHttpClient<BioManager>();
builder.Services.AddAutoMapper(typeof(Mappings));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
