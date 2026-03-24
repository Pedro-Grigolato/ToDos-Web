using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Models;

namespace ToDoPlatform.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region ROLES
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = "ROLE_ADMIN_ID",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = "ROLE_USER_ID",
                Name = "Usuario",
                NormalizedName = "USUARIO"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region USERS
        List<AppUser> users = new()
        {
            new AppUser()
            {
                Id = "USER_PEDRO_ID",
                Name = "Pedro Henrique Antunes",
                UserName = "pedroantunes480@gmail.com",
                NormalizedUserName = "PEDROANTUNES480@GMAIL.COM",
                Email = "pedroantunes480@gmail.com",
                NormalizedEmail = "PEDROANTUNES480@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ProfilePicture = "https://wallpapers.com/images/featured-full/foto-de-perfil-legal-2we7xmn0737hqgtu.jpg"
            }
        };

        var hasher = new PasswordHasher<AppUser>();

        foreach (var user in users)
        {
            user.PasswordHash = hasher.HashPassword(user, "123456");
        }

        builder.Entity<AppUser>().HasData(users);
        #endregion

        #region USER ROLES
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = "USER_PEDRO_ID",
                RoleId = "ROLE_ADMIN_ID"
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region TODOS
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Estudar matemática",
                Description = "Introdução à matemática básica",
                UserId = "USER_PEDRO_ID"
            },
            new ToDo()
            {
                Id = 2,
                Title = "Estudar português",
                Description = "Literatura clássica",
                UserId = "USER_PEDRO_ID"
            },
            new ToDo()
            {
                Id = 3,
                Title = "Estudar biologia",
                Description = "Teoria da evolução",
                UserId = "USER_PEDRO_ID"
            }
        };

        builder.Entity<ToDo>().HasData(toDos);
        #endregion
    }
}