namespace MinotaurLabyrinth
{
    // Represents the player in the game.
    public class Hero
    {
        // Creates a new player that starts at the given location.
        public Hero(Location start) => Location = start;
        
        // Contains all the commands that a player can access.
        public CommandList CommandList { get; } = new CommandList();
        
        // Represents the distance the player can sense danger.
        // Diagonally adjacent squares have a range of 2 from the player.
        public int SenseRange { get; } = 1;

        // The player's current location.
        public Location Location { get; set; }

        // Indicates whether the player is alive or not.
        public bool IsAlive { get; set; } = true;

        // Indicates whether the player has won the game or not.
        public bool IsVictorious { get; set; }

        // Indicates whether the player currently has the catacomb map.
        public bool HasMap { get; set; } = true;

        // Indicates whether the player currently has the sword.
        public bool HasSword { get; set; }

        // Explains why a player died.
        public string CauseOfDeath { get; private set; } = "";

        // The current health points of the hero.
        public int Health { get; private set; } = 100;
        public bool HasWon { get; internal set; } = false;

        // Applies damage to the hero's health.
        public void TakeDamage(int damage)
        {
            Health -= damage;
            
            if (Health <= 0)
                Kill("You have been defeated in battle.");
        }

        // Heals the hero by the specified amount.
        public void Heal(int amount)
        {
            Health += amount;
        }

        // Kills the hero and sets the cause of death.
        public void Kill(string cause)
        {
            IsAlive = false;
            CauseOfDeath = cause;
        }
        
    }
}
