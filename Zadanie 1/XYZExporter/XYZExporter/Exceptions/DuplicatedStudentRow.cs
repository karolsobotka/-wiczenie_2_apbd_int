using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter.Exceptions
{
    internal class DuplicatedStudentRow : Exception
    {
        public DuplicatedStudentRow()
            : base("Student with such First Name, Last Name and Student Number was already added")
        {

        }
    }
}
