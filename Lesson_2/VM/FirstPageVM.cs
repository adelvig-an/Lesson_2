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
        }

        private int[] newArray;
        public int[] NewArray
        {
            get => newArray;
            set => SetProperty(ref newArray, value);
        }

        private readonly int sum;
        public int Sum
        {
            get => sum;
            set
            {
                int sum = 0;
                for (int i = 0; i < NewArray.Length; i++)
                    sum += NewArray[i];
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
