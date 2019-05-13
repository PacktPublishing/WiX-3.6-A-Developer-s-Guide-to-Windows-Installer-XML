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
        public static ActionResult ShowTime(Session session)
        {
            ResetProgress(session);
            NumberOfTicksPerActionData(session, 100);
            DisplayActionData(session, "Message 1");
            System.Threading.Thread.Sleep(2000);

            DisplayActionData(session, "Message 2");
            System.Threading.Thread.Sleep(2000);

            DisplayActionData(session, "Message 3");
            System.Threading.Thread.Sleep(2000);

            return ActionResult.Success;
        }

        private static void ResetProgress(Session session)
        {
            Record record = new Record(4);
            record[1] = "0";
            record[2] = "1000";
            record[3] = "0";
            record[4] = "0";
            session.Message(InstallMessage.Progress, record);
        }

        private static void NumberOfTicksPerActionData(
                  Session session, int ticks)
        {
            Record record = new Record(3);
            record[1] = "1";
            record[2] = ticks.ToString();
            record[3] = "1";
            session.Message(InstallMessage.Progress, record);
        }

        private static void DisplayActionData(Session session,
                  string message)
        {
            Record record = new Record(1);
            record[1] = message;
            session.Message(InstallMessage.ActionData, record);
        }
    }
}
