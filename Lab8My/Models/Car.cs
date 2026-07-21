using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8My.Models
{
    public class Car : ICloneable
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Vin {  get; set; }
        public string Number { get; set; }



        public object Clone()
        {
            return MemberwiseClone();
        }

        public void Clone(ref Car target)
        {
            target.CarId = CarId;
            target.Name = Name;
            target.Model = Model;
            target.Vin = Vin;
            target.Number = Number;
        }
    }
}
