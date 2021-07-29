using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Classes_App.Models
{
    public static class FilterPrefix
    {
        public const string ClassType = "classtype-";
        public const string NumberOfCredits = "startdate-";
        public const string Teacher = "author-";
    }

    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current) {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) && 
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string ClassTypeFilter {
            get => Get(nameof(ClassesGridDTO.ClassType))?.Replace(FilterPrefix.ClassType, "");
            set => this[nameof(ClassesGridDTO.ClassType)] = value;
        }

        public string StartDateFilter {
            get => Get(nameof(ClassesGridDTO.NumberOfCredits))?.Replace(FilterPrefix.NumberOfCredits, "");
            set => this[nameof(ClassesGridDTO.NumberOfCredits)] = value;
        }

        public string TeacherFilter {
            get
            {
                string s = Get(nameof(ClassesGridDTO.Teacher))?.Replace(FilterPrefix.Teacher, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(ClassesGridDTO.Teacher)] = value;
        }

        public void ClearFilters() =>
            ClassTypeFilter = StartDateFilter = TeacherFilter = ClassesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys) {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
