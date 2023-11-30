using BECapstone.Models;
using BECapstone;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7149") // Change to match your SWAGGER Url *****
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
// CHANGE THE "DBCONTEXT" and "DBConnectionString" ******* DELETE THIS LINE AFTERWARDS *******
builder.Services.AddNpgsql<BEDbContext>(builder.Configuration["BEDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();
//Add for Cors
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENDPOINTS 

//USER
//  check user
app.MapGet("/checkuser/{uid}", (BEDbContext db, string uid) =>
{
    var user = db.Users.Where(x => x.uid == uid)
    .Include(u => u.Class)
    .Include(u => u.Events)
    .FirstOrDefault();
    if (user == null)
    {
        return Results.NotFound();
    }
        return Results.Ok(user);
});
// get all users
app.MapGet("/users", (BEDbContext db) =>
{
    return db.Users.ToList();
});
// get user by Id
app.MapGet("/users/{id}", (BEDbContext db, int id) =>
{
    var user = db.Users.Where(u => u.Id == id)
    .Include(u => u.Class)
    .Include(u => u.Events)
    .FirstOrDefault(); ;
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});
//create User 
app.MapPost("/users", (BEDbContext db, User User) =>
{
    db.Users.Add(User);
    db.SaveChanges();
    return Results.Created($"/user/{User.Id}", User);
});
// update a user
app.MapPut("/users/{id}", (int id, BEDbContext db, User User) =>
{
    User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    userToUpdate.Name = User.Name;
    userToUpdate.Email = User.Email;
    db.SaveChanges();
    return Results.Ok(userToUpdate);
});
// delete a user
app.MapDelete("/users/{id}", (BEDbContext db, int id) =>
{
    User userToDelete = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToDelete == null)
    {
        return Results.NotFound();
    }
    db.Users.Remove(userToDelete);
    db.SaveChanges();
    return Results.NoContent();
});
// events a user has signed up for 
app.MapGet("/userEvents/{uid}", async (BEDbContext db, string uid) =>
{
    var userEvents = await db.Events
        .Where(e => e.Users.Any(u => u.uid == uid))
        .Include(e => e.Users)
        .Include(e => e.Class)
        .Include(e => e.StartTime)
        .Include(e => e.EndTime)
        .Include(e => e.PlayType)
        .ToListAsync();

    return Results.Ok(userEvents);
});
// add a Class to a User 
app.MapPost("/classUser/{classId}/{userId}", (int classId, int userId, BEDbContext db) =>
{
    var classToAdd = db.Class.Include(c => c.Users).FirstOrDefault(c => c.Id == classId);

    if (classToAdd == null)
    {
        return Results.NotFound();
    }

    var userToAdd = db.Users.FirstOrDefault(u => u.Id == userId);

    if (userToAdd == null)
    {
        return Results.NotFound();
    }

    classToAdd.Users.Add(userToAdd);
    db.SaveChanges();

    return Results.Ok();
});
// delete a class from an user
app.MapDelete("/userClass/{userId}/{classId}", (int userId, int classId, BEDbContext db) =>
{
    var classToDelete = db.Class.Include(c => c.Users).FirstOrDefault(c => c.Id == classId);

    if (classToDelete == null)
    {
        return Results.NotFound();
    }

    var userToRemove = db.Users.FirstOrDefault(u => u.Id == userId);

    if (userToRemove == null)
    {
        return Results.NotFound();
    }

    classToDelete.Users.Remove(userToRemove);
    db.SaveChanges();

    return Results.Ok("Class removed from Event successfully");
});
//  EVENT ENDPOINTS
// get users on a event 
app.MapGet("/eventUser/{id}", (BEDbContext db, int id) =>
{
    var eventUsersToGet = db.Events.Where(e => e.Id == id)
    .Include(e => e.Class)
    .Include(e => e.StartTime)
    .Include(e => e.EndTime)
    .Include(e => e.PlayType)
    .Include(u => u.Users).ToList();
    return eventUsersToGet;
});
// get events that a user created 
app.MapGet("/createdEventUser/{uid}", (BEDbContext db, string uid) =>
{
    var createdEvents = db.Events.Where(e => e.uid == uid)
    .Include(e => e.Class)
    .Include (e => e.StartTime)
    .Include(e => e.EndTime)
    .Include(e => e.PlayType)
    .ToList();
    return createdEvents;
});
// add a user to a event 
app.MapPost("/eventUser/{userId}/{eventId}", (int userId, int eventId, BEDbContext db) =>
{
    var user = db.Users.Include(u => u.Events).FirstOrDefault(u => u.Id == userId);

    if (user == null)
    {
        return Results.NotFound();
    }

    var eventToAdd = db.Events.FirstOrDefault(e => e.Id == eventId);

    if (eventToAdd == null)
    {
        return Results.NotFound();
    }

    user.Events.Add(eventToAdd);
    db.SaveChanges();

    return Results.Ok();
});
// add a Class to a event 
app.MapPost("/eventClass/{classId}/{eventId}", (int classId, int eventId, BEDbContext db) =>
{
    var classToAdd = db.Class.Include(c => c.Events).FirstOrDefault(c => c.Id == classId);

    if (classToAdd == null)
    {
        return Results.NotFound();
    }

    var eventToAdd = db.Events.FirstOrDefault(e => e.Id == eventId);

    if (eventToAdd == null)
    {
        return Results.NotFound();
    }

    classToAdd.Events.Add(eventToAdd);
    db.SaveChanges();

    return Results.Ok();
});
// delete a Class from an event
app.MapDelete("/eventClass/{eventId}/{classId}", (int eventId, int classId, BEDbContext db) =>
{
    var classToDelete = db.Class.Include(c => c.Events).FirstOrDefault(c => c.Id == classId);

    if (classToDelete == null)
    {
        return Results.NotFound();
    }

    var eventToRemove = db.Events.FirstOrDefault(e => e.Id == eventId);

    if (eventToRemove == null)
    {
        return Results.NotFound();
    }

    classToDelete.Events.Remove(eventToRemove);
    db.SaveChanges();

    return Results.Ok("Class removed from Event successfully");
});
// get Events
app.MapGet("/events", async (BEDbContext db) =>
{
    var events = await db.Events
    .Include(e => e.Users)
    .Include(e => e.Class)
    .Include(e => e.StartTime)
    .Include(e => e.EndTime)
    .Include(e => e.PlayType)
    .ToListAsync();

    return Results.Ok(events);
});
// get events by id
app.MapGet("/events/{id}", (BEDbContext db, int id) =>
{
    var events = db.Events.Where(e => e.Id == id)
    .Include(e => e.Users)
    .ThenInclude(u => u.Class)
    .Include(e => e.Class)
    .Include(e => e.StartTime)
    .Include(e => e.EndTime)
    .Include(e => e.PlayType)
    .FirstOrDefault();
    if (events == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(events);
});
//update a Event
app.MapPut("/events/{id}", (int id, BEDbContext db, Events Event) =>
{
    Events eventToUpdate = db.Events.SingleOrDefault(o => o.Id == id);
    if (eventToUpdate == null)
    {
        return Results.NotFound();
    }
    eventToUpdate.Name = Event.Name;
    eventToUpdate.StartTimeId = Event.StartTimeId;
    eventToUpdate.EndTimeId = Event.EndTimeId;
    eventToUpdate.PlayTypeId = Event.PlayTypeId;
    db.SaveChanges();
    return Results.Ok(eventToUpdate);
});
// Create a Event
app.MapPost("/events", (BEDbContext db, Events Event) =>
{
    db.Events.Add(Event);
    db.SaveChanges();
    return Results.Created($"/events/{Event.Id}", Event);
});
//delete a Event 
app.MapDelete("/events/{id}", (BEDbContext db, int id) =>
{
    Events eventToDelete = db.Events.SingleOrDefault(e => e.Id == id);
    if (eventToDelete == null)
    {
        return Results.NotFound();
    }
    db.Events.Remove(eventToDelete);
    db.SaveChanges();
    return Results.NoContent();
});
// delete a user from an event
app.MapDelete("/eventUser/{eventId}/{userId}", (int eventId, int userId, BEDbContext db) =>
{
    var user = db.Users.Include(u => u.Events).FirstOrDefault(u => u.Id == userId);

    if (user == null)
    {
        return Results.NotFound();
    }

    var eventToRemove = db.Events.FirstOrDefault(e => e.Id == eventId);

    if (eventToRemove == null)
    {
        return Results.NotFound();
    }

    user.Events.Remove(eventToRemove);
    db.SaveChanges();

    return Results.Ok("User removed from Event successfully");
});
// Misc Endpoint 
//  get all PlayTypes
app.MapGet("/playType", (BEDbContext db) =>
{
    return db.PlayTypes.ToList();
});
// get all time slots
app.MapGet("/timeSlots", (BEDbContext db) =>
{
    return db.TimeSlots.ToList();
});
// get all classes 
app.MapGet("/class", (BEDbContext db) =>
{
    return db.Class.ToList();
});
app.Run();
