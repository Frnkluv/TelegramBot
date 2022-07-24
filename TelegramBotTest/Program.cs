using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;


namespace TelegramBotTest
{
    class Program
    {
        private const string TOKEN = "che-to123";
        private static TelegramBotClient botClient;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(TOKEN);
            
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot '{me.FirstName}' started! \t id: {me.Id}");

            botClient.StartReceiving();
            botClient.OnMessage += OnMessageHandler;
            Console.ReadLine();
            botClient.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.Write("Пришло сообщение с текстом: " + msg.Text + "\t");
                Console.WriteLine($"Тип: {msg.Text.GetType()}");

                // вынести эту конструкцию в метод
                try
                {
                    // если мало вариантов кейсов, то лучше делать через if, тк шустрее робит.
                    switch (msg.Text)
                    {
                        case "Расчет КБЖУ":
                            // Подключить сюда БД?
                            // Реализовать кейсы через словарь dict ?
                            await botClient.SendTextMessageAsync(msg.Chat.Id, TextFormula.Formula());


                            break;


                        case "Стикер":
                            var stic = await botClient.SendStickerAsync(
                                chatId: msg.Chat.Id,
                                sticker: "https://tlgrm.ru/_/stickers/b6d/bc8/b6dbc819-573d-3876-a7f1-36d76d1f1a9f/192/54.webp",
                                replyMarkup: Buttons.GetButtons());
                            break;

                        
                        case "Источники БЖУ":
                            await botClient.SendTextMessageAsync(msg.Chat.Id, FoodSourses.PFC());
                            break;

                        
                        case "Рекомендации":
                            // Можно добавить доп.параметр ответ на смс replyToMessage: msg.MessageId
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "В разработке", replyMarkup: Buttons.GetButtons());
                            break;

                        
                        default:
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: Buttons.GetButtons());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}









/* НЕРАБОЧАЯ ДРЯНЬ */
/*
 *  написать метод который принимает два параметра (вес, рост) и подставляются в формулу.     !!!  метод(а, б, out result)
 *  
    await client.SendTextMessageAsync(msg.Chat.Id, "Введите возраст:");
    int age = int.Parse(msg.Text);
    
    int weight = 1;
    if (weight > 0)
    {
        await client.SendTextMessageAsync(msg.Chat.Id, "Введите возраст:");
        //int age = Convert.ToInt32(msg.Text);
        //if (age > 0) { }
    }

        //private async void SendNumber(MessageEventArgs e)
        //{
        //    var message = e.Message;
        //    double weight = double.Parse(message.Text);
        //    if (weight is double w)
        //    {
        //        w = 4.99 * weight;
        //        await botClient.SendTextMessageAsync(message.Chat.Id, "Введите рост (см): ");
        //    }
        //}


    if (msg.Text is String num)
    {
                            
        // надо написать что-то, чтобы компил останавливался/ждал действие (новое смс)
        int numInt = int.Parse(num);    // ошибка
        Console.WriteLine("55");

        // Не заходит сюда,т.к. сообщение и от бота и от чел-ка в переменной "e.Message" и при КАЖДОМ смс
        // начинается все с начала метода.
        // После нажатия/написания  "Расчет КБЖУ" прога выходит из метода, а при последующем смс все по новой.
    }
 

    // не сработало в данный свитч не заходит, тк по колл стеку поднимается вверх
            case "Расчет КБЖУ":
            await botClient.SendTextMessageAsync(msg.Chat.Id, "Введите вес:");

            switch (msg.Text)       // не заходит в этот свитч. Сразу выходит через break.
            {
                case "70":
                    double a = double.Parse(msg.Text);
                    double b = a * 10;
                    var res_70 = Convert.ToString(b);
                    await botClient.SendTextMessageAsync(msg.Chat.Id, res_70);
                    break;
            }
            break;
 


    // было написано в " case "Расчет КБЖУ" "
            SendNumber(msg.Text);

            async void SendNumber(string message)
            {
                double weight = double.Parse(message);      // FormatExeption !!!
                double w = 4.99 * weight;
                var w_res = Convert.ToString(w);

                await botClient.SendTextMessageAsync(msg.Chat.Id, $"Проверка: ответ - {w_res}");
            }
            break;

*/  
