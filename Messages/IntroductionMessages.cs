using System;
namespace LuisBot.Messages
{
    public static class IntroductionMessages
    {
        private static readonly Random random = new Random();

        private static string[] introductionMessagesPool = new string[] {
            "{0} o meu nome é {1} e estou aqui para {2} ajudar :)\nCaso não se esteja bem pode dizer-me o que sente e eu ajudo-{3} a marcar uma consulta no nosso hospital",
            "{0} eu chamo-me {1} e estou aqui para {2} ajudar :)\nCaso não se esteja bem pode dizer-me o que sente e eu ajudo-{3} a marcar uma consulta no nosso hospital"
        };

        public static string GenerateIntroductionMessage(int gender){
            string message = introductionMessagesPool[random.Next(introductionMessagesPool.Length)];

            string genderString = "o";
            string botName = "Bot";

            if(gender == 0){
                genderString = "a";
            }

            return String.Format(message, "Bom dia", botName, genderString, genderString);
        }
    }
}
