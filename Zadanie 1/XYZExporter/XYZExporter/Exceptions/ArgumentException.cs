using System;

namespace XYZExporter.Exceptions
{
    public class ArgumentException : Exception
    {
        public ArgumentException() : base("Podana ścieżka jest niepoprawna") 
        {
           
        }
    }
}
