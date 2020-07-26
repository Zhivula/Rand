﻿using Rand.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rand.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string start;
        private string finish;
        private string result;
        private string count;

        private SolidColorBrush borderCount;
        private SolidColorBrush borderFinish;
        private SolidColorBrush borderStart;

        public string Start
        {
            get => start;
            set
            {
                start = value;
                OnPropertyChanged(nameof(Start));
                if (!MainWindowModel.TryConvertStringToInt(value).flag) BorderStart = new SolidColorBrush(Colors.Red);
                else BorderStart = new SolidColorBrush(Colors.Blue);
            }
        }
        public string Finish
        {
            get => finish;
            set
            {
                finish = value;
                OnPropertyChanged(nameof(Finish));
                if (!MainWindowModel.TryConvertStringToInt(value).flag) BorderFinish = new SolidColorBrush(Colors.Red);
                else BorderFinish = new SolidColorBrush(Colors.Blue);
            }
        }
        public string Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
                if (!MainWindowModel.TryConvertStringToInt(value).flag) BorderCount = new SolidColorBrush(Colors.Red);
                else BorderCount = new SolidColorBrush(Colors.Blue);
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


        public SolidColorBrush BorderCount
        {
            get => borderCount;
            set
            {
                borderCount = value;
                OnPropertyChanged(nameof(BorderCount));
            }
        }
        public SolidColorBrush BorderFinish
        {
            get => borderFinish;
            set
            {
                borderFinish = value;
                OnPropertyChanged(nameof(BorderFinish));
            }
        }
        public SolidColorBrush BorderStart
        {
            get => borderStart;

            set
            {
                borderStart = value;
                OnPropertyChanged(nameof(BorderStart));
            }
        }

        public MainWindowViewModel()
        {
            BorderCount = new SolidColorBrush(Colors.Blue);//"#FF468AFF"
            BorderFinish = new SolidColorBrush(Colors.Blue);
            BorderStart = new SolidColorBrush(Colors.Blue);
        }
        /// <summary>
        /// Начало генерации чисел 
        /// </summary>
        public ICommand GenerateNumbers => new DelegateCommand(o =>
        {
            if (MainWindowModel.TryConvertStringToInt(start).flag && MainWindowModel.TryConvertStringToInt(finish).flag && MainWindowModel.TryConvertStringToInt(count).flag)
            {
                MainWindowModel model = new MainWindowModel(int.Parse(start), int.Parse(finish), int.Parse(count));
                string result = string.Empty;
                foreach (var i in model.GetList()) result += i.ToString() + "   ";
                Result = result;
            }
            else
            {
                if (!MainWindowModel.TryConvertStringToInt(count).flag) MessageBox.Show(MainWindowModel.TryConvertStringToInt(count).message);
                if (!MainWindowModel.TryConvertStringToInt(start).flag) MessageBox.Show(MainWindowModel.TryConvertStringToInt(start).message);
                if (!MainWindowModel.TryConvertStringToInt(finish).flag) MessageBox.Show(MainWindowModel.TryConvertStringToInt(finish).message);
            }
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