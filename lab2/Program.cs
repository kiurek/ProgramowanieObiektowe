IFlyable[] flyingObject =
{
    new Duck(){Name="Kaczka", Size="Srednia"},
    new Wasp(){Name="Osa",Size="Mala"},
    new Plane(){Name="Samolot",Size="Duzy"}
};

int flies = 0;
foreach (var item in flyingObject)
{
    if (item is IFlyable && item is ISwimmingable)
    {
        flies++;
    }
}
Console.WriteLine($"Jest {flies} obiektów które posiadają zaimplementowane dwa interfejsy ");


Vehicle[] vehicles =
{

 new ElectricScooter(){Weight =40, MaxSpeed=40, MaxRange=10},
 new ElectricScooter(){Weight =40, MaxSpeed=40, MaxRange=5}
};


Console.WriteLine();
foreach (var vehicle in vehicles)
{

    Console.WriteLine($"{vehicle.Drive(5)}");
    Console.WriteLine($"Bateria naładowana w {vehicle.ChargeBatteries()}");
}

//Ćwiczenie 1

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
    public abstract decimal ChargeBatteries();


    public override string ToString()
    {
        return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
    }
}
public abstract class Scooter : Vehicle
{
}

public class ElectricScooter : Scooter
{
    protected decimal _batteriesLevel = 100;
    public decimal BatteriesLevel
    {
        get { return _batteriesLevel; }
    }
    public decimal MaxRange { get; init; } //20

    public override decimal ChargeBatteries()
    {
        if (_batteriesLevel != 100 && _batteriesLevel < 100)
        {
            while (_batteriesLevel != 100)
            {
                _batteriesLevel++;
            }
            return _batteriesLevel;
        }
        else
        {
            return _batteriesLevel;
        }



    }
    public override decimal Drive(int distance) //MAx range 10 distance 5 batlevel 100
    {
        decimal ProcentBateriNaJedenDistance = _batteriesLevel / MaxRange;
        if (ProcentBateriNaJedenDistance > 0)
        {
            while (distance != 0)
            {
                distance--;
                _batteriesLevel = _batteriesLevel - ProcentBateriNaJedenDistance;
            }

            _mileage += distance;
            return _batteriesLevel;
        }
        return -1;
    }
    public override string ToString()
    {
        return $"Scooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
    }
}


class EmailMessage : AbstractMessage
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }

    public override bool Send()
    {
        Console.WriteLine($"Sending email from {From} to {To} with content {Content}");
        return true;
    }
}
class MessengerMessage : AbstractMessage
{
    public string NameFrom { get; set; }
    public string NameTo { get; set; }

    public override bool Send()
    {
        Console.WriteLine($"Sending message using Messanger from {NameFrom}, to {NameTo} with content {Content}");
        return true;
    }
}

class SmsMessage : AbstractMessage
{
    public string ToPhone { get; init; }
    public string FromPhone { get; init; }
    public override bool Send()
    {
        Console.WriteLine($"Sending sms from {FromPhone} to { ToPhone} with content {Content}");
        return true;
    }
}

class User
{
    public string Name { get; init; }
    public AbstractMessage LastMessage { get; init; }

}


abstract class AbstractMessage
{
    public string Content { get; set; }
    public abstract bool Send();
}


public interface IFlyable
{
    void fly();
}

public interface ISwimmingable
{
    void swim();
}

public class Duck : IFlyable, ISwimmingable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}

public class Wasp : IFlyable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }
}

public class Plane : IFlyable, ISwimmingable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}