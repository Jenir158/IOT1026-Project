using MinotaurLabyrinth;

public class Muzan : Monster

{
    
 
    public int Strength { get; set; } = 100;
   public override bool DisplaySense(Hero hero, int heroDistance)
{
    if (heroDistance == 1)
    {
        ConsoleHelper.WriteLine("You sense an overwhelming presence nearby... Muzan is dangerously close!", ConsoleColor.Red);
        return true;
    }
    else if(heroDistance== 0){if (hero.HasSword && hero.Health > 90)
        {
            // Hero wins
            ConsoleHelper.WriteLine("You are face to face with Muzan! Prepare for a fierce battle!", ConsoleColor.Red);
            ConsoleHelper.WriteLine("You draw your Nichirin Sword, its blade gleaming with determination.", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("With unmatched skill and unwavering resolve, you engage Muzan in an epic duel.", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("Your strikes are precise, each swing of the sword showcasing your exceptional training.", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("Muzan staggers back, weakened by your relentless assault.", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine("With a final strike, you deliver the decisive blow, defeating Muzan and emerging victorious!", ConsoleColor.Green);
            hero.TakeDamage(100);
            hero.HasWon= true;

        }
        else
        {
            // Hero loses
            ConsoleHelper.WriteLine("You are face to face with Muzan! Prepare for a fierce battle!", ConsoleColor.Red);
            ConsoleHelper.WriteLine("You muster all your courage and engage Muzan in combat, fighting valiantly against overwhelming odds.", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("Your every move is met with swift and powerful counters from Muzan, displaying his superior strength.", ConsoleColor.Red);
            ConsoleHelper.WriteLine("Despite your best efforts, you find yourself unable to match Muzan's power.", ConsoleColor.Red);
            ConsoleHelper.WriteLine("Exhausted and wounded, you fall to the ground, unable to continue the battle.", ConsoleColor.Red);
            hero.IsAlive = false;
        }}
     
    
    return false;
}


    public override DisplayDetails Display()
    {
        return new DisplayDetails("[M]", ConsoleColor.Red);
    }

    public override void Activate(Hero hero, Map map)
    {
        Strength += 50;
        ConsoleHelper.WriteLine("The moster has awaken"+ hero,ConsoleColor.Red);

    
      
    
      
    }
}
