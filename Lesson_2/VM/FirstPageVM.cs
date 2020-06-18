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

        private string[] text;
        public string[] Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private int[] newArray;
        public int[] NewArray
        {
            get => newArray;
            set => SetProperty(ref newArray, value);
        }

        private bool TryPaseArray = int.TryParse(Text, out NewArray);

        int sum = 0, num = 0, max = -100;

        private int sumArray;
        public int Sum
        {
            get => sumArray;
            set
            {
                for (int i = 0; i < NewArray.Length; i++)
                    sum += NewArray[i];
            }
        }

        private int sumPosArray;
        public int SumPosArray
        {
            get => sumPosArray;
            set
            {
                for (int i = 0; i < NewArray.Length; i++)
                    if (max < NewArray[i])
                    {
                        max = NewArray[i]; //Максимальное значение
                        num = i + 1; //Номер элемента массива с максимальным значением
                    }
                for (int j = num - 2; j >= 0; j--)
                {
                    if (NewArray[j] > 0)
                        sum += NewArray[j]; //Сумма положительных элементов после максимального
                }
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
