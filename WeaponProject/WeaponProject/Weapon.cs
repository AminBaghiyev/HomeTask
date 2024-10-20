using System.Diagnostics;

namespace WeaponProject;

internal class Weapon
{
    public int CapacityOfBullet { get; set; }

    private int _numberOfBullets;
    public int NumberOfBullets
    {
        get {  return _numberOfBullets; }
        set
        {
            if (value <= CapacityOfBullet && value >= 0) _numberOfBullets = value;
            else App.ErrorMsg("Number of bullets cannot exceed bullet capacity of the weapon!");
        }
    }

    private string _fireMode = "manual";
    public string FireMode
    {
        get { return _fireMode; }
        set
        {
            if (value.ToLower() == "manual" || value.ToLower() == "auto") _fireMode = value;
            else App.ErrorMsg("Shooting mode can only be manual or auto!");
        }
    }

    public Weapon(int capacityOfBullet, int numberOfBullets)
    {
        CapacityOfBullet = capacityOfBullet;
        NumberOfBullets = numberOfBullets;
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
        NumberOfBullets = CapacityOfBullet;
    }

    public void ChangeFireMode()
    {
        FireMode = FireMode == "manual" ? "auto" : "manual";
    }
}
