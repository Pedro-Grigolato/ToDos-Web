using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Models;

namespace ToDoPlatform.Data;

public class AppDbSeed
{
    // ctor - construção
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular dados de Perfil do usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = "91d71587-4500-4a21-bd21-0f5cc725ad2e",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = "9922eecd-404d-4b8e-88a6-6e61247f3a3c",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion
        #region Popular dados de Usuário
        List<AppUser> users = new()
            {
                new AppUser()
                {
                    Id = "",
                    Email = "pedroantunes480@gmail.com",
                    NormalizedEmail = "PEDROANTUNES480@GMAIL.COM",
                    UserName = "pedroantunes480@gmail.com",
                    NormalizedUserName = "PEDROANTUNES480@gmail.com",
                    LockoutEnabled = false,
                    EmailConfirmed = true,
                    Name = "Pedro Henrique Antunes",
                    ProfilePicture = "https://wallpapers.com/images/featured-full/foto-de-perfil-legal-2we7xmn0737hqgtu.jpg"

                    }
                };

        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        #endregion

        #region Popular Dados de Uduário Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular as Tarefas do usuário
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Estudar para matemática",
                Description = "Introdução a matemática básica",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 2,
                Title = "Estudar português",
                Description = "Introdução a literatura clássica",
                UserId = users[1].Id
            },

              new ToDo()
            {
                Id = 3,
                Title = "Estudar biologia",
                Description = "Teoria da evolução (Darwin)",
                UserId = users[2].Id
            },
        };

        #endregion
    }
}
