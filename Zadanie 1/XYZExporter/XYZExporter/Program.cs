using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XYZExporter
{
    class ProgramS
    {
        static async Task Main(string[] args)
        {
            string pathToCSVFile = args[0];
            string pathToResultFile = args[1];
            string typeOfFile = args[2];
            string pathToLogFile = "..\\..\\..\\log.txt";
            StreamWriter streamWriter = new StreamWriter(pathToLogFile);

            if (args.Length != 3)
            {
                throw new Exceptions.ArgumentException();
            }

            if (!File.Exists(Path.GetFullPath(pathToCSVFile)))
            {
                streamWriter.WriteLine($"File not found: {pathToCSVFile}");
            }
            else
            {
                pathToCSVFile = Path.GetFullPath(pathToCSVFile);
                Console.WriteLine(pathToCSVFile);
            }
            try
            {
                using (File.Create(pathToResultFile + "." + typeOfFile)) ;
                pathToResultFile = Path.GetFullPath(pathToResultFile + "."+typeOfFile);
                Console.WriteLine(pathToResultFile);
            }
            catch (Exception e)
            {
                streamWriter.WriteLine(e.Message);
            }

            if (typeOfFile.ToLower().Equals("json"))
            {
                string[] studentsArray = await File.ReadAllLinesAsync(pathToCSVFile);
                bool validated = true;

                var studenci = new JArray();

                foreach (string line in studentsArray)
                {
                    string alineData = line;

                    string[] studentData = alineData.Split(',');

                    if ((studentData.Length != 9))
                    {
                        validated = false;
                        streamWriter.WriteLine($"Not described by 9 data columns: {alineData}");
                    }
                    else
                    {
                        foreach (string data in studentData)
                        {
                            if (data == "")
                            {
                                validated = false;
                                streamWriter.WriteLine($"One or more columns are empty: {alineData}");
                            }
                        }
                    }

                    if (validated)
                    {
                        var newStudent = new JObject(
                            new JProperty("indexNumber", "s" + studentData[4]),
                            new JProperty("fname", studentData[0]),
                            new JProperty("lname", studentData[1]),
                            new JProperty("birthdate", studentData[5]),
                            new JProperty("email", studentData[6]),
                            new JProperty("mothersName", studentData[7]),
                            new JProperty("fathersName", studentData[8]),
                            new JProperty("studiesName", studentData[2]),
                            new JProperty("studiesMode", studentData[3])
                            );

                        if (studenci.Count == 0)
                        {
                            studenci.Add(newStudent);
                        }

                        if (studenci.Contains(newStudent))
                        {
                            streamWriter.WriteLine("Student exist" + newStudent.ToString());
                        }
                        else
                        {
                            studenci.Add(newStudent);
                        }
                    }
                    var jObject = new JObject(
                   new JProperty("uczelnia", new JObject(
                       new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                       new JProperty("author", "Karol Sobotka"),
                       new JProperty("studenci", studenci)
                   ))
                   );
                    File.WriteAllText(pathToResultFile, jObject.ToString());



                }
            }
        }
    }
}