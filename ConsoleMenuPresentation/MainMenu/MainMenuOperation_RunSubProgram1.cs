using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.MainMenu
{
    class MainMenuOperation_RunSubProgram1 : ConsoleMenuLib.ConsoleMenuOperation
    {
        public override ConsoleMenuReport Execute()
        {
            ConsoleMenuOperation[] menuOperations = new ConsoleMenuOperation[3]
            {
                new SubProgram1.Operation1(),
                new SubProgram1.Operation2(),
                new SubProgram1.Operation3()
            };
            ConsoleMenu subMenu1 = new ConsoleMenu("Sub Program 1:", menuOperations);
            subMenu1.Run();
            return new ConsoleMenuReport(this.ToString(),Request.WithoutInterruption);
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D1 };
        }

        protected override string GetMenuOperationName()
        {
            return "Start SubProgram 1";
        }
    }
}
