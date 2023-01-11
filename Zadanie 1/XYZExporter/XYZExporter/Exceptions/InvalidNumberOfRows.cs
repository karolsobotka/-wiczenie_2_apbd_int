using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter.Exceptions
{
    public class InvalidNumberOfRows : Exception
    {
        public InvalidNumberOfRows(int expected, int given)
            : base($"Invalid number of rows provided," +
                  $" {expected} expected, but {given} given")
        {
           
        }
    }
}
