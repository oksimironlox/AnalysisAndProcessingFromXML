using AnalysisAndProcessingFromXML.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AnalysisAndProcessingFromXML.ProcessingXML
{
    public static class OperationsXML
    {
        static XDocument customers = new XDocument();
        public static void ReadingXML(string pathToFile) 
        {
            try
            {
                customers = XDocument.Load(pathToFile);
                MainMenu menu = new MainMenu();
                menu.Menu();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: Файл не найден. {ex.Message}");
                Console.WriteLine("Введите правильный путь к файлу:\n");
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"Ошибка: Неправильный формат XML. {ex.Message}");
                Console.WriteLine("Исправьте файл и введите путь к файлу:\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.WriteLine("Введите путь к файлу:\n");
            }
        }

        public static List<string> GetNumAtribute()
        {
            List<string> numAtribute = new List<string>();
            try
            {
                foreach (var customerElement in customers.Descendants("Customer"))
                {
                    foreach (var attribute in customerElement.Attributes())
                    {
                        if (int.TryParse(attribute.Value, out int numericValue))
                        {
                            numAtribute.Add(attribute.Name.ToString());
                        }
                        
                    }
                    return numAtribute;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            return null;
        }

        public static void DisplaySumCustomers()
        {
            try
            {
                int count = customers.Descendants("Customer").Count();
                Console.WriteLine("Сумма всех элементов в файле: " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вычислении суммы: {ex.Message}");
            }
        }

        public static void DisplayInfoCustomers() 
        {
            try
            {
                foreach (var customerElement in customers.Descendants("Customer"))
                {
                    Console.WriteLine($"Element: Customer");
                    foreach (var attribute in customerElement.Attributes())
                    {
                        Console.WriteLine($" Attribute: {attribute.Name} = {attribute.Value}");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void DisplaySumAtribute(string nameAtribute)
        {
            long totalSum = 0;

            try
            {
                totalSum = customers.Descendants() 
                  .SelectMany(element => element.Attributes(nameAtribute)) 
                  .Where(attribute => long.TryParse(attribute.Value, out long value)) 
                  .Sum(attribute => long.Parse(attribute.Value));

                Console.WriteLine($"Сумма всех атрибутов {nameAtribute}: {totalSum}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Не все атрибуты являются числами.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }


        }
    }


    }

