

using registracija2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("All", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("All");

app.MapGet("/registracijas/{id}", (int id) =>
{
    Registracijasreposetey registresanaRepository = new Registracijasreposetey(); 
    Profils profils = registresanaRepository.FindById(id); 
    return profils;
});

// GET
// Izgūt visus sludinājumus kā sarakstu no datubāzes
app.MapGet("/profils", () =>
{
    Registracijasreposetey registracijasreposetey = new Registracijasreposetey();

    List<Profils> profils = registracijasreposetey.GetAll();
     
    return profils;
});

app.MapPost("/profils", (Profils profils) =>
{
    Registracijasreposetey registracijasreposetey = new Registracijasreposetey();

    registracijasreposetey.Add(profils);
});


app.MapPost("/post", () => "Hello from POST!");

// PUT
app.MapPut("/", () => "Hello from root PUT!");
app.MapPut("/put", () => "Hello from PUT!");

// DELETE
app.MapDelete("/", () => "Hello from root DELETE!");
app.MapDelete("/delete", () => "Hello from DELETE!");

app.Run();