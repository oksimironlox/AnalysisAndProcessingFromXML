using AnalysisAndProcessingFromXML.ProcessingXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProcessingFromXML.Menu
{
    public class MainMenu : Menu
    {
        private const string CountElements = "CountElements";
        private const string OutputElements = "OutputElements";
        private const string SummarizeDefiniteElements = "SummarizeDefiniteElements";
        public void DrawMenu(List<MenuItem> menu)
        {
            ConsoleHelper.ClearScreen();
            foreach (MenuItem menuItem in menu)
            {
                Console.BackgroundColor = menuItem.IsSelected
                    ? ConsoleColor.Green
                    : ConsoleColor.Black;

                Console.WriteLine(menuItem.Text);
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void MenuSelectNext(List<MenuItem> menu)
        {
            var selectedItem = menu.First(x => x.IsSelected);
            int selectedIndex = menu.IndexOf(selectedItem);
            selectedItem.IsSelected = false;

            selectedIndex = selectedIndex == menu.Count - 1
                ? 0
                : ++selectedIndex;

            menu[selectedIndex].IsSelected = true;
        }

        public void MenuSelectPrev(List<MenuItem> menu)
        {
            var selectedItem = menu.First(x => x.IsSelected);
            int selectedIndex = menu.IndexOf(selectedItem);
            selectedItem.IsSelected = false;

            selectedIndex = selectedIndex == 0
                ? menu.Count - 1
                : --selectedIndex;

            menu[selectedIndex].IsSelected = true;
        }

        public void Execute(string commandId)
        {
            ConsoleHelper.ClearScreen();
            switch (commandId)
            {
                case CountElements:
                    OperationsXML.DisplaySumCustomers();
                    break;
                case OutputElements:
                    OperationsXML.DisplayInfoCustomers();
                    break;
                case SummarizeDefiniteElements:
                    HelperMenu menu = new HelperMenu();
                    menu.Menu();
                    break;
                case "exit":
                    break;
            }
        }

        public void Menu()
        {
            Console.CursorVisible = false;
            List<MenuItem> menu = new List<MenuItem>
            {
                new MenuItem {Id = CountElements, Text = "Подсчитать количество элементов в файле", IsSelected = true},
                new MenuItem {Id = OutputElements, Text = "Вывести список всех элементов в файле" },
                new MenuItem {Id = SummarizeDefiniteElements, Text = "Суммировать значения определенных атрибутов" },
                new MenuItem {Id = "exit", Text = "Выход" }
            };

            bool exit = false;
            do
            {
                DrawMenu(menu);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        MenuSelectNext(menu);
                        break;
                    case ConsoleKey.UpArrow:
                        MenuSelectPrev(menu);
                        break;
                    case ConsoleKey.Enter:
                        var selectedItem = menu.First(x => x.IsSelected);
                        Execute(selectedItem.Id);

                        Console.WriteLine("Хотите продолжить? y/n");
                        string answer = Console.ReadLine();
                        exit = answer == "n" || answer == "no";

                        break;
                }
            } while (!exit);
        }
    }
}
