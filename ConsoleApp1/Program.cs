using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7482521603:AAFXnEbGHhNEGdeDqwMLMofIdHsWRpYkbMc");
bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, cancellationToken: cts.Token);

Console.WriteLine($"Bot is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel();
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    //ловим сообщения в консоль
{
    if (update.Type == UpdateType.Message && update.Message?.Text != null)
    {
        // Отображаем сообщение пользователя в консоли
        Console.WriteLine($"Received message from {update.Message.From.Username}: {update.Message.Text}");

        await knopka (update.Message);
    }
    else if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery != null)
    {
        await HandleCallbackQuery(update.CallbackQuery);
    }
}

async Task knopka (Message msg)//команды 
{
    if (msg.Text == "/start")
    {
        await bot.SendTextMessageAsync(msg.Chat, "Привет, выбери кнопочку.",//кнопки
            replyMarkup: new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Проверка", "check"),
                InlineKeyboardButton.WithCallbackData("вопрос1", "chair1"),
                InlineKeyboardButton.WithCallbackData("вопрос 2", "chair2"),
                InlineKeyboardButton.WithCallbackData("вопрос 3", "chair3"),
                }));
    }
    else if (msg.Text == "/Check" || msg.Text == "/check")
    {
        await bot.SendTextMessageAsync(msg.Chat, "Проверка бота: работа корректна");
    }
    else if (msg.Text == "Привет" || msg.Text == "привет")
    {
        await bot.SendTextMessageAsync(msg.Chat, "Здравствуй, пользователь.");
    }
    else
    {
        await bot.SendTextMessageAsync(msg.Chat, "Такой команды пока нет. Доступные команды: /check, /start");
    }
}

async Task HandleCallbackQuery(CallbackQuery callbackQuery)//нажатия кнопок
{
    var chatId = callbackQuery.Message.Chat.Id;

    switch (callbackQuery.Data)
    {
        case "check":
            await bot.SendTextMessageAsync(chatId, "Проверка бота: работа корректна");
            break;
        case "chair1":
            // вопрос 1
            var ros1 = "https://yandex-images.clstorage.net/99V3OWY33/e88e32v3zrE/2NKhSk_IBTLRU9KJkm66j0pIJUwXHRfNaJcNdVjdoAbJJK9lUhLQLdlFQx5LwaZqFEsx8CaHg5KDNqGfb1muFYzB9xrYWcUzlEEQGpTtvooZT3WJR5tWzL7UDO6DAWgahnt1uk5Z2r9YEINKzZNjuRoRdL8qWA6GGqsqmXCP_oBcU2UEg9bPv9mJV0DSqjKHH8omD0nTBYUqSRZjxwyrFIi5MziKWpr3E55JhYAKr3mdGKGzLNbCit4pZhj2jzAMFJMiRYJYhTaYgNdLFa2ywNMI4AgFUUoPr8EU7cpBrdJNOb97SpNb8Fzbys6ABuu8k13k-mUaCoQa5O8eMM0xAp2VYEPIGY2xHMKYiNVlOE2VwiiDTdNJQSWEnaLNjGKRwD2_s0dSVzAcks9DyIujulnfob_nXUBDnCts0PROsAjUkygFC17COVXJWcyZIfiDW8eqA47dhA0jThJhBQOjXk1xenvOGtI13BrMRgrFqnXfk-l1KZOJS5mj7FJ4DXrDEZurSItfhDOdxV3N0ySxARAALYuCXUaGqQRVqE0PZhJB8Hp2RJDdupnbw8ePg6s4HpCo9y9RQ4fUqe-WMEr-hZSTpQVLnwv6FcCfgNwiuwAUy-qEjFsEjiEOWm1GD2bfijgy8Q6eHDyZEs5CRssl992XqjxnWkpFXqmnX7mMeUwaFGiPAJgNsZgJ3gUcK3EIXUsiQc2bxEKsxVHsSAdtWwE5-jYLEpUwVB1CgcrJonCTnC50YldKixKopdExyn6H0hIgRUfXjbsfjljMFWz6zVPA7UnBGc2JpAFSZM4LZdRCcDt1wxFUPRPTyMsJwiv435SpvaITg4fbqeAVvgU3DNnVJwML0I-7kckXihKmM0DZguHIgZ4GhGMN0mxCxGgSxL7z-U9T2Dmbl8HByM1hcNDS6DKrkkeBHyIrGTkJO0MeFy-EAFvK_9XAlY_TKvGMEwUpiAUSBIJkAJajCQ";
            await bot.SendPhotoAsync(chatId, ros1);
            break;
        case "chair2":
            // вопрос 2
            var ros2 = "https://yandex.ru/images/search?text=%D0%BF%D0%B5%D1%80%D0%B2%D1%8B%D0%B5+%D0%BE%D0%BB%D0%B8%D0%BC%D0%BF%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B5+%D1%87%D0%B5%D0%BC%D0%BF%D0%B8%D0%BE%D0%BD%D1%8B+%D0%B3%D1%80%D0%B5%D1%86%D0%B8%D0%B8&pos=3&rpt=simage&img_url=https%3A%2F%2Fimage1.slideserve.com%2F3168660%2Fslide6-l.jpg&from=tabbar&lr=213";
            await bot.SendPhotoAsync(chatId, ros2);
            break;
        case "chair3":       
            // вопрос 3
            var ros3 = "https://yandex.ru/images/search?text=%D0%BF%D0%B5%D1%80%D0%B2%D1%8B%D0%B5+%D0%BE%D0%BB%D0%B8%D0%BC%D0%BF%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B5+%D0%B8%D0%B3%D1%80%D1%8B+%D1%81%D0%BE%D0%B2%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8&pos=2&rpt=simage&img_url=https%3A%2F%2Fvossport.ru%2Fmedia%2Fk2%2Fitems%2Fcache%2Fedc1d0314df26f4954651131e82a7939_XL.jpg&from=tabbar&lr=213";
            await bot.SendPhotoAsync(chatId, ros3);
            break;
        case "clear_chat":
            // удаление сообщений
            var messagesToDelete = 5; // кооличество сообщений для удаления
            for (int i = 0; i < messagesToDelete; i++)
            {
                try
                {

                    var messageIdToDelete = callbackQuery.Message.MessageId - i;
                    await bot.DeleteMessageAsync(chatId, messageIdToDelete);
                }
                catch (Exception ex)//мало сообщений для чистки
                {
                    Console.WriteLine($"Ошибка при удалении сообщения: {ex.Message}");
                }
            }
            await bot.SendTextMessageAsync(chatId, "Чат очищен!");
            break;
        default:
            await bot.SendTextMessageAsync(chatId, "Неизвестный выбор.");
            break;

    await bot.AnswerCallbackQueryAsync(callbackQuery.Id);
}




    }
Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine($"Error: {exception.Message}");
    return Task.CompletedTask;
}

