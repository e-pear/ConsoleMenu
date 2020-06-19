using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuLib
{
    /// <summary>
    /// Menu object that manages user-created operations.
    /// </summary>
    public class ConsoleMenu
    {
        // Fields - log related
        private bool isLoggingAllowed;
        private bool showLoggingErrors;
        private DateTime timeStamp;
        // Fields - presentation layer
        private string menuHeader;
        private string separator;
        private string staticMessage;
        private bool showStaticMessage;
        // Fields - main mechanics
        private List<ConsoleMenuOperation> menuOptions;
        private bool loopBreaker; // breakes main loop if false
        private ConsoleMenuReport operationExecutionReport;
        /// <summary>
        /// Menu constructor.
        /// </summary>
        /// <param name="menuHeader">Menu header displayed on top.</param>
        /// <param name="menuOptions">Collection of all user's defined ConsoleMenuOperation objects - order matters.</param>
        /// <param name="initialStaticMessage">Initial static message that will be displayed directly under menu header.</param>
        /// <param name="isLoggingAllowed">Boolean indicator setting whether ConsoleMenu instance has to log it's operations or not.</param>
        /// <param name="showLoggingErrors">Boolean indicator setting whether ConsoleMenu instance should inform user's obout logging I/O errors.</param>
        public ConsoleMenu(string menuHeader, IEnumerable<ConsoleMenuOperation> menuOptions, string initialStaticMessage = "", bool isLoggingAllowed = false, bool showLoggingErrors = false)
        {
            this.menuHeader = menuHeader;
            this.isLoggingAllowed = isLoggingAllowed;
            this.showLoggingErrors = showLoggingErrors;
            separator = "";
            foreach (char character in menuHeader)
            {
                if (character == '\n') break;
                separator += "-";
            }
            this.menuOptions = new List<ConsoleMenuOperation>(menuOptions);
            staticMessage = initialStaticMessage;
            if (staticMessage != null && staticMessage != "") showStaticMessage = true;
            else showStaticMessage = false;
            loopBreaker = true;
        }
        /// <summary>
        /// Main method which starts instance's loop.
        /// </summary>
        public void Run()
        {
            while (loopBreaker)
            {
                DisplayMenu();
                operationExecutionReport = RunChosenOption(GetOptionFromUser());
                ProcessOperationReport(operationExecutionReport);
                //post action log processing
                if (isLoggingAllowed) ProcessOperationLog(operationExecutionReport);
            }
        }
        // Aux Methods:
        // -> Describes way in which menu is displayed.
        private void DisplayMenu()
        {
            Console.Clear();
            if (showStaticMessage)
            {
                Console.WriteLine(staticMessage);
            }
            Console.WriteLine("\n" + menuHeader + "\n");
            Console.WriteLine(separator);
            Console.WriteLine(DrawAvailableMenuOptions());
            Console.WriteLine(separator);
        }
        // -> Draws list of available menu operations based on ConsoleMenuOperation collection passed in constructor. Returns a storey string.
        private string DrawAvailableMenuOptions()
        {
            string buffer = "";
            int counter = 0;
            int count = menuOptions.Count();

            foreach (ConsoleMenuOperation item in menuOptions)
            {
                counter++;
                buffer += item.Title;
                if (counter < count) buffer += "\n";
            }

            return buffer;
        }
        // -> Retreives a key informatrion from user.
        private ConsoleKey GetOptionFromUser()
        {
            ConsoleKeyInfo keyInfo;
            Console.Write("Option selection: ");
            keyInfo = Console.ReadKey();
            timeStamp = DateTime.Now;
            return keyInfo.Key;
        }
        // -> Runs choosen user operation
        private ConsoleMenuReport RunChosenOption(ConsoleKey associatedKey)
        {
            int counter = 0;
            int capturedIndex = -1;
            foreach (ConsoleMenuOperation option in menuOptions)
            {
                if (option.HasAssociatedKey(associatedKey))
                {
                    capturedIndex = menuOptions.IndexOf(option);
                    counter++;
                }
            }
            Console.WriteLine();
            // here pre action log processing
            if (counter > 1)
            {
                if (isLoggingAllowed) ProcessOperationLog("Critical application error: Duplicate operation ID encountered. Contact with software provider needed.");
                return new ConsoleMenuReport("#ERROR: duplicated user operation ID has been found#. Please contact with software provider.", menuHeader, Request.Suspend);
            }
            else if (counter == 1)
            {
                if (isLoggingAllowed) ProcessOperationLog(menuOptions[capturedIndex]);
                return menuOptions[capturedIndex].Execute();
            }
            else
            {
                if (isLoggingAllowed) ProcessOperationLog("Operation selection error: operation not found.");
                return new ConsoleMenuReport("Operation selection error: operation not found.", menuHeader, Request.Suspend);
            }
        }
        // -> Operation post-processing
        private void ProcessOperationReport(ConsoleMenuReport report)
        {
            if (report.UpdateStaticMessageRequest)
            {
                showStaticMessage = true;
                staticMessage = report.StaticMessage;
            }
            if (report.InterruptionRequest == Request.Suspend || report.InterruptionRequest == Request.SuspendThenBreak)
            {
                Console.WriteLine(report.DynamicMessage);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            if (report.InterruptionRequest == Request.Break || report.InterruptionRequest == Request.SuspendThenBreak)
            {
                loopBreaker = false;
            }
            else Console.WriteLine(report.DynamicMessage);
        }
        // Little Wrappers
        private void ProcessOperationLog(ConsoleMenuReport report)
        {
            LogToFile(GetLogLine(report));
        }
        private void ProcessOperationLog(ConsoleMenuOperation launchedOperation)
        {
            LogToFile(GetLogLine(launchedOperation));
        }
        private void ProcessOperationLog(string rawLogMessage)
        {
            string actionTime = timeStamp.ToString();
            string actionPlace = menuHeader;
            string extraOrdinaryLogLine = $"Operation start time: <{actionTime}> | Operation origin: <{actionPlace}> | {rawLogMessage}";
            LogToFile(extraOrdinaryLogLine);

        }
        // Logging Method
        private void LogToFile(string logLine)
        {
            OperationInfo logResult = StaticLogger.LogToFile(logLine);
            if (logResult.MessageType == InformationType.Exception && showLoggingErrors)
            {
                Console.WriteLine("#Operation event logging error has occured#:");
                Console.WriteLine(logResult.ResultantMessage);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
        // post action log
        private string GetLogLine(ConsoleMenuReport report)
        {
            string resultantMessage;

            string actionName = report.CreatorName;
            string resultTime = report.ReportCreationTime.ToString();
            string totalTime = (report.ReportCreationTime - timeStamp).ToString();

            if (report.InterruptionRequest == Request.WithoutInterruption) resultantMessage = "Operation completed successfully.";
            if (report.InterruptionRequest == Request.Break) resultantMessage = $"Operation terminated by user in: {menuHeader}.";
            else resultantMessage = report.DynamicMessage;

            return $"Operation end time: <{resultTime}> | Additional information: <{resultantMessage}> | Total time of operation: <{totalTime}>";
        }
        // pre action log
        private string GetLogLine(ConsoleMenuOperation actualOperation)
        {
            string actionTime = timeStamp.ToString();
            string actionPlace = menuHeader;
            string actionName = actualOperation.Title;
            return $"Operation start time: <{actionTime}> | Operation origin: <{actionPlace}> | Operation name: <{actionName}>";
        }
    }
}
