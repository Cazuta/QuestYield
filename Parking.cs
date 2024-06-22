
using System.Collections;
using System.Runtime.CompilerServices;

public class Parking
  {
  private List<Car> p_cars = new List<Car>();
  private const int p_maxCars = 100;
  public Car this[string number]
  {
    get
    {
      var car = p_cars
      .FirstOrDefault(c => c.Number == number);
      return car;
    }
  }
  public Car this[ int position]
  {
    get
    {
      if (position < p_cars.Count)
      {
        return p_cars[position];
      }
      return null;
    }
    set
    {
      if(position < p_cars.Count)
      {  p_cars[position] = value; }
    }
  }

  public string Name {  get; set; }
  public int Count => p_cars.Count;

  public int Add(Car car)
  {
    if (car == null)
    {
      throw new ArgumentNullException(nameof(car), "Car is null");
    }

    if (p_cars.Count < p_maxCars) { 
      p_cars.Add(car);
    return p_cars.Count - 1; }

    else
    {
      return -1;
    }

  }
  public void GoOut(string number)
  {
    if (string.IsNullOrWhiteSpace(number))
    {
      throw new ArgumentNullException(nameof(number), "Number is null or empty");
    }
    var car = p_cars
      .FirstOrDefault(c => c.Number == number); 
    if (car != null) 
    {
      p_cars.Remove(car);
    }
  }

  public async IAsyncEnumerable<Car> GetCarsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    foreach (var car in p_cars)
    {
      if (cancellationToken.IsCancellationRequested)
      {
        yield break;
      }
      yield return car;
    }
  }

 
  public async IAsyncEnumerable<string> GetCarNamesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    foreach (var car in p_cars)
    {
      if (cancellationToken.IsCancellationRequested)
      {
        yield break;
      }
      yield return car.Name;
      
    }
  }
}

