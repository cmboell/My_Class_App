﻿using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class BookDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public double StartDate { get; set; }
        public Dictionary<int, string> Teachers { get; set; }

        public void Load(Class book)
        {
            ClassId = book.ClassId;
            ClassName = book.ClassName;
            StartDate = book.StartDate;
            Teachers = new Dictionary<int, string>();
            foreach (ClassTeacher ba in book.ClassTeachers) {
                Teachers.Add(ba.Teacher.TeacherId, ba.Teacher.FullName);
            }
        }
    }

}
