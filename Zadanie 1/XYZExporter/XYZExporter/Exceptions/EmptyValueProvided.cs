using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter.Exceptions
{
    public class EmptyValueProvided : Exception
    {
        public EmptyValueProvided()
            : base("All columns are required but empty value provided")
        {

        }
    }
}
