using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2.Model
{
    public class MyArray
    {
        public int[] Arr { get; set; }

        int sum = 0, num = 0, max = -100;

        private int sumArray;
        public int SumArray
        {
            get
            {
                for (int i = 0; i < Arr.Length; i++)
                    sum += Arr[i];

                return sumArray;
            }
            
        }

        private int sumPosArray;
        public int SumPosArray
        {
            get
            {
                for (int i = 0; i < Arr.Length; i++)
                    if (max < Arr[i])
                    {
                        max = Arr[i]; //Максимальное значение
                        num = i + 1; //Номер элемента массива с максимальным значением
                    }
                for (int j = num - 2; j >= 0; j--)
                {
                    if (Arr[j] > 0)
                        sum += Arr[j]; //Сумма положительных элементов после максимального
                }

                return sumPosArray;
            }
        }
    }
}