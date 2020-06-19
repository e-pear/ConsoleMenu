using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.SubProgram2
{
    class Operation_ChangeObjectsInt : ConsoleMenuLib.ConsoleMenuOperation
    {
        string line;
        ExternalObject externalObject;

        public Operation_ChangeObjectsInt(ExternalObject externalObject) : base()
        {
            this.externalObject = externalObject;
        }
        
        public override ConsoleMenuReport Execute()
        {
            Console.WriteLine("Enter new number: \n");
            line = Console.ReadLine();
            externalObject.SomeInt = Convert.ToInt32(line);
            return new ConsoleMenuReport(externalObject.ToString(), "Int value has been changed.", this.ToString(), Request.Suspend);
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.NumPad1 };
        }

        protected override string GetMenuOperationName()
        {
            return "Change external object int value";
        }
    }
}
