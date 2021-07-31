using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class model
namespace My_Classes_App.Models
{
    internal class SeedClasses : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasData(
                new Class { ClassId = 1, ClassTitle = "1776", ClassTypeId = "history", NumberOfCredits = 18.00 },
                new Class { ClassId = 2, ClassTitle = "1984", ClassTypeId = "scifi", NumberOfCredits = 5.50 },
                new Class { ClassId = 3, ClassTitle = "And Then There Were None", ClassTypeId = "mystery", NumberOfCredits = 4.50 },
                new Class { ClassId = 4, ClassTitle = "Band of Brothers", ClassTypeId = "history", NumberOfCredits = 11.50 },
                new Class { ClassId = 5, ClassTitle = "Beloved", ClassTypeId = "novel", NumberOfCredits = 10.99 },
                new Class { ClassId = 6, ClassTitle = "Between the World and Me", ClassTypeId = "memoir", NumberOfCredits = 13.50 },
                new Class { ClassId = 7, ClassTitle = "Bossypants", ClassTypeId = "memoir", NumberOfCredits = 4.25 },
                new Class { ClassId = 8, ClassTitle = "Brave New World", ClassTypeId = "scifi", NumberOfCredits = 16.25 },
                new Class { ClassId = 9, ClassTitle = "D-Day", ClassTypeId = "history", NumberOfCredits = 15.00 },
                new Class { ClassId = 10, ClassTitle = "Down and Out in Paris and London", ClassTypeId = "memoir", NumberOfCredits = 12.50 },
                new Class { ClassId = 11, ClassTitle = "Dune", ClassTypeId = "scifi", NumberOfCredits = 8.75 },
                new Class { ClassId = 12, ClassTitle = "Emma", ClassTypeId = "novel", NumberOfCredits = 9.00 },
                new Class { ClassId = 13, ClassTitle = "Frankenstein", ClassTypeId = "scifi", NumberOfCredits = 6.50D },
                new Class { ClassId = 14, ClassTitle = "Go Tell it on the Mountain", ClassTypeId = "novel", NumberOfCredits = 10.25 },
                new Class { ClassId = 15, ClassTitle = "Guns, Germs, and Steel", ClassTypeId = "history", NumberOfCredits = 15.50 },
                new Class { ClassId = 16, ClassTitle = "Hunger", ClassTypeId = "memoir", NumberOfCredits = 14.50 },
                new Class { ClassId = 17, ClassTitle = "Murder on the Orient Express", ClassTypeId = "mystery", NumberOfCredits = 6.75 },
                new Class { ClassId = 18, ClassTitle = "Pride and Prejudice", ClassTypeId = "novel", NumberOfCredits = 8.50 },
                new Class { ClassId = 19, ClassTitle = "Rebecca", ClassTypeId = "mystery", NumberOfCredits = 10.99 },
                new Class { ClassId = 20, ClassTitle = "The Art of War", ClassTypeId = "history", NumberOfCredits = 5.75 },
                new Class { ClassId = 21, ClassTitle = "The Girl with the Dragon Tattoo", ClassTypeId = "mystery", NumberOfCredits = 8.50 },
                new Class { ClassId = 22, ClassTitle = "The Handmaid's Tale", ClassTypeId = "scifi", NumberOfCredits = 12.50 },
                new Class { ClassId = 23, ClassTitle = "The Maltese Falcon", ClassTypeId = "mystery", NumberOfCredits = 10.99 },
                new Class { ClassId = 24, ClassTitle = "The New Jim Crow", ClassTypeId = "history", NumberOfCredits = 13.75 },
                new Class { ClassId = 25, ClassTitle = "The Year of Magical Thinking", ClassTypeId = "memoir", NumberOfCredits = 13.50 },
                new Class { ClassId = 26, ClassTitle = "Wuthering Heights", ClassTypeId = "novel", NumberOfCredits = 9.00 },
                new Class { ClassId = 27, ClassTitle = "Running With Scissors", ClassTypeId = "memoir", NumberOfCredits = 11.00 },
                new Class { ClassId = 28, ClassTitle = "Pride and Prejudice and Zombies", ClassTypeId = "novel", NumberOfCredits = 8.75 },
                new Class { ClassId = 29, ClassTitle = "Harry Potter and the Sorcerer's Stone", ClassTypeId = "novel", NumberOfCredits = 9.75 }
            );
        }
    }

}
