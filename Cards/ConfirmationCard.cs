using System;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace LuisBot.Cards
{
    public static class ConfirmationCard
    {
        public static HeroCard GetConfirmationCard(string title, string subtitle){

            HeroCard heroCard = new HeroCard()
            {
                Text = "Algo mais? :)",
                Title = title != null ? title : null,
                Subtitle = subtitle != null ? subtitle : null,
                Buttons = new List<CardAction>()
                    {
                        new CardAction()
                        {
                            Title = "Sim",
                            Type = ActionTypes.MessageBack,
                            Value = 1
                        },
                        new CardAction()
                        {
                            Title = "Não",
                            Type = ActionTypes.MessageBack,
                            Value = 0
                        }
                    }
            };

            return heroCard;
        }
    }
}
