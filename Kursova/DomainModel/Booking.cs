using System;

namespace Kursova.DomainModel.LookUps
{
    public class Booking
    {
        public Booking(Guid id, DateTime pickUpDate, DateTime dropOffDate, string pickUpLocation, string dropOffLocation,
            string clientRequestInfo, Car carToBook, RentalInfo rentalInfo)
            => (Id, PickUpDate, DropOffDate, PickUpLocation,
            DropOffLocation, ClientAdditionalInfo, CarToBook, RentalInfo)
            = (id, pickUpDate, dropOffDate, pickUpLocation,
            dropOffLocation, clientRequestInfo, carToBook, rentalInfo);


        public Guid Id { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string ClientAdditionalInfo { get; set; }
        public Car CarToBook { get; set; }
        public RentalInfo RentalInfo { get; set; }
       
        public bool Equals(Booking booking)
        {
            return booking != null && Id == booking.Id; 
        }

        public override string ToString()
        {
            return $"Pick up date: {PickUpDate.ToShortDateString()}\n" +
                   $"Drop off date: {DropOffDate.ToShortDateString()}\n" +
                   $"Pick up location: {PickUpLocation}\n" +
                   $"Drop off location: {DropOffLocation}\n" + 
                   $"Client additional info: {ClientAdditionalInfo}\n\n" + 
                   $"Car:\n\n{CarToBook}\n" +
                   $"Rental info:\n\n{RentalInfo}\n";
        }
    }
}