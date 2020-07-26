using Rand.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rand.Model
{
    class MainWindowModel
    {
        private int start;
        private int finish;
        private int count;
        public MainWindowModel(int start, int finish, int count)
        {
            this.start = start;
            this.finish = finish;
            this.count = count;
        }
        public List<int> GetList()
        {
            Random rand = new Random();
            var list = new List<int>(count);
            finish++;//finish+1 - это чтобы было включительное значение, по умолчанию не включительно 
            for(var i = 0; i < count; i++) list.Add(rand.Next(start, finish));
            return list;
        }
        /// <summary>
        /// Конвертирует входные строковые данные в данные типа float.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        ///     true - можно преобразовать;
        ///     false - ошибка преобразования;
        /// </returns>
        public static TryConvertMessage TryConvertStringToInt(string value)
        {
            //Для начала просто проверям на пустоту входную строку.
            if (!string.IsNullOrWhiteSpace(value))
            {
                //если пользователь ввел действительно число, но через точку,
                //то мы его просто заменим на нужную нам запятую, чтобы лишний раз не напрягать пользователя.
                //value = value.Replace('.', ',');

                if (int.TryParse(value, out int result))
                {
                    //Вводимое число обязательно должно быть не меньше нуля, иначе нет сработает.
                    if (result >= 0)
                    {
                        return new TryConvertMessage(true, "");
                    }
                    else return new TryConvertMessage(false, "Входные данные меньше нуля");
                }
                else return new TryConvertMessage(false, "Неудалось выполнить преобразование");
            }
            else return new TryConvertMessage(false, "Попытка ввести пустую строку");
        }
    }
    class TryConvertMessage
    {
        public readonly string message;
        public readonly bool flag;

        public TryConvertMessage(bool flag, string message)
        {
            this.message = message;
            this.flag = flag;
        }
    }
}
