using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace My_Classes_App.Models
{
    internal class SeedClasses : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasData(
                new Class { ClassId = 1, ClassName = "1776", ClassTypeId = "history", StartDate = 18.00 },
                new Class { ClassId = 2, ClassName = "1984", ClassTypeId = "scifi", StartDate = 5.50 },
                new Class { ClassId = 3, ClassName = "And Then There Were None", ClassTypeId = "mystery", StartDate = 4.50 },
                new Class { ClassId = 4, ClassName = "Band of Brothers", ClassTypeId = "history", StartDate = 11.50 },
                new Class { ClassId = 5, ClassName = "Beloved", ClassTypeId = "novel", StartDate = 10.99 },
                new Class { ClassId = 6, ClassName = "Between the World and Me", ClassTypeId = "memoir", StartDate = 13.50 },
                new Class { ClassId = 7, ClassName = "Bossypants", ClassTypeId = "memoir", StartDate = 4.25 },
                new Class { ClassId = 8, ClassName = "Brave New World", ClassTypeId = "scifi", StartDate = 16.25 },
                new Class { ClassId = 9, ClassName = "D-Day", ClassTypeId = "history", StartDate = 15.00 },
                new Class { ClassId = 10, ClassName = "Down and Out in Paris and London", ClassTypeId = "memoir", StartDate = 12.50 },
                new Class { ClassId = 11, ClassName = "Dune", ClassTypeId = "scifi", StartDate = 8.75 },
                new Class { ClassId = 12, ClassName = "Emma", ClassTypeId = "novel", StartDate = 9.00 },
                new Class { ClassId = 13, ClassName = "Frankenstein", ClassTypeId = "scifi", StartDate = 6.50D },
                new Class { ClassId = 14, ClassName = "Go Tell it on the Mountain", ClassTypeId = "novel", StartDate = 10.25 },
                new Class { ClassId = 15, ClassName = "Guns, Germs, and Steel", ClassTypeId = "history", StartDate = 15.50 },
                new Class { ClassId = 16, ClassName = "Hunger", ClassTypeId = "memoir", StartDate = 14.50 },
                new Class { ClassId = 17, ClassName = "Murder on the Orient Express", ClassTypeId = "mystery", StartDate = 6.75 },
                new Class { ClassId = 18, ClassName = "Pride and Prejudice", ClassTypeId = "novel", StartDate = 8.50 },
                new Class { ClassId = 19, ClassName = "Rebecca", ClassTypeId = "mystery", StartDate = 10.99 },
                new Class { ClassId = 20, ClassName = "The Art of War", ClassTypeId = "history", StartDate = 5.75 },
                new Class { ClassId = 21, ClassName = "The Girl with the Dragon Tattoo", ClassTypeId = "mystery", StartDate = 8.50 },
                new Class { ClassId = 22, ClassName = "The Handmaid's Tale", ClassTypeId = "scifi", StartDate = 12.50 },
                new Class { ClassId = 23, ClassName = "The Maltese Falcon", ClassTypeId = "mystery", StartDate = 10.99 },
                new Class { ClassId = 24, ClassName = "The New Jim Crow", ClassTypeId = "history", StartDate = 13.75 },
                new Class { ClassId = 25, ClassName = "The Year of Magical Thinking", ClassTypeId = "memoir", StartDate = 13.50 },
                new Class { ClassId = 26, ClassName = "Wuthering Heights", ClassTypeId = "novel", StartDate = 9.00 },
                new Class { ClassId = 27, ClassName = "Running With Scissors", ClassTypeId = "memoir", StartDate = 11.00 },
                new Class { ClassId = 28, ClassName = "Pride and Prejudice and Zombies", ClassTypeId = "novel", StartDate = 8.75 },
                new Class { ClassId = 29, ClassName = "Harry Potter and the Sorcerer's Stone", ClassTypeId = "novel", StartDate = 9.75 }
            );
        }
    }

}
