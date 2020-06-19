using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuPresentation
{
    class ExternalObject // simple object class not related with console menu in any way
    {
        public int SomeInt { get; set; }
        public string SomeString { get; set; }

        public override string ToString() // Some status display method. I choosen to override ToString, but this can be done in any place (inside ConsoleMenuOperation object, as a separate method in ExternalObject, etc.)
        {
            return $"External Object desc.:\nActual int value: {SomeInt}\nActual string value: {SomeString}";
        }
    }
}
