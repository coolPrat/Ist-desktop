using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST
{
    public class StudentServices
    {
        public string title { get; set; }
        public AcademicAdvisors academicAdvisors { get; set; }
        public ProfessonalAdvisors professonalAdvisors { get; set; }
        public FacultyAdvisors facultyAdvisors { get; set; }
        public IstMinorAdvising istMinorAdvising { get; set; }
    }
}
