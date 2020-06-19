using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.SubProgram1
{
    class Operation2 : ConsoleMenuLib.ConsoleMenuOperation
    {
        public override ConsoleMenuReport Execute()
        {
            return new ConsoleMenuReport("Operation 2 - returned as operation result passed in ConsoleMenuReport object as dynamic message.", this.ToString(), Request.Suspend);
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D2 };
        }

        protected override string GetMenuOperationName()
        {
            return "Operation 2";
        }
    }
}
