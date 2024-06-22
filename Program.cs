
class Program
{
  static async Task Main(string[] args)
  {
    var cars = new List<Car>()
        {
            new Car(){Name = "Ford", Number = "A001AA01"},
            new Car(){Name = "Toyota",Number = "A002AA02"},
        };

    var parking = new Parking();

   
    foreach (var car in cars)
    {
      parking.Add(car);
    }


    using (var cts = new CancellationTokenSource())
    {
      var token = cts.Token;
      await foreach (var car in parking.GetCarsAsync(token))
      {
        Console.WriteLine(car);
      }
    }

   
    using (var cts = new CancellationTokenSource())
    {
      var token = cts.Token;
      await foreach (var name in parking.GetCarNamesAsync(token))
      {
        Console.WriteLine($"Имя: {name}");
      }
    }

    Console.WriteLine();


    Console.WriteLine(parking["A001AA01"]?.Name);
    Console.WriteLine(parking["A222AA02"]?.Name);

    Console.WriteLine("Введите номер нового автомобиля");
    var num = Console.ReadLine();

   
    parking[1] = new Car() { Name = "BMW", Number = num };
    Console.WriteLine(parking[1]);

    Console.ReadLine();
  }
}