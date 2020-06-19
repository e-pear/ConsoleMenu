using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuLib
{
    /// <summary>
    /// An object which is returned when ConsoleMenuOperation object do it's job.
    /// It can carry two types of information for user and instructions for ConsoleMenu parent object.
    /// </summary>
    public class ConsoleMenuReport
    {
        private string buffer;
        public string CreatorName { get; private set; }
        public DateTime ReportCreationTime { get; private set; }
        /// <summary>
        /// Stores post-action, short lived information for user. Information may be used as feedback as a result of UserMenuOperation object main action. 
        /// </summary>
        public string DynamicMessage { get; private set; }
        /// <summary>
        /// Stores post-action, long lived information for user. Information is displayed even after UserMenu clears console screen. May be used as status report.
        /// </summary>
        public string StaticMessage
        {
            get
            {
                if (UpdateStaticMessageRequest) return buffer;
                else return "";
            }
        }
        public Request InterruptionRequest { get; private set; }
        /// <summary>
        /// Informs the UserMenu recipient-object that StaticMessage can be read and should be displayed.
        /// </summary>
        public bool UpdateStaticMessageRequest { get; private set; }

        /// <summary>
        /// Creates blank report.
        /// </summary>
        /// <param name="reportCreatorName">Name of calling object</param>
        /// <param name="interruptionRequest">Specifies whether created blank report object should pause menu loop.</param>
        public ConsoleMenuReport(string reportCreatorName = "NOT_DEFINED", Request interruptionRequest = Request.WithoutInterruption)
        {
            buffer = "";
            CreatorName = reportCreatorName;
            ReportCreationTime = DateTime.Now;
            DynamicMessage = "";
            InterruptionRequest = interruptionRequest;
            UpdateStaticMessageRequest = false;
        }
        /// <summary>
        /// Creates a standard user report, which is displayed after menu operation is done.
        /// </summary>
        /// <param name="reportCreatorName">Name of calling object</param>
        /// <param name="userMessage">Message for user.</param>
        /// <param name="interruptionRequest">Specifies whether created blank report object should pause menu loop.</param>
        public ConsoleMenuReport(string userMessage, string reportCreatorName = "NOT_DEFINED", Request interruptionRequest = Request.WithoutInterruption)
        {
            buffer = "";
            CreatorName = reportCreatorName;
            ReportCreationTime = DateTime.Now;
            DynamicMessage = userMessage;
            InterruptionRequest = interruptionRequest;
            UpdateStaticMessageRequest = false;
        }
        /// <summary>
        /// Creates full report, which userMessage part is displayed after manu operation is done and statusMessage part is displayed after menu refresh.
        /// </summary>
        /// <param name="reportCreatorName">Name of calling object</param>
        /// <param name="statusMessage">Short-Lived, dynamic information for user.</param>
        /// <param name="userMessage">Long-Lived, static information for user.</param>
        /// <param name="interruptionRequest">Specifies whether created blank report object should pause menu loop.</param>
        public ConsoleMenuReport(string statusMessage, string userMessage, string reportCreatorName = "NOT_DEFINED", Request interruptionRequest = Request.WithoutInterruption)
        {
            buffer = statusMessage;
            CreatorName = reportCreatorName;
            ReportCreationTime = DateTime.Now;
            UpdateStaticMessageRequest = true;
            DynamicMessage = userMessage;
            InterruptionRequest = interruptionRequest;
        }
    }
}
