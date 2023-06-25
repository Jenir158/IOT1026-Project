namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a trap room, which contains a dangerous trap that the hero can trigger.
    /// </summary>
    public class TrapRoom : Room
    {

        static TrapRoom()
        {
            RoomFactory.Instance.Register(RoomType.TrapRoom, () => new TrapRoom());
        }

        /// <inheritdoc/>
        public override RoomType Type { get; } = RoomType.TrapRoom;

        /// <inheritdoc/>
        public override bool IsActive { get; protected set; } = true;

        /// <summary>
        /// Activates the trap, causing the hero to potentially face consequences.
        /// </summary>
        public override void Activate(Hero hero, Map map)
        {
            if (IsActive)
            {
                int trapDamage = GetRandomRoundedNumber();
                ConsoleHelper.WriteLine("As you step into the room, the floor beneath you triggers a hidden trap!", ConsoleColor.Red);
                ConsoleHelper.WriteLine("Spikes suddenly emerge from the floor, impaling you.", ConsoleColor.DarkRed);
                hero.TakeDamage(trapDamage);

                if (hero.IsAlive)
                {
                    ConsoleHelper.WriteLine($"You have been damaged by the trap! Your health: {hero.Health}", ConsoleColor.DarkRed);

                    // Display storyline based on the damage severity
                    if (trapDamage <= 30)
                    {
                        ConsoleHelper.WriteLine("You feel a sharp pain but manage to endure the damage.", ConsoleColor.Yellow);
                    }
                    else if (trapDamage <= 60)
                    {
                        ConsoleHelper.WriteLine("The impact is intense, causing you to stumble and gasp in pain.", ConsoleColor.DarkYellow);
                    }
                    else
                    {
                        ConsoleHelper.WriteLine("The trap inflicts a devastating blow, leaving you barely conscious.", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    ConsoleHelper.WriteLine("You have triggered a trap and died.", ConsoleColor.DarkRed);
                }

                IsActive = false; // Deactivate the trap after it has been triggered
            }

        }

        /// <inheritdoc/>
        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Red)
                            : base.Display();
        }

        /// <summary>
        /// Displays sensory information about the trap, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the trap.</param>
        /// <param name="heroDistance">The distance between the hero and the trap room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You recall the dangerous trap in this room, but it has already been triggered.", ConsoleColor.DarkGray);

                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You sense danger nearby. There is a trap in a nearby room!" : "Your intuition tells you that something dangerous is nearby", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
        private int GetRandomRoundedNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101); // Generates a random number between 0 and 100 (inclusive)
            int roundedNumber = (int)(Math.Round(randomNumber / 10.0) * 10); // Rounds the number to the nearest multiple of 10
            return roundedNumber;
        }

    }
}
