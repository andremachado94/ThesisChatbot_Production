using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace LuisBot.Data
{
    public static class Client
    {
        public static void SetClientFirstName(IDialogContext context, string name) {
            context.UserData.SetValue("ClientFirstName", name);
        }

        public static string GetClientFirstName(IDialogContext context)
        {
            context.UserData.TryGetValue("ClientFirstName", out string name);
            return name;
        }

    }
}
