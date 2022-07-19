using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotTest
{
    internal static class Buttons
    {
        internal static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Расчет КБЖУ"}, new KeyboardButton { Text = "Источники БЖУ"} },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Рекомендации" }, new KeyboardButton { Text = "Стикер" } }
                }
            };
        }
    }
}
