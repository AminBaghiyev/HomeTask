using System.Diagnostics;

namespace WeaponProject;

internal class Weapon
{
    private int _capacityOfBullet;
    public int CapacityOfBullet
    {
        get { return _capacityOfBullet; }
        set
        {
            while (true)
            {
                Console.Write("Enter capacity of bullet: ");
                int.TryParse(Console.ReadLine(), out value);
                if (value > 0) { _capacityOfBullet = value; break; }
                else App.ErrorMsg("The capacity of bullet should be natural value");
            }
        }
    }
    private int _numberOfBullets;
    public int NumberOfBullets
    {
        get {  return _numberOfBullets; }
        set
        {
            while (true)
            {
                Console.Write("Enter number of bullets: ");
                int.TryParse(Console.ReadLine(), out value);
                if (value <= CapacityOfBullet && value >= 0) { _numberOfBullets = value; break; }
                else App.ErrorMsg("Number of bullets cannot exceed bullet capacity of the weapon!");
            }
        }
    }

    private string _fireMode;
    public string FireMode
    {
        get { return _fireMode; }
        set
        {
            while (true)
            {
                Console.Write("Enter fire mode (manual or auto): ");
                value = Console.ReadLine();
                if (value.ToLower() == "manual" || value.ToLower() == "auto") { _fireMode = value; break; }
                else App.ErrorMsg("Shooting mode can only be manual or auto!");
            }
        }
    }

    public void Shoot()
    {
        if (NumberOfBullets > 0)
        {
            _numberOfBullets--;
            Console.WriteLine("1 bullet fired.");
        }
        else
        {
            App.ErrorMsg("Not enough bullets to fire!");
        }
    }

    public void Fire()
    {
        if (NumberOfBullets <= 0)
        {
            App.ErrorMsg("Not enough bullets to fire!");
            return;
        }

        if (FireMode == "auto")
        {
            int oldNumberOfBullets = NumberOfBullets;
            Stopwatch timerForAutoMode = new Stopwatch();
            timerForAutoMode.Start();

            while (NumberOfBullets > 0)
            {
                _numberOfBullets--;
            }

            timerForAutoMode.Stop();
            Console.WriteLine($"{oldNumberOfBullets} bullets fired in {timerForAutoMode.Elapsed.TotalSeconds} seconds");
            return;
        }

        Stopwatch timerForManualMode = new Stopwatch();
        timerForManualMode.Start();
        _numberOfBullets--;
        timerForManualMode.Stop();
        Console.WriteLine($"1 bullet fired in {timerForManualMode.Elapsed.TotalSeconds} seconds");
    }

    public int GetRemainBulletCount() => CapacityOfBullet - NumberOfBullets;

    public void Reload()
    {
        _numberOfBullets = CapacityOfBullet;
    }

    public void ChangeFireMode()
    {
        _fireMode = FireMode == "manual" ? "auto" : "manual";
    }
}
