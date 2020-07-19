using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova.DomainModel.LookUps
{
    public class Car
    {
        public Car(CarClassesEnum carClass, CarTypeEnum carType, int seats, DoorsEnum doorsEnum, GearBoxEnum gearBoxEnum,
            EngineSpecification engine, BrandInfo brandInfo, ICollection<Extra> extras = null)
       => (Id, CarClass, Type, Seats, Doors, GearBoxType, EngineSpecification, BrandInfo, Extras) =
            (Guid.NewGuid(), carClass, carType, seats, doorsEnum, gearBoxEnum,
            new EngineSpecification(engine), brandInfo, new List<Extra>(extras));

        public Guid Id { get; set; }
        public CarClassesEnum CarClass { get; set; }
        public CarTypeEnum Type { get; set; }
        public int Seats { get; set; }
        public DoorsEnum Doors { get; set; }
        public GearBoxEnum GearBoxType { get; set; }
        public EngineSpecification EngineSpecification { get; set; }
        public ICollection<Extra> Extras { get; set; }
        public BrandInfo BrandInfo { get; set; }

        public bool Equals(Car car)
        {
            return car != null && Id == car.Id;
        }

        public override string ToString()
        {
            int element = 1;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Extra item in Extras)
            {
                stringBuilder.AppendLine($"Extra No {element++}");

                stringBuilder.AppendLine(item.ToString());
            }

            return $"Car class: {CarClass}\n" +
                   $"Car type: {Type}\n" +
                   $"Seats: {Seats}\n" +
                   $"Doors type: {Doors}\n" +
                   $"Gear box type: {GearBoxType}\n" +
                   $"Engine specification:\n{EngineSpecification}\n" +
                   $"Extras:\n\n{stringBuilder}\n" +
                   $"Brand info\n\n{BrandInfo}\n";
        }
    }
}
