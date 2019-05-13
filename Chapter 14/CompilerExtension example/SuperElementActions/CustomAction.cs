
namespace SuperElementActions
{
    using Microsoft.Deployment.WindowsInstaller;
    using System;
    using System.Collections.Generic;
    
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ShowMessageImmediate(Session session)
        {
            Database db = session.Database;
            
            try
            {
                View view = db.OpenView("SELECT `Id`, `Type` FROM `SuperElementTable`");
                view.Execute();

                CustomActionData data = new CustomActionData();

                foreach (Record row in view)
                {
                    data[row["Id"].ToString()] = row["Type"].ToString();
                }

                session["ShowMessageDeferred"] = data.ToString();

                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log(ex.Message);
                return ActionResult.Failure;
            }
            finally 
            {
                db.Close();
            }
        }

        [CustomAction]
        public static ActionResult ShowMessageDeferred(Session session)
        {
            try
            {
                CustomActionData data = session.CustomActionData;
                
                foreach (KeyValuePair<string, string> datum in data)
                {
                    DisplayWarningMessage(session, string.Format("{0} => {1}", datum.Key, datum.Value));
                }

                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log(ex.Message);
                return ActionResult.Failure;
            }
        }

        private static void DisplayWarningMessage(Session session, string message)
        {
            Record record = new Record(0);
            record[0] = message;
            session.Message(InstallMessage.Warning, record);
        }
    }
}
