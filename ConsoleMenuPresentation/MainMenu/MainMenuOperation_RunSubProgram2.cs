using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.MainMenu
{
    class MainMenuOperation_RunSubProgram2 : ConsoleMenuLib.ConsoleMenuOperation
    {
        public override ConsoleMenuReport Execute()
        {
            ExternalObject externalObject = new ExternalObject() { SomeInt = 50, SomeString = "Initial string" };

            ConsoleMenuOperation[] menuOperations = new ConsoleMenuOperation[3]
            {
                new SubProgram2.Operation_ChangeObjectsInt(externalObject),
                new SubProgram2.Operation_ChangeObjectsString(externalObject),
                new SubProgram2.Operation_CloseSubProgram2()
            };
            ConsoleMenu subMenu2 = new ConsoleMenu("Sub Program 2:", menuOperations, externalObject.ToString());
            subMenu2.Run();
            return new ConsoleMenuReport("Sub program 2 has been closed.",this.ToString(), Request.Suspend);
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D2 };
        }

        protected override string GetMenuOperationName()
        {
            return "Start SubProgram 2";
        }
    }
}
