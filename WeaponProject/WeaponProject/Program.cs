namespace WeaponProject;

public class Program
{
    static void Main(string[] args)
    {
        bool render = true;
        App.WarningMsg("Welcome to the Weapon Project...");
        string input = "";
        Weapon weapon = new(30, 30);

        while (true)
        {
            if (render) App.MainPage();
            input = Console.ReadLine().Trim();

            switch (input)
            {
                case "0":
                    Console.Clear();
                    App.InfoPage(weapon);
                    render = true;
                    break;

                case "1":
                    weapon.Shoot();
                    render = false;
                    break;

                case "2":
                    weapon.Fire();
                    render = false;
                    break;

                case "3":
                    Console.WriteLine($"The number of bullets required to fill the magazine: {weapon.GetRemainBulletCount()}");
                    render = false;
                    break;

                case "4":
                    weapon.Reload();
                    Console.WriteLine("The weapon is reloaded.");
                    render = false;
                    break;

                case "5":
                    weapon.ChangeFireMode();
                    Console.WriteLine($"Fire mode changed to {weapon.FireMode}.");
                    render = false;
                    break;

                case "6":
                    Console.Clear();
                    return;

                default:
                    Console.Clear();
                    App.ErrorMsg("There is no such command!");
                    render = true;
                    break;
            }
        }
    }
}
