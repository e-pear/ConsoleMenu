using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Building main menu
            // -> menu operations/options:
            List<ConsoleMenuOperation> menuOperations = new List<ConsoleMenuOperation>()
            {
                new MainMenu.MainMenuOperation_RunSubProgram1(),
                new MainMenu.MainMenuOperation_RunSubProgram2(),
                new MainMenu.MainMenuOperation_ExitApp()
            };
            // -> menu object itself
            ConsoleMenu mainMenu = new ConsoleMenu("Main Menu", menuOperations, "Please choose Sub Program: ");
            // -> running whole circus:
            mainMenu.Run();
        }
    }
}
