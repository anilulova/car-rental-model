

namespace Kursova.DomainModel.LookUps
{
    public class RentalInfo
    {
        public RentalInfo(int period, decimal totalSum) => (Period, TotalSum) = (period, totalSum);

        public int Period { get;  }
        

        public string CarClass { get; set; }

        public decimal TotalSum { get; set; }
        

        public override string ToString()
        {
            return $"Period: {Period}\n" +
                   $"Total: {TotalSum}\n";
        }
    }
}
