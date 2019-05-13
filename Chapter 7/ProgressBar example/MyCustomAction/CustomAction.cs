using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace MyCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult DoStuff(Session session)
        {
            ResetProgress(session);
            NumberOfTicksPerActionData(session, 100);

            DisplayActionData(session, "Sleeping for two seconds...");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "Sleeping for another two seconds...");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "This is my third message");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "See how the ProgressText template stays the same?");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "I can keep updating my status...");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "You can do this sort of thing for all your custom actions!");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "This is the second to last message");
            System.Threading.Thread.Sleep(3000);

            DisplayActionData(session, "Last message from this custom action!");
            System.Threading.Thread.Sleep(3000);

            return ActionResult.Success;
        }

        /// <summary>
        /// Reset the progress bar to empty
        /// </summary>
        /// <param name="session">Windows Installer session object</param>
        private static void ResetProgress(Session session)
        {
            Record record = new Record(4);
            record[1] = "0";
            record[2] = "1000";
            record[3] = "0";
            record[4] = "0";
            session.Message(InstallMessage.Progress, record);
        }


        /// <summary>
        /// Sets how much to increment progress bar for each ActionData message sent
        /// </summary>
        /// <param name="session">Windows Installer session object</param>
        /// <param name="ticks">Number of ticks to add to progress bar</param>
        private static void NumberOfTicksPerActionData(Session session, int ticks)
        {
            Record record = new Record(3);
            record[1] = "1";
            record[2] = ticks.ToString();
            record[3] = "1";
            session.Message(InstallMessage.Progress, record);
        }

        /// <summary>
        /// Display ActionData message on dialog
        /// </summary>
        /// <param name="session">Windows Installer session object</param>
        /// <param name="message">Message to display</param>
        private static void DisplayActionData(Session session, string message)
        {
            Record record = new Record(1);
            record[1] = message;
            session.Message(InstallMessage.ActionData, record);
        }
    }
}
