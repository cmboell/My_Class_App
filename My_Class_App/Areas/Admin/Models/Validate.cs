using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace My_Classes_App.Models
{
    public class Validate
    {
        private const string GenreKey = "validGenre";
        private const string AuthorKey = "validAuthor";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckGenre(string genreId, IRepository<ClassType> data)
        {
            ClassType entity = data.Get(genreId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"ClassType id {genreId} is already in the database.";
        }
        public void MarkGenreChecked() => tempData[GenreKey] = true;
        public void ClearGenre() => tempData.Remove(GenreKey);
        public bool IsGenreChecked => tempData.Keys.Contains(GenreKey);

        public void CheckTeacher(string firstName, string lastName, string operation, IRepository<Teacher> data)
        {
            Teacher entity = null; 
            if (Operation.IsAdd(operation))
            {
                entity = data.Get(new QueryOptions<Teacher>
                {
                    Where = a => a.FirstName == firstName && a.LastName == lastName
                });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Teacher {entity.FullName} is already in the database.";
        }
        public void MarkAuthorChecked() => tempData[AuthorKey] = true;
        public void ClearAuthor() => tempData.Remove(AuthorKey);
        public bool IsAuthorChecked => tempData.Keys.Contains(AuthorKey);
    }
}