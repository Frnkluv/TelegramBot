using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotTest
{
    internal class TextFormula
    {
        internal static string Formula()
        {
            string formula = "Подставьте свои данные в необходимую формулу." +
                                "\nПолученный результат надо умножить на коэф. активности." +
                                "\nРезультат получается приближенный, далее лучше всего проконсультироваться с вашим тренером." +
                                "\nУдачи!\n" +
                                "\nМуж: BMR = [9.99 x вес (кг)] + [6.25 x рост (см)] - [4.92 x возраст (в годах)] + 5\n" +
                                "\nЖен: BMR = [9.99 x вес(кг)] + [6.25 x рост(см)] - [4.92 x возраст(в годах)] - 161";
            return formula;
        }
    }
}
