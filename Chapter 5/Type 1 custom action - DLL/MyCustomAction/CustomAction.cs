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
        public static ActionResult ShowMessage(Session session)
        {
            string myProperty = session["MY_PROPERTY"];
            
            Record record = new Record(0);
            record[0] = "MY_PROPERTY is set to " + myProperty;
            session.Message(InstallMessage.Warning, record);

            return ActionResult.Success;

        }
    }
}
