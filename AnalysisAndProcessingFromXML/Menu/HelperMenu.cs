using AnalysisAndProcessingFromXML.ProcessingXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProcessingFromXML.Menu
{
    public class HelperMenu : Menu
    {
        public List<MenuItem> GetIdElements()
        {
            List<string> menuItemsFromSource = OperationsXML.GetNumAtribute(); 

            List<MenuItem> menu = new List<MenuItem>();
            foreach (string itemText in menuItemsFromSource)
            {
                menu.Add(new MenuItem { Id = itemText, Text = itemText, IsSelected = false }); 
            }

            menu.Add(new MenuItem { Id = "exit", Text = "Выход", IsSelected = false });
            if (menu.Count > 0) menu[0].IsSelected = true; 

            return menu;
        }

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
            if (commandId == "exit")
            {
                return;
            }
            try
            {
                OperationsXML.DisplaySumAtribute(commandId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке атрибута: {ex.Message}");
            }

        }

        public void Menu()
        {
            Console.CursorVisible = false;
            List<MenuItem> menu = GetIdElements();

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

                        exit = true;

                        break;
                }
            } while (!exit);
        }
    }
}

