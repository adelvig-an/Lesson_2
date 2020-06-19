using Lesson_2.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Windows.Input;

namespace Lesson_2.VM
{
    public class FirstPageVM : PageVM
    {
        public MyArray MyArray { get; }

        public FirstPageVM()
        {
            MyArray = new MyArray
            {
                Arr = NewArray
            };
            Result = new RelayCommand(_ => ResultAction(MyArray));

            var IntArray = int.TryParse(StrArray, out int value);
        }

        private string strArray;
        public string StrArray
        {
            get => strArray;
            set => SetProperty(ref strArray, value);
        }

        private int[] newArray;
        public int[] NewArray
        {
            get => newArray;
            set
            {
                SetProperty(ref newArray, value);
            }
        }

        public ICommand Result { get; }
        public void ResultAction(MyArray myArray)
        {
            myArray.Arr = NewArray;
            OnPropertyChanged(nameof(MyArray));
        }
    }
}
