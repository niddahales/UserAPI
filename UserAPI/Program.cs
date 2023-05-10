using UserAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get Method
app.MapGet("/users", () =>
{
    DatabaseAction action = new DatabaseAction();
    return action.GetUsers();     
});

app.MapPost("/users", (User user) =>
{
    Validation validation = new Validation();
    if (string.IsNullOrWhiteSpace(user.Name))
        return Results.BadRequest("Name cannot be null. Try again.");
    else if (user.Password != user.ConfirmPassword)
        return Results.BadRequest("Password and Confirm Password should match. Try again.");
    else if (!validation.IsValidEmail(user.Email))
        return Results.BadRequest("Please enter valid email. Try again");
    else if (!validation.IsValidBirthday(user.Birthday))
        return Results.BadRequest("Please enter birthday as a 07/01/2000. Try again.");
    else if (!validation.IsValidAge(user.Age, user.Birthday))
        return Results.BadRequest("Please enter your age correctly. Try again.");
    else
    {
        DatabaseAction action = new DatabaseAction();
        action.AddUser(user);
        return Results.Ok("User added succesfully.");
    }
});

app.Run();

public partial class Program { };