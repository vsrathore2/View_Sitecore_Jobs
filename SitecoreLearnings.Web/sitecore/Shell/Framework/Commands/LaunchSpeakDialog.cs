using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreLearnings.Web.Shell.Framework.Commands
{
    public class LaunchSpeakDialog : Command
    {
        public override void Execute(CommandContext context)
        {
            SheerResponse.Alert("Hello World!", new string[0]);
            return;
        }
    }
}