var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var plants = new List<Plant>();

app.MapGet("/plants", () => plants);
app.MapGet("/plants/{id}", (int id) => plants.FirstOrDefault(p => p.Id == id));
app.MapPost("/plants", (Plant plant) => 
{
    plant.Id = plants.Count + 1;
    plants.Add(plant);
    return Results.Created($"/plants/{plant.Id}", plant);
});

app.Run()