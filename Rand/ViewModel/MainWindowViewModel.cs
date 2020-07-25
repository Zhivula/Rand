using Rand.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rand.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string start;
        private string finish;
        private string result;
        private string count;

        public string Start
        {
            get => start;
            set
            {
                start = value;
                OnPropertyChanged(nameof(Start));
            }
        }
        public string Finish
        {
            get => finish;
            set
            {
                finish = value;
                OnPropertyChanged(nameof(Finish));
            }
        }
        public string Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public string Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public MainWindowViewModel()
        {

        }
        /// <summary>
        /// Начало генерации чисел 
        /// </summary>
        public ICommand GenerateNumbers => new DelegateCommand(o =>
        {
            MainWindowModel model = new MainWindowModel(int.Parse(start), int.Parse(finish), int.Parse(count));
            string result = string.Empty;
            foreach (var i in model.GetList()) result += i.ToString()+"   "; 
            Result = result;
        });
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
