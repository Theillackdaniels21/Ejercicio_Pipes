using System;
using System.Drawing;
using Ucu.Poo.Discord;

namespace Ucu.Poo.PipesAndFilters.Filters
{
    public class FilterDiscord : IFilter
    {
        private ulong channelId;
        private DiscordClient discord;

        public FilterDiscord()
        {
            string botToken = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
            string channelText = Environment.GetEnvironmentVariable("CHANNEL_ID");
            if (string.IsNullOrWhiteSpace(botToken) || string.IsNullOrWhiteSpace(channelText))
            {
                Console.WriteLine("Faltan las variables de entorno 'DISCORD_BOT_TOKEN' y 'CHANNEL_ID'.");
                return;
            }

            this.channelId = ulong.Parse(channelText);
            this.discord = new DiscordClient();

            discord.Login(botToken);
        }

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, "tmp.jpg");
            discord.SendImage(channelId, "tmp.jpg", "¡Nueva imagen filtrada!");
            return image;
        }

    }
}