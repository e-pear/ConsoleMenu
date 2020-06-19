using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.SubProgram1
{
    class Operation1 : ConsoleMenuLib.ConsoleMenuOperation
    {
        public override ConsoleMenuReport Execute()
        {
            Console.WriteLine("Operation 1 - returned from execute method.");
            return new ConsoleMenuReport(this.ToString(), Request.Suspend);
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D1 };
        }

        protected override string GetMenuOperationName()
        {
            return "Operation 1";
        }
    }
}
