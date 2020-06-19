using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuLib
{
    public enum InformationType { ConfirmationWithMessage, ConfirmationWithoutMessage, Error, Exception }
    public enum Request { WithoutInterruption, Suspend, Break, SuspendThenBreak }
}
