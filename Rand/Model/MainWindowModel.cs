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
        private bool isChecked;
        public MainWindowModel(int start, int finish, int count, bool isChecked)
        {
            this.start = start;
            this.finish = finish;
            this.count = count;
            this.isChecked = isChecked;
        }
        public List<int> GetList()
        {
            Random rand = new Random();
            var list = new List<int>(count);
            finish++;//finish+1 - это чтобы было включительное значение, по умолчанию не включительно 
            if (finish < start) Swap();/*Для получения рандомного числа нужно обязательно, чтобы start<finish
            и если пользователь ввел данные не в те поля, программа просто поменяет значения и продолжит работу*/

            if (isChecked)
            {
                if (Math.Abs(finish - start) >= count)
                {
                    var nextValue = 0;
                    for (var i = 0; i < count; i++)
                    {
                        nextValue = rand.Next(start, finish);
                        if (list.Contains(nextValue)) i--;
                        else list.Add(nextValue);
                    }
                }
                else MessageBox.Show("В данном диапазоне чисел невозможно получить значения без повторений.");
            }
            else
            {
                for (var i = 0; i < count; i++) list.Add(rand.Next(start, finish));
            }
                
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
        public static TryConvertBox TryConvertStringToInt(string value)
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
                        return new TryConvertBox(true, "");
                    }
                    else return new TryConvertBox(false, "Входные данные меньше нуля");
                }
                else return new TryConvertBox(false, "Неудалось выполнить преобразование");
            }
            else return new TryConvertBox(false, "Попытка ввести пустую строку");
        }
        private void Swap()
        {
            var box = finish;
            finish = start;
            start = box;
        }
    }
    class TryConvertBox
    {
        public readonly string message;
        public readonly bool flag;

        public TryConvertBox(bool flag, string message)
        {
            this.message = message;
            this.flag = flag;
        }
    }
}
