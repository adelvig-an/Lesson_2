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

            //var IntArray = int.TryParse(StrArray, out int value);
            //var StrArr = Str.Split();
            
            //for (int i = 0; i < StrArr.Length; i++)
            //{
            //    if (int.TryParse(StrArr[i], out int value))
            //    {
            //        NewArray[i] = value;
            //    }
            //    else
            //        break;
                
            //    //var IntArray = int.TryParse(StrArr, out int NewArray);
            //}
        }

        private string str;
        public string Str
        {
            get => str;
            set
            {
                SetProperty(ref str, value);
                var StrArr = Str.Split();
                for (int i = 0; i < StrArr.Length; i++)
                {
                    if (int.TryParse(StrArr[i], out int nmb))
                    {
                        NewArray[i] = nmb;
                    }
                    else
                        break;
                }
            }

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
