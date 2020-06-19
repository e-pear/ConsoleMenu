using ConsoleMenuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation.SubProgram2
{
    class Operation_ChangeObjectsString : ConsoleMenuLib.ConsoleMenuOperation
    {
        string line;
        ExternalObject externalObject;

        public Operation_ChangeObjectsString(ExternalObject externalObject) : base()
        {
            this.externalObject = externalObject;
        }

        public override ConsoleMenuReport Execute()
        {
            Console.WriteLine("Enter new string: \n");
            line = Console.ReadLine();
            externalObject.SomeString = line;
            return new ConsoleMenuReport(externalObject.ToString(), "String value has been changed.", this.ToString(), Request.WithoutInterruption); // this time user doesn't see confirmation
        }

        protected override ConsoleKey[] GetAssociatedKeys()
        {
            return new ConsoleKey[] { ConsoleKey.D2, ConsoleKey.NumPad2 };
        }

        protected override string GetMenuOperationName()
        {
            return "Change external object string value";
        }
    }
}
