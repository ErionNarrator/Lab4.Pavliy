using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class AmmoComparator : IComparer
    {
        public int Compare(object? x, object? y)
        {
            // Проверяем, являются ли x и y массивами Monster<int>
            if (x is Monster<int>[] && y is Monster<int>[])
            {
                var monsters1 = x as Monster<int>[];
                var monsters2 = y as Monster<int>[];

                // Сравниваем длины массивов
                if (monsters1.Length > monsters2.Length) return 1;
                else if (monsters1.Length < monsters2.Length) return -1;

                // Если длины массивов равны, сравниваем по элементам
                for (int i = 0; i < monsters1.Length; i++)
                {
                    if (monsters1[i].Ammo > monsters2[i].Ammo) return 1;
                    else if (monsters1[i].Ammo < monsters2[i].Ammo) return -1;
                }

                // Если все элементы равны, возвращаем 0
                return 0;
            }
            throw new Exception("Невозможно сравнить массивы");
        }
    }
}
