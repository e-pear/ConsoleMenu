using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuLib
{
    /// <summary>
    /// Simple opject for internal reports. It allows to encapsulate I/O exceptions during file logging operations.
    /// </summary>
    internal class OperationInfo
    {
        public InformationType MessageType { get; private set; }
        public string ResultantMessage { get; private set; }

        public OperationInfo(InformationType messageType, string resultantMessage)
        {
            MessageType = messageType;
            ResultantMessage = resultantMessage;
        }
    }
}
