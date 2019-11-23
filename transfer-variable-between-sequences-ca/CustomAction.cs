using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace CustomAction1
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult SetPropertyCustomAction(Session session)
        {
            session.Log($"Begin {nameof(SetPropertyCustomAction)}");
            session.Log($"test: {session["TEST"]}");

            session["TEST"] = "changed";

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ReadPropertyCustomAction(Session session)
        {
            session.Log($"Begin {nameof(ReadPropertyCustomAction)}");
            session.Log($"{session["TEST"]}");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ReadPropertyDeferredCustomAction(Session session)
        {
            session.Log($"Begin {nameof(ReadPropertyDeferredCustomAction)}");

            try
            {
                foreach (var data in session.CustomActionData)
                    session.Log($"{data.Key}: {data.Value}");
            }
            catch (Exception ex)
            {
                session.Log($"{ex.Message}");
                throw;
            }

            return ActionResult.Success;
        }
    }
}
