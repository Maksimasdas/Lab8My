using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Lab8My.Models
{
    internal class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Cars.AddRange(new Car[]
            {
                new Car {Name = "Фольксваген", Model = "Мультиван", Vin="1111111111111", Number = "9578АС-7"},
                new Car {Name = "Фольксваген", Model = "Крафтер", Vin="2222222222222", Number = "7845КА-7"},
                new Car {Name = "Фольксваген", Model = "Т5", Vin="333333333333", Number = "1532ВА-7"},
                new Car {Name = "Джили", Model = "Атлас", Vin="4444444444444", Number = "9752ВА-7"},
                new Car {Name = "Джили", Model = "Атлас Про", Vin="5555555555555", Number = "7896ЕН-7"},
                new Car {Name = "ГАЗ", Model = "A22R33", Vin="6666666666666", Number = "7423АР-7"},
                new Car {Name = "МАЗ", Model = "4317", Vin="7777777777777", Number = "4562МА-7"},
            });
        }
    }
}
