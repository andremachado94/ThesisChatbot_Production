using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using LuisBot.Cards;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    //[LuisModel(AppSettings.LuisAppId, AppSettings.LuisSubscriptionKey, domain: AppSettings.LuisDomain)]
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "Greeting" with the name of your newly created intent in the following handler
        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }


        [LuisIntent("SymptomDescription")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {

            string res = "";

            foreach(EntityRecommendation entity in result.Entities){
                res += "\n\nEntity: " + entity.Entity;
                res += "\n\tType: " + entity.Type;
                res += "\n\tScore: " + entity.Score;
                if(entity.Resolution != null){
                    res += "\n\tResolution: ";
                    if(entity.Resolution.ContainsKey("values"))
                        res += entity.Resolution["values"];
                    else
                        res +="Not found";
                }
            }

            await context.PostAsync($"{res}\n\nMais algum sintoma? Caso sinta algo mais por favor refira o que é :)");

            context.Wait(MessageReceived);

            /*
            var resultMessage = context.MakeMessage();
            resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            resultMessage.Attachments = new List<Attachment>();

            resultMessage.Attachments.Add(ConfirmationCard.GetConfirmationCard("Algo mais?").ToAttachment());

            await context.PostAsync(resultMessage);
            context.Wait(MessageReceived);
            */
        }

        private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
            context.Wait(MessageReceived);
        }


    }
}