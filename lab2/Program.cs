public abstract class Vehicle
{
    public double Weight { get; init; }
    public int MaxSpeed { get; init; }
    protected int _mileage;
    public int Mealeage
    {
        get { return _mileage; }
    }
    public abstract decimal Drive(int distance);
    public override string ToString()
    {
        return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
    }
}

public class Car : Vehicle
{
    public bool isFuel { get; set; }
    public bool isEngineWorking { get; set; }
    public override decimal Drive(int distance)
    {
        if (isFuel && isEngineWorking)
        {
            _mileage += distance;
            return (decimal)(distance / (double)MaxSpeed);
        }
        return -1;
    }
    public override string ToString()
    {
        return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
    }
}

public class Bicycle : Vehicle
{
    public bool isDriver { get; set; }
    public override decimal Drive(int distance)
    {
        if (isDriver)
        {
            _mileage += distance;
            return (decimal)(distance / (double)MaxSpeed);
        }
        return -1;
    }
    public override string ToString()
    {
        return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
    }
}

foreach (var vehicle in vehicles)
{
    Console.WriteLine("Time for distance: " + vehicle.Drive(45));
}

int bicycleCounter = 0;
int carCounter = 0;
foreach (var vehicle in vehicles)

{
    if (vehicle is Bicycle)
    {
        bicycleCounter++;
        Bicycle bicycle = (Bicycle)vehicle;
        Console.WriteLine("Czy rower ma kierowcę: " + bicycle.isDriver);
    }
    if (vehicle is Car)
    {
        carCounter++;
    }
}
Console.WriteLine($"Liczba rowerów: {bicycleCounter}, liczba samochodów: {carCounter}");

interface Driveable
{
    int Drive(int distance);
}
interface Swimmingable
{
    int Swim(int distance);
}
interface Flyable
{
    void TakeOff();
    int Fly(int disntance);
}

public class Truck : Vehicle, Driveable
{
    public override decimal Drive(int distance)
    {
        return 0;
    }
}
public class Amphibian : Vehicle, Driveable, Swimmingable
{
    public override decimal Drive(int distance)
    {
        Console.WriteLine("DRIVE");
        return 0;
    }
    public decimal Swim(int distance)
    {
        Console.WriteLine("SWIM");
        return 0;
    }
}
public class Hydroplane : Vehicle, Flyable, Swimmingable
{
    public override decimal Drive(int distance)
    {
        Console.WriteLine("DRIVE");
        return 0;
    }
    public decimal Swim(int distance)
    {
        Console.WriteLine("SWIM");
        return 0;
    }
    public bool TakeOff()
    {
        Console.WriteLine("TAKE OFF");
        return true;
    }
    public decimal Fly(int distance)
    {
        Console.WriteLine("FLY");
        return 0;
    }
    public bool Land()
    {
        Console.WriteLine("LAND");
        return true;
    }
}

Vehicle[] army =
{
 new Amphibian(){MaxSpeed = 20},
 new Hydroplane(){MaxSpeed = 800},
 new Truck() {MaxSpeed = 100}
};
foreach (var vehicle in army)
{
    if (vehicle is Hydroplane)
    {
        Console.WriteLine("Hydroplane");
        Hydroplane hydroplane = (Hydroplane)vehicle;
        hydroplane.TakeOff();
        hydroplane.Fly(100);
        hydroplane.Land();
    }
}

class Duck : ISwimmingable, IFlyable
{
    public decimal size;
    public decimal Fly(int distance)
    {
        throw new NotImplementedException();
    }

    public decimal Swim(int distance)
    {
        throw new NotImplementedException();
    }
}

class Wasp : IFlyable
{
    public decimal size;
    public decimal Fly(int distance)
    {
        throw new NotImplementedException();
    }
}

readonly static IFlyable[] IcanFly =
{
    new Duck(){size=5},
    new Wasp(){size=21},
    new Duck(){size=1},
    new Duck(){size=6},
    new Hydroplane()
};

foreach (var fly in IcanFly)
{
    if ((fly is IFlyable) && (fly is ISwimmingable))
    {
        count++;
        Console.WriteLine(fly.GetType().Name);
    }
};