using System;


namespace XYZExporter.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException() : base("Plik o podanej nazwie nie istnieje")
        {

        }
    }
}
