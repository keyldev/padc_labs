using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string? _resultText;

        public string ResultText
        {
            get { return _resultText ?? "null"; }
            set { _resultText = value; NotifyPropertyChanged(); }
        }
        public RelayCommand ResumeZero { get; set; }
        public RelayCommand ResumeFirst { get; set; }
        public RelayCommand SuspendZero { get; set; }
        public RelayCommand SuspendFirst { get; set; }
        public RelayCommand ShowResult { get; set; }
        private int counter = 0;

        public MainWindowModel()
        {
            Thread thread_1 = new Thread(func_1);
            Thread thread_2 = new Thread(func_2);

            thread_1.Start();
            thread_2.Start();

            ResumeZero = new RelayCommand(o =>
            {
                thread_1.Resume();
            });
            ResumeFirst = new RelayCommand(o =>
            {
                thread_2.Resume();
            });
            SuspendZero = new RelayCommand(o =>
            {
                thread_1.Suspend();
            });
            SuspendFirst = new RelayCommand(o =>
            {
                thread_2.Suspend();
            });
            ShowResult = new RelayCommand(o =>
            {
                ResultText = counter.ToString();
            });

        }
        private void func_1(object? obj)
        {
            for (; ; )
            {
                counter++;
                ResultText = counter.ToString();
            }
        }
        private void func_2(object? obj)
        {
            for (; ; )
            {

                counter--;
                ResultText = counter.ToString();
            }
        }


    }
}
