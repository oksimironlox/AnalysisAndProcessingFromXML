using AnalysisAndProcessingFromXML.ProcessingXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProcessingFromXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = getPathToFile();
            OperationsXML.ReadingXML(pathToFile);
        }

        private static string getPathToFile()
        {
            string heading = "Введите путь к файлу:\n";
            Console.WriteLine(heading);
            string pathToFile = Console.ReadLine();
            return pathToFile;
        }
    }
}
