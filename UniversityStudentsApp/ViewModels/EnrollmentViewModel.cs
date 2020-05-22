using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityStudentsApp.Models;

namespace UniversityStudentsApp.ViewModels
{
    public class EnrollmentViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<int> SelectedStudents { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
