using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace MyCustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            ResetProgress(session);

            System.Threading.Thread.Sleep(10000);
            IncrementProgress(session, 100);

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult CustomAction2(Session session)
        {
            System.Threading.Thread.Sleep(10000);
            IncrementProgress(session, 100);

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult CustomAction3(Session session)
        {
            System.Threading.Thread.Sleep(10000);
            IncrementProgress(session, 100);

            return ActionResult.Success;
        }

        private static void ResetProgress(Session session)
        {
            Record record = new Record(4);
            record[1] = "0"; // "Reset" message
            record[2] = "1000"; // total ticks
            record[3] = "0"; // forward motion
            record[4] = "0"; // execution is in progress
            session.Message(InstallMessage.Progress, record);
        }

        private static void IncrementProgress(Session session, int ticks)
        {
            Record record = new Record(2);
            record[1] = "2"; // "Increment" message
            record[2] = ticks.ToString(); // ticks to increment
            session.Message(InstallMessage.Progress, record);
        }
    }
}
