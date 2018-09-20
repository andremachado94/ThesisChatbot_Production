using System;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace LuisBot.Cards
{
    public static class ConfirmationCard
    {
        public static HeroCard GetConfirmationCard(string text){

            HeroCard heroCard = new HeroCard()
            {
                Text = text,
                Buttons = new List<CardAction>()
                    {
                        new CardAction()
                        {
                            Title = "Sim",
                            Type = ActionTypes.Call,
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
