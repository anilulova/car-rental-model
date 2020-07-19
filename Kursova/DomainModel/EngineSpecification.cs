

namespace Kursova.DomainModel.LookUps
{
    public class EngineSpecification
    {
        public EngineSpecification(EngineSpecification engineSpecifications)
        {
            Capacity = engineSpecifications.Capacity;
            HorsePowers = engineSpecifications.HorsePowers;
            FuelType = engineSpecifications.FuelType;
        }
        
        public EngineSpecification(float capacity, int horsePowers, FuelTypeEnum fuelType)
        => (Capacity, HorsePowers, FuelType) = (capacity, horsePowers, fuelType);

        public float Capacity { get; }
        public int HorsePowers { get; }
        public FuelTypeEnum FuelType { get; }

        public override string ToString()
        {
            return $"Capacity: {Capacity}\n" +
                   $"Horse powers: {HorsePowers}\n" +
                   $"Fuel type: {FuelType}\n";
        }
    }
}