using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using service.DataBase;
using Service.Models;

namespace Service.Endpoints
{
    public static class UsersEndpoints
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            //get users list
            app.MapGet("/users", async (DataContext db) =>
                await db.Users.ToListAsync());
            //add new user
            app.MapPost("/users/add", async (DataContext db, UsersModel User) =>
            {
                db.Users.Add(User);
                await db.SaveChangesAsync();
                return Results.Created($"/users/{User.Id}", User);
            });
            //search for user
            app.MapGet("users/{id}", async (DataContext db, int id) =>
                {
                    await db.Users.FindAsync(id);
                }
            );
            //update user
            app.MapPut("users/update/{id}", async (DataContext db, UsersModel inputUser, int id) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                user.FirstName = inputUser.FirstName;
                user.LastName = inputUser.LastName;
                user.PhoneNumber = inputUser.PhoneNumber;
                db.SaveChangesAsync();
                return Results.NoContent();
            });
            //delete user

            app.MapDelete("users/delete/{id}", async (DataContext db, int id) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return Results.NotFound();
                }

                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
