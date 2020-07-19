using Kursova.DomainModel.LookUps;
using System;
using System.Collections.Generic;
using System.Linq;
using Kursova.Writers;
using Kursova.Readers;
using Kursova.DomainModel;

namespace Kursova.Engines
{
    public class Engine
    {
        private Reader reader;

        private Writer writer;

        private List<Booking> bookings;

        private List<Car> cars;

        public Engine()
        {
            reader = new Reader();

            writer = new Writer();

            bookings = new List<Booking>();

            cars = new List<Car>();
        }

        // активира се главната функция на класа
        public void Run()
        {
            //Прочитат се командите
            ReadCommand();
        }

        // Отпечатване на менюто
        public void DisplayAdminMenu()
        {
            writer.WriteLine("Press 1 for adding a car");
            writer.WriteLine("Press 2 for adding a booking");
            writer.WriteLine("Press 3 for printing cars");
            writer.WriteLine("Press 4 for printing bookings");
            writer.WriteLine("Press 5 for removing a booking");
            writer.WriteLine("Press 6 for removing a car");
            writer.WriteLine("Press 7 for updating a booking");
            writer.WriteLine("Press 8 for updating a car");
            writer.WriteLine("Press exit for exit");
        }

        // Прочитане на команда
        public void ReadCommand()
        {
            while (true)
            {
                //Отпечатване на менюто
                DisplayAdminMenu();

                //Прочитане на команда
                string command = reader.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                //Активира се избранта функция
                ProccessCommand(command);
            }
        }

        public void ProccessCommand(string command)
        {
            switch (command)
            {
                //За добавяне на кола
                case "1":
                    ProccessAddCar();

                    break;

                //За добавяне на резервация
                case "2":
                    ProccessAddBooking();

                    break;

                //За отпечатване на всички коли
                case "3":
                    PrintCars();

                    break;

                //За отпечатване на всички резервации
                case "4":
                    PrintBookings();

                    break;

                //За премахване на резервация
                case "5":
                    ProccessRemoveBooking();

                    break;

                //За премахване на кола
                case "6":
                    ProccessRemoveCar();

                    break;

                //За промяна на резервация
                case "7":
                    ProccessUpdateBooking();

                    break;

                //За промяна на кола
                case "8":
                    ProccessUpdateCar();

                    break;

                default:
                    break;
            }
        }

        // Извеждат се резултатите от добавянето на кола
        public void ProccessAddCar()
        {
            try
            {
                Car car = InputCar();

                cars.Add(car);

                writer.WriteLine();

                writer.WriteLine("Added a car", ConsoleColor.Blue);

                writer.WriteLine();

                writer.WriteLine(car.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Извеждат се резултатие от добавянето на резервация
        public void ProccessAddBooking()
        {
            try
            {
                //Ако няма коли, няма как да се добави резервация
                if (cars.Count == 0)
                {
                    writer.WriteLine("First enter cars", ConsoleColor.Red);

                    return;
                }

                Booking booking = InputBooking();

                bookings.Add(booking);

                writer.WriteLine();

                writer.WriteLine("Added a booking", ConsoleColor.Blue);

                writer.WriteLine();

                writer.WriteLine(booking.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Извеждат се резултатие за премахване на резервация
        public void ProccessRemoveBooking()
        {
            try
            {
                //Ако няма резервации, няма как да се премахне
                if (bookings.Count == 0)
                {
                    writer.WriteLine("First Enter bookings", ConsoleColor.Red);

                    return;
                }

                Booking booking = InputBookingSelection();

                writer.WriteLine();

                bookings.Remove(booking);

                writer.WriteLine("Removed a booking", ConsoleColor.Blue);

                writer.WriteLine();

                writer.WriteLine(booking.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Извеждат се резултатие от премахването на кола
        public void ProccessRemoveCar()
        {
            try
            {
                //Ако няма коли, няма как да се премахне
                if (cars.Count == 0)
                {
                    writer.WriteLine("First Enter cars", ConsoleColor.Red);

                    return;
                }

                Car car = InputCarSelection();

                writer.WriteLine();

                cars.Remove(car);

                writer.WriteLine("Removed a car", ConsoleColor.Blue);

                writer.WriteLine();

                writer.WriteLine(car.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Извеждат се резултатие за промяна на резервация
        private void ProccessUpdateBooking()
        {
            try
            {
                //Ако няма резервации, няма как да се промени
                if (bookings.Count == 0)
                {
                    writer.WriteLine("First Enter bookings", ConsoleColor.Red);

                    return;
                }

                //Избира се текущата резервация
                Booking booking = InputBookingSelection();

                writer.WriteLine();

                //Отпечатва се съобщение да въведат данните
                writer.WriteLine("Enter new info for booking: ");

                //Въвежда се новата информация за резервацията
                Booking newBooking = InputBooking();

                //На мястото на избранта резервация, се задава информация за новата
                bookings[bookings.FindIndex(a => a.Equals(booking))] = newBooking;

                //Отпечатване, че е променена резервацията
                writer.WriteLine("Updated a booking", ConsoleColor.Blue);

                writer.WriteLine();

                //Отпечатване на информацията за старата резервация
                writer.WriteLine(booking.ToString());

                //Отпечатване, че се показва новата информация
                writer.WriteLine("New info: ");

                writer.WriteLine();

                //Отпечатване на информацияра за новата резервация
                writer.WriteLine(newBooking.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Извеждат се резултатие за промяна на кола
        public void ProccessUpdateCar()
        {
            try
            {
                //Ако няма коли, няма как да се промени
                if (cars.Count == 0)
                {
                    writer.WriteLine("First Enter cars", ConsoleColor.Red);

                    return;
                }

                //Избира се текущата кола
                Car car = InputCarSelection();

                writer.WriteLine();

                //Отпечатва съобщение да въведе данните
                writer.WriteLine("Enter new info for car: ");

                //Вевежда се новата информация
                Car newCar = InputCar();

                //На мястото на избранта кола, се задава информация за новата
                cars[cars.FindIndex(a => a.Equals(car))] = newCar;

                //Отпечатване, че е променена колата
                writer.WriteLine("Updated a car", ConsoleColor.Blue);

                writer.WriteLine();

                //Отпечатване на информацията за старата кола
                writer.WriteLine(car.ToString());

                //Отпечатване, че се показва нова информация
                writer.WriteLine("New info: ");

                writer.WriteLine();

                //Отпечатване на информацията за новата кола
                writer.WriteLine(newCar.ToString());

                writer.WriteLine();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Отпечатва резервациите
        public void PrintBookings()
        {
            try
            {
                writer.WriteLine("Bookings");

                writer.WriteLine();

                int element = 1;

                foreach (Booking item in bookings)
                {
                    //Извеждаме, кой номер е
                    writer.WriteLine($"Booking No {element++}");

                    //Извеждаме информацията
                    writer.Write(item.ToString());

                    writer.WriteLine("-------------");

                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }

        // Проверява дали дадена кола може да се наеме за дадени дати
        public bool IsBookingAvailable(Car car, DateTime pickUpDateTime,
            DateTime dropOffDateTime)
        {
            //Проверяваме всички резервации с тази кола
            foreach (Booking item in bookings
                .Where(a => a.CarToBook.Equals(car)))
            {
                //Ако избраната дата е в интервала между датата на добавяне, то тогава няма как да се наеме
                //Ако е в интервала между датата на наемане и датата на връщане, то тогава няма как да се наеме

                //Проверяваме, дали избраната дата за наемане не е в интервала между датите на текущата
                if (pickUpDateTime.Date >= item.PickUpDate.Date
                    && pickUpDateTime.Date <= item.DropOffDate.Date)
                {
                    return false;
                }

                //Ако е в интервала между датата на наемане и датата на връщане, то няма как да се наеме

                //Проверяваме, дали избраната дата за връщане не е в интервала между датите на текущата
                if (dropOffDateTime.Date >= item.PickUpDate.Date
                    && dropOffDateTime.Date <= item.DropOffDate.Date)
                {
                    return false;
                }
            }

            return true;
        }

        // Проверяваме кои са наличните дати за избрана кола, да бъде наета за определен период от време, спрямо дата на наемане и на връщане

        public Dictionary<DateTime, DateTime> GetFreeDates(Car car, DateTime pickUpDateTime,
            DateTime dropOffDateTime)
        {
            //Резултата
            Dictionary<DateTime, DateTime> dates =
                new Dictionary<DateTime, DateTime>();

            //Всички резервации с тази кола
            IEnumerable<Booking> items = bookings.Where(a => a.CarToBook.Equals(car));

            try
            {
                //Ако има някои резервации, на които датата на връщане е преди
                //датата на новото наемане, то те вече са минали
                //и няма нужда да ги проверяваме
                //Ако няма такива, трябва да прихванем случай, защото 
                //ще се хвърли изключение
                items = items.Where(a => a.DropOffDate.Date >= pickUpDateTime.Date);

            }
            catch (Exception)
            {

            }

            //На предишната резервация, датата на връщане
            //Инициализираме я с първата, от резервациите
            DateTime prevDropOffDateTime = items.First().DropOffDate;

            //Дали е намерена поне една дата
            bool foundAtLEastOne = false;

            //Интервалът, за който искам да се наеме колата
            TimeSpan timeSpan = dropOffDateTime.Date
                .Subtract(pickUpDateTime.Date);

            //Взели сме вече датата на първата поръчка, и затова няма нужда
            //да минаваме през нея, тъй като вече сме я запазили в променлива
            foreach (Booking item in items.Skip(1))
            {
                //Проверяваме дали на текущата резервация, 
                //предишния ден, на датата на наемане
                //е след този на следващия ден на датата на връщане
                //на предишната резервация
                if (item.PickUpDate.Date.AddDays(-1).Date
                    >= prevDropOffDateTime.Date.AddDays(1).Date)
                {
                    //Проверяваме дали интервалът между датата
                    //на наемане на текущата резервация, предишния ден,
                    //е след следващия ден на датата на наемане
                    //на предишната поръчка
                    if (item.PickUpDate.Date.AddDays(-1).Date
                        .Subtract(prevDropOffDateTime.Date.AddDays(1)).TotalDays
                        >= timeSpan.TotalDays)
                    {
                        //Ако е така, то тя е добър резултат за избор
                        //Добавяме я към резултата
                        dates.Add(prevDropOffDateTime.Date.AddDays(1),
                            item.PickUpDate.Date.AddDays(-1));

                        //Намерили сме поне една дата
                        foundAtLEastOne = true;

                        //Няма нужда да търсим още, тъй като сме намерили първата с този интервал
                        break;
                    }

                    //Ако няма още добавени дати, не е намерена
                    if (!foundAtLEastOne)
                    {
                        //Намерена е, тъй като горната проверка казва, че има
                        //интервал от време между датата на напускане на 
                        //предишната резервация и датата на наемане на сегашната резервация
                        foundAtLEastOne = true;

                        //Добавяме я към резултата, тя е 1-вата дата
                        dates.Add(prevDropOffDateTime.Date.AddDays(1),
                            item.PickUpDate.Date.AddDays(-1));
                    }
                }

                //Задаваме стойността на предишната дата на напускане 
                //на резервация, да е тази, на текущата резервация
                prevDropOffDateTime = item.DropOffDate;
            }

            //Ако не е намерена нито една свободна дата между поръчките
            //то можем да предложим тази след последната
            //Добавяме към следващия ден на датата на напускане на последната
            //поръчка, интервалът, който е бил избран
            if (!foundAtLEastOne)
            {
                //Добавя се в резултата
                dates.Add(prevDropOffDateTime.Date.AddDays(1), prevDropOffDateTime.Date.AddDays(1).Add(timeSpan));
            }

            return dates;
        }

        // Отпечатват се всички коли
        public void PrintCars()
        {
            try
            {
                writer.WriteLine("Cars");

                writer.WriteLine();

                int element = 1;

                foreach (Car item in cars)
                {
                    //Отпечатва се номера на текущата кола
                    writer.WriteLine($"Car No {element++}");

                    //Отпечатва се информация за текущата кола
                    writer.Write(item.ToString());

                    writer.WriteLine("-------------");

                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message, ConsoleColor.Red);

                writer.WriteLine();
            }
        }


        // Въвежда се информация за марката
        public BrandInfo InputBrandInfo()
        {
            writer.WriteLine("Input brand info");

            string brand;

            while (true)
            {
                writer.WriteLine("Enter brand: ");

                brand = reader.ReadLine();
                writer.WriteLine();

                if (brand.Length == 0 || !brand.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }

            string model;

            while (true)
            {
                writer.WriteLine("Enter model: ");

                model = reader.ReadLine();
                writer.WriteLine();

                if (model.Length == 0 || !model.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }

            return new BrandInfo(brand, model);
        }

        public Extra InputExtra()
        {
            writer.WriteLine("Input extra");

            string extraType;

            while (true)
            {
                writer.WriteLine("Enter extra type: ");

                extraType = reader.ReadLine();
                writer.WriteLine();

                if (extraType.Length == 0 || !extraType.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }
            return new Extra(extraType);
        }

        // Въвежда се информация за цената на наемане
        public RentalInfo InputRentalInfo()
        {
            writer.WriteLine("Input rental info");

            int period;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter period value: ");

                    period = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (period <= 0)
                    {
                        writer.WriteLine("Enter period greater than zero", ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            CarClassesEnum[] carClasses = new CarClassesEnum[]
            {
                CarClassesEnum.Economy,
                CarClassesEnum.Comfort,
                CarClassesEnum.Luxury
            };

            CarClassesEnum carClass;

            while (true)
            {
                try
                {
                    writer.WriteLine("Car class: ");

                    int number = 1;

                    foreach (CarClassesEnum item in carClasses)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }

                    writer.Write("Enter number: ");

                    int selectedCarClassNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedCarClassNumber <= 0 || selectedCarClassNumber > carClasses.Length)
                    {
                        writer.WriteLine("Enter a valid number");

                        continue;
                    }

                    carClass = carClasses[selectedCarClassNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            decimal rentalPrice = 0;

            if (carClass == CarClassesEnum.Economy)
            {
                rentalPrice = period * 50.00M;

                if (period >= 1 && period <= 5)
                {
                    rentalPrice = (period * 50.00M) * 0.9M;
                }
                else if (period > 5 && period <= 10)
                {
                    rentalPrice = (period * 50.00M) * 0.8M;
                }
                else if (period > 10)
                {
                    rentalPrice = (period * 50.00M) * 0.7M;
                }

            }
            else if (carClass == CarClassesEnum.Comfort)
            {
                rentalPrice = period * 70.00M;


                if (period >= 1 && period <= 5)
                {
                    rentalPrice = (period * 70.00M) * 0.9M;
                }
                else if (period > 5 && period <= 10)
                {
                    rentalPrice = (period * 70.00M) * 0.8M;
                }
                else if (period > 10)
                {
                    rentalPrice = (period * 70.00M) * 0.7M;
                }
            }
            else if (carClass == CarClassesEnum.Luxury)
            {
                rentalPrice = period * 90.00M;


                if (period >= 1 && period <= 5)
                {
                    rentalPrice = (period * 90.00M) * 0.9M;
                }
                else if (period > 5 && period <= 10)
                {
                    rentalPrice = (period * 90.00M) * 0.8M;
                }
                else if (period > 10)
                {
                    rentalPrice = (period * 90.00M) * 0.7M;
                }
            }
            Console.WriteLine("Total price for selected car is: {0:f2} lv.", rentalPrice);
            writer.WriteLine();
            return new RentalInfo(period, rentalPrice);
        }

        // Въвеждане на спецификация
        public EngineSpecification InputEngineSpecification()
        {
            writer.WriteLine("Input Engine specification");

            float capacity;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter capacity value: ");

                    capacity = float.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (capacity <= 0)
                    {
                        writer.WriteLine("Enter capacity value greater than zero", ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            int horsePowers;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter horse powers value: ");

                    horsePowers = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (horsePowers <= 0)
                    {
                        writer.WriteLine("Enter horse powers value greater than zero", ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            FuelTypeEnum[] fuelTypes = new FuelTypeEnum[]
            {
                FuelTypeEnum.Petrol,
                FuelTypeEnum.LPG,
                FuelTypeEnum.Diesel,
                FuelTypeEnum.LPGOrPetrol,
                FuelTypeEnum.Electric,
                FuelTypeEnum.Hybrid
            };

            FuelTypeEnum fuelType;

            while (true)
            {
                try
                {
                    writer.WriteLine("Fuel types: ");

                    int number = 1;

                    //Изборява се всяка възможност и нейният номер
                    foreach (FuelTypeEnum item in fuelTypes)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }

                    writer.Write("Enter number: ");

                    int selectedFuelTypeNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedFuelTypeNumber <= 0 || selectedFuelTypeNumber > fuelTypes.Length)
                    {
                        writer.WriteLine("Enter a valid number");

                        continue;
                    }

                    //текущата стойност е тази, която е избрана
                    //от масива с всички възможности за стойността
                    fuelType = fuelTypes[selectedFuelTypeNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }
            return new EngineSpecification(capacity, horsePowers, fuelType);
        }

        // Въвеждане на кола
        public Car InputCar()
        {
            writer.WriteLine("Input Car");

            Guid id = new Guid();
            writer.WriteLine();

            CarClassesEnum[] carClasses = new CarClassesEnum[]
            {
                CarClassesEnum.Economy,
                CarClassesEnum.Comfort,
                CarClassesEnum.Luxury
            };

            CarClassesEnum carClass;

            while (true)
            {
                try
                {
                    writer.WriteLine("Car class: ");

                    int number = 1;

                    foreach (CarClassesEnum item in carClasses)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }
                    writer.WriteLine();

                    writer.Write("Enter number: ");

                    int selectedCarClassNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedCarClassNumber <= 0 || selectedCarClassNumber > carClasses.Length)
                    {
                        writer.WriteLine("Enter a valid number");

                        continue;
                    }

                    carClass = carClasses[selectedCarClassNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            CarTypeEnum[] carTypes = new CarTypeEnum[]
            {
                CarTypeEnum.Sedan,
                CarTypeEnum.Combi,
                CarTypeEnum.Hetchback,
                CarTypeEnum.SUV,
                CarTypeEnum.Cabrio,
                CarTypeEnum.Minivan
            };

            CarTypeEnum carType;

            while (true)
            {
                try
                {
                    writer.WriteLine("Car Types: ");

                    int number = 1;

                    foreach (CarTypeEnum item in carTypes)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }
                    writer.WriteLine();

                    writer.Write("Enter number: ");

                    int selectedCarTypeNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedCarTypeNumber <= 0 || selectedCarTypeNumber > carTypes.Length)
                    {
                        writer.WriteLine("Enter a valid number");
                    }

                    carType = carTypes[selectedCarTypeNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            int seats;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter seats value between 2 and 7: ");

                    seats = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (seats < 2 || seats > 7)
                    {
                        writer.WriteLine("Enter seats between 2 and 7",
                            ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            DoorsEnum[] doorsEnums = new DoorsEnum[]
            {
                DoorsEnum.Two,
                DoorsEnum.Three,
                DoorsEnum.Four,
                DoorsEnum.Five
            };

            DoorsEnum doors;

            while (true)
            {
                try
                {
                    writer.WriteLine("Doors Types: ");

                    int number = 1;

                    foreach (DoorsEnum item in doorsEnums)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }

                    writer.Write("Enter number: ");

                    int selectedDoorsEnumNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedDoorsEnumNumber <= 0 || selectedDoorsEnumNumber > doorsEnums.Length)
                    {
                        writer.WriteLine("Enter a valid number");
                    }

                    doors = doorsEnums[selectedDoorsEnumNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            GearBoxEnum[] gearBoxEnums = new GearBoxEnum[]
            {
                GearBoxEnum.Manual,
                GearBoxEnum.Automatic,
                GearBoxEnum.Combined
            };

            GearBoxEnum gearBox;

            while (true)
            {
                try
                {
                    writer.WriteLine("Gear Box Types: ");

                    int number = 1;

                    foreach (GearBoxEnum item in gearBoxEnums)
                    {
                        writer.WriteLine($"{number++}. {item}");
                    }

                    writer.Write("Enter number: ");

                    int selectedGearBoxNumber = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (selectedGearBoxNumber <= 0 || selectedGearBoxNumber > gearBoxEnums.Length)
                    {
                        writer.WriteLine("Enter a valid number");
                    }

                    gearBox = gearBoxEnums[selectedGearBoxNumber - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            EngineSpecification engineSpecification = InputEngineSpecification();

            List<Extra> extras = new List<Extra>();

            writer.WriteLine("Do you want to add extras? YES/NO");

            string choice = reader.ReadLine();

            while (true)
            {
                if (choice.ToLower() == "yes")
                {
                    break;
                }
                else
                {
                    if (choice.ToLower() == "no")
                    {
                        break;
                    }
                    else
                    {
                        writer.WriteLine("Do you want to add extras? YES/NO");

                        choice = reader.ReadLine();
                    }
                }
            }

            if (choice.ToLower() == "yes")
            {
                Extra extra = InputExtra();

                extras.Add(extra);

                writer.WriteLine("Do you want to add more extras? YES/NO");

                choice = reader.ReadLine();

                while (true)
                {
                    if (choice.ToLower() == "yes")
                    {
                        extra = InputExtra();

                        extras.Add(extra);

                        writer.WriteLine("Do you want to add more extras? YES/NO");

                        choice = reader.ReadLine();
                    }
                    else
                    {
                        if (choice.ToLower() == "no")
                        {
                            break;
                        }
                        else
                        {
                            writer.WriteLine("Do you want to add more extras? YES/NO");

                            choice = reader.ReadLine();
                        }
                    }
                }
            }

            BrandInfo brandInfo = InputBrandInfo();

            return new Car(carClass, carType, seats, doors, gearBox, engineSpecification,
                brandInfo, extras);
        }

        // Вход за резервация
        public Booking InputBooking()
        {
            writer.WriteLine("Input booking");

            Guid id = new Guid();

            DateTime pickUpDate;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter pick up date value in format MM/dd/yyyy (e.g 11/05/2000)");

                    pickUpDate = DateTime.Parse(reader.ReadLine());

                    if (pickUpDate.Date < DateTime.Now.Date)
                    {
                        writer.WriteLine("Enter date greater than the current",
                            ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message, ConsoleColor.Red);
                }
            }

            DateTime dropOffDate;

            while (true)
            {
                try
                {
                    writer.WriteLine("Enter drop off date value in format dd/MM/yyyy (e.g 11/05/2000)");

                    dropOffDate = DateTime.Parse(reader.ReadLine());

                    if (dropOffDate.Date < pickUpDate.Date)
                    {
                        writer.WriteLine("Enter date greater than the pick up date",
                            ConsoleColor.Red);

                        continue;
                    }

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a date", ConsoleColor.Red);
                }
            }

            Car car = InputCarSelection();

            //Проверка, дали не е свободна колата
            if (!IsBookingAvailable(car, pickUpDate, dropOffDate))
            {
                //Резултата с наличните свободни дати за наемане
                Dictionary<DateTime, DateTime>? dates =
                    GetFreeDates(car, pickUpDate, dropOffDate);

                try
                {
                    writer.WriteLine("Dates available: ");

                    writer.WriteLine();

                    int element = 1;

                    //Оптечатваме датите и техния номер
                    foreach (var item in dates)
                    {
                        writer.WriteLine($"Date No {element++}\n");

                        writer.WriteLine($"Pick up date: {item.Key.Date.ToShortDateString()} Drop off date: {item.Value.Date.ToShortDateString()}");

                        writer.WriteLine("-------------");

                        writer.WriteLine();
                    }

                    while (true)
                    {
                        try
                        {
                            writer.Write("Enter number: ");

                            int value = int.Parse(reader.ReadLine());
                            writer.WriteLine();

                            if (value <= 0 || value > dates.Count)
                            {
                                writer.WriteLine("Enter a valid number");

                                continue;
                            }

                            //Взима се стойността за дата на наемане от избранaта дата
                            pickUpDate = dates.ElementAt(value - 1).Key;

                            //Взима се стойността за дата на връщане от избранта дата
                            dropOffDate = dates.ElementAt(value - 1).Value;

                            //Отпечатване, че е избрана датата
                            writer.WriteLine($"Choosed dates: {pickUpDate} and {dropOffDate}", ConsoleColor.Blue);

                            writer.WriteLine();

                            break;
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine("Enter a number", ConsoleColor.Red);

                            writer.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message, ConsoleColor.Red);

                    writer.WriteLine();
                }
            }

            RentalInfo rentalInfo = InputRentalInfo();

            string pickUpLocation;

            while (true)
            {
                writer.WriteLine("Enter pick up location: ");

                pickUpLocation = reader.ReadLine();
                writer.WriteLine();

                if (pickUpLocation.Length == 0 ||
                    !pickUpLocation.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }

            string dropOffLocation;

            while (true)
            {
                writer.WriteLine("Enter drop off location: ");

                dropOffLocation = reader.ReadLine();
                writer.WriteLine();

                if (dropOffLocation.Length == 0 ||
                    !dropOffLocation.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }

            string clientAdditionalInfo;

            while (true)
            {
                writer.WriteLine("Enter client additional info: ");

                clientAdditionalInfo = reader.ReadLine();
                writer.WriteLine();

                if (clientAdditionalInfo.Length == 0 ||
                    !clientAdditionalInfo.Any(a => char.IsLetterOrDigit(a)))
                {
                    writer.WriteLine("Enter at least one character", ConsoleColor.Red);

                    continue;
                }

                break;
            }

            return new Booking(id, pickUpDate, dropOffDate, pickUpLocation,
                dropOffLocation, clientAdditionalInfo, car, rentalInfo);
        }

        // Избиране на кола
        public Car InputCarSelection()
        {
            writer.WriteLine("Select a car");

            PrintCars();

            writer.WriteLine();

            Car car;

            while (true)
            {
                try
                {
                    writer.Write("Enter number: ");

                    int element = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (element <= 0 || element > cars.Count)
                    {
                        writer.WriteLine("Enter a valid number");
                    }

                    //Резултата е този от избранaта кола
                    car = cars[element - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            return car;
        }

        // Избиране на резервация
        public Booking InputBookingSelection()
        {
            writer.WriteLine("Select a booking");

            PrintBookings();

            writer.WriteLine();

            Booking booking;

            while (true)
            {
                try
                {
                    writer.Write("Enter number: ");

                    int element = int.Parse(reader.ReadLine());
                    writer.WriteLine();

                    if (element <= 0 || element > bookings.Count)
                    {
                        writer.WriteLine("Enter a valid number");
                    }

                    //Резултата е този от избраната резервация
                    booking = bookings[element - 1];

                    break;
                }
                catch (Exception)
                {
                    writer.WriteLine("Enter a number", ConsoleColor.Red);
                }
            }

            return booking;
        }
    }
}
