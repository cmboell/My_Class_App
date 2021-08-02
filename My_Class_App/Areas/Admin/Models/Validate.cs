using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace My_Classes_App.Models
{
    public class Validate
    {
        private const string ClassTypeKey = "validClassType";
        private const string TeacherKey = "validTeacher";
        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckClassType(string classTypeId, IRepository<ClassType> data)
        {
            ClassType entity = data.Get(classTypeId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"ClassType id {classTypeId} is already in the database.";
        }
        public void MarkClassTypeChecked() => tempData[ClassTypeKey] = true;
        public void ClearClassType() => tempData.Remove(ClassTypeKey);
        public bool IsClassTypeChecked => tempData.Keys.Contains(ClassTypeKey);

        public void CheckTeacher(string firstName, string lastName, string operation, IRepository<Teacher> data)
        {
            Teacher entity = null;
            if (Operation.IsAdd(operation))
            {
                entity = data.Get(new QueryOptions<Teacher>
                {
                    Where = t => t.FirstName == firstName && t.LastName == lastName
                });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Teacher {entity.FullName} is already in the database.";
        }
        public void MarkTeacherChecked() => tempData[TeacherKey] = true;
        public void ClearTeacher() => tempData.Remove(TeacherKey);
        public bool IsTeacherChecked => tempData.Keys.Contains(TeacherKey);
    }
}