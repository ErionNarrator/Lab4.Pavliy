using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Monster<T>:ICloneable,IComparable
    {
        public T? Id { get; set; }
        public string? Name { get; set; }
        public int Health { get; set; }
        public int Ammo { get; set; }
        public static int Count = 0;
        public object Clone()
        {
            return new Monster<T>()
            {
                Id=this.Id,
                Name=this.Name,
                Health=this.Health,
                Ammo=this.Ammo
            };
        }
        public int CompareTo(object? obj)
        {
            if(obj is Monster<T>)
            {
                Monster<T>? monster = obj as Monster<T>;
                return this.Health.CompareTo(monster!.Health);
            }
            else throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
