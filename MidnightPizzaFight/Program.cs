using System;
using static Program;

class Program
{
    // Main entry point of the program
    static void Main()
    {
        // Create a new game instance and start the game loop
        Game game = new Game();
        game.GameLoop();
    }

    /// <summary>
    /// Player class representing the hero character (Dough Master)
    /// </summary>
    public class Player
    {
        // Player attributes
        private int health = 100;
        private int maxHealth = 100;
        private int attackDamage = 20;
        private int healingCapacity = 15;

        // Health property with validation
        public int Health
        {
            get { return health; }
            set
            {
                // Ensure health stays within bounds (0 - maxHealth)
                if (value < 0)
                    health = 0;
                else if (value > maxHealth)
                    health = maxHealth;
                else
                    health = value;
            }
        }

        // Constructor - called when player is created
        public Player()
        {
            spawnPlayer();
        }

        /// <summary>
        /// Display player introduction and backstory
        /// </summary>
        private void spawnPlayer()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("   DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST   ");
            Console.WriteLine("==================================================\n");
            Console.WriteLine("\nDough Master: That scoundrel won't escape with my creation!\n");
        }

        /// <summary>
        /// Generate a random number within specified range
        /// </summary>
        private int generateRandomInRange(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        /// <summary>
        /// Calculate total attack damage with random bonus
        /// </summary>
        public int CalculateTotalDamage()
        {
            int additionalDamage = generateRandomInRange(5, 15);
            return attackDamage + additionalDamage;
        }

        /// <summary>
        /// Calculate total healing amount with random bonus
        /// </summary>
        public int CalculateTotalHeal()
        {
            int additionalHeal = generateRandomInRange(10, 20);
            return healingCapacity + additionalHeal;
        }

        // Methods to modify player health
        public void TakeDamage(int damageRecieved) => Health -= damageRecieved;
        public void Heal(int healAmount) => Health += healAmount;

        /// <summary>
        /// Display attack results to the player
        /// </summary>
        public void ShowAttackDamage(int totalDamage)
        {
            Console.WriteLine("               PIZZA BATTLE                     ");
            Console.WriteLine("============================================");
            Console.WriteLine("Dough Master's attack dealt " + totalDamage + " damage! ");
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Display healing results to the player
        /// </summary>
        public void ShowHeal(int healAmount)
        {
            Console.WriteLine("               PIZZA BATTLE                    ");
            Console.WriteLine("============================================");

            if (Health >= maxHealth)
                Console.WriteLine("     Dough Master is bursting with energy!      ");
            else
                Console.WriteLine("Dough Master's heal restored " + healAmount + " hp!  ");

            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Display current player stats (health, attack, etc.)
        /// </summary>
        public void DisplayPlayerStats()
        {
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("\n             DOUGHT MASTER\'S STATS");
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("Health: " + health + "/" + maxHealth);
            Console.WriteLine("Dough Slapper: " + attackDamage);
            Console.WriteLine("Espresso Shot: " + healingCapacity);
            Console.WriteLine("Dough Slapper Boost: 5 to 15");
            Console.WriteLine("Espresso Shot Boost: 10 to 20");
        }
    }

    /// <summary>
    /// Enemy class representing the antagonist (Crust Bandit)
    /// </summary>
    public class Enemy
    {
        // Enemy attributes
        private int health = 150;
        private int maxHealth = 150;
        private int attackDamage = 15;

        // Health property with validation
        public int Health
        {
            get { return health; }
            set
            {
                // Ensure health stays within bounds (0 - maxHealth)
                if (value < 0)
                    health = 0;
                else if (value > maxHealth)
                    health = maxHealth;
                else
                    health = value;
            }
        }

        // Constructor - called when enemy is created
        public Enemy()
        {
            spawnEnemy();
        }

        /// <summary>
        /// Display enemy introduction and taunt
        /// </summary>
        private void spawnEnemy()
        {
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("               CRUST BANDIT: NEMESIS OF ITALIAN CUISINE");
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("\n\nYou'll never catch me, flour face!");
        }

        /// <summary>
        /// Generate a random number within specified range
        /// </summary>
        private int generateRandomNumberInRange(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        /// <summary>
        /// Calculate total attack damage with random bonus
        /// </summary>
        public int CalculateTotalDamage()
        {
            int additionalDamage = generateRandomNumberInRange(5, 15);
            return attackDamage + additionalDamage;
        }

        // Method to modify enemy health
        public void TakeDamage(int damageRecieved) => Health -= damageRecieved;

        /// <summary>
        /// Display attack results to the player
        /// </summary>
        public void ShowAttackDamage(int totalDamage)
        {
            Console.WriteLine("               PIZZA BATTLE                     ");
            Console.WriteLine("============================================");
            Console.WriteLine("Enemy's attack dealt " + totalDamage + " damage! ");
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Display current enemy stats
        /// </summary>
        public void DisplayEnemyStats()
        {
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("\n             SNATCHER\'S STATS");
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("Health: " + health + "/" + maxHealth);
            Console.WriteLine("Snatcher attack: " + attackDamage);
            Console.WriteLine("Dough Slapper Boost: 5 to 15");
        }
    }

    /// <summary>
    /// Main Game class that controls the game flow and logic
    /// </summary>
    class Game
    {
        // Game state variables
        private Player player;
        private Enemy enemy;
        private bool isGameExited;

        /// <summary>
        /// Display the game's backstory and introduction
        /// </summary>
        private void DisplayGameStory()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("              MIDNIGHT PIZZA FIGHT           ");
            Console.WriteLine("================================================");
            Console.WriteLine("In a bustling pizzeria on a busy Friday night...\n" +
                "------------------------------------------------\n" +
                "You,the Dough Master,created your magnum opus -\n" +
                "the perfect pizza Suddenly,a sneaky Crust Bandit\n" +
                "snactches your masterpiece!\n" +
                "------------------------------------------------\n\n" +
                "Fueled by passion for your craft,you give chase...\n" +
                "------------------------------------------------\n" +
                "Through winding alleys and crowded streets, you\n" +
                "pursue the pizza pilferer. Finally, the thief is\n" +
                "cornered in a dead-end alley. It's time to recover\n" +
                "your stolen slice!\n" +
                "------------------------------------------------\n" +
                "                    FIGHT!                   ");
        }

        /// <summary>
        /// Initialize player and enemy characters
        /// </summary>
        private void SpawnCharacters()
        {
            player = new Player();
            enemy = new Enemy();
        }

        /// <summary>
        /// Main battle loop - continues until one character is defeated
        /// </summary>
        private void ProcessBattleLoop()
        {
            do
            {
                ShowBattleOptions();
                ProcesBattleInput();
            }
            while (AreCharactersAlive());
        }

        /// <summary>
        /// Display available battle actions to the player
        /// </summary>
        private void ShowBattleOptions()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("               PIZZA BATTLE OPTIONS               ");
            Console.WriteLine("==================================================");
            Console.WriteLine("  Choose your action:");
            Console.WriteLine("    [A] Attack the Crust Bandit ");
            Console.WriteLine("    [H] Gulp an Espresso Shot ");
            Console.WriteLine("==================================================");
            Console.Write("  Your choice: ");
        }

        /// <summary>
        /// Process player's battle choice and execute corresponding action
        /// </summary>
        private void ProcesBattleInput()
        {
            string PlayerChoice = GetInput();
            Console.Clear();

            switch (PlayerChoice)
            {
                case "A": // Attack chosen
                    PlayerAttack();
                    if (CheckGameOver()) break;
                    EnemyAttack();
                    if (CheckGameOver()) break;
                    DisplayerCharacterStats();
                    break;

                case "H": // Heal chosen
                    PlayerHeal();
                    EnemyAttack();
                    if (CheckGameOver()) break;
                    DisplayerCharacterStats();
                    break;

                default: // Invalid input
                    InvalidInput();
                    break;
            }
        }

        /// <summary>
        /// Get and sanitize player input
        /// </summary>
        private string GetInput()
        {
            return Console.ReadLine().ToUpper();
        }

        /// <summary>
        /// Display invalid input message
        /// </summary>
        private void InvalidInput() => Console.WriteLine("Invalid Input! please try again");

        /// <summary>
        /// Display start menu with game options
        /// </summary>
        private void StartMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("     Press S to Get Your Masterpiece BACK...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");
            ProcessStartMenuInput();
        }

        /// <summary>
        /// Process start menu choice
        /// </summary>
        private void ProcessStartMenuInput()
        {
            if (GetInput() == "S")
            {
                Console.Clear();
                SpawnCharacters();
                ProcessBattleLoop();
            }
            else
            {
                ExitGame();
            }
        }

        /// <summary>
        /// Display restart menu after game ends
        /// </summary>
        private void RestartMenu()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("     Press R to Restart...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");
            ProcessRestartMenuInput();
        }

        /// <summary>
        /// Process restart menu choice
        /// </summary>
        private void ProcessRestartMenuInput()
        {
            if (GetInput() == "R")
                isGameExited = false;
            else
                ExitGame();
        }

        /// <summary>
        /// Exit the game gracefully
        /// </summary>
        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing Midnight Pizza Fight!");
            isGameExited = true;
        }

        /// <summary>
        /// Execute player attack sequence
        /// </summary>
        private void PlayerAttack()
        {
            int totalDamage = player.CalculateTotalDamage();
            enemy.TakeDamage(totalDamage);
            player.ShowAttackDamage(totalDamage);
        }

        /// <summary>
        /// Execute player heal sequence
        /// </summary>
        private void PlayerHeal()
        {
            int totalHeal = player.CalculateTotalHeal();
            player.Heal(totalHeal);
            player.ShowHeal(totalHeal);
        }

        /// <summary>
        /// Execute enemy attack sequence
        /// </summary>
        private void EnemyAttack()
        {
            int totalDamage = enemy.CalculateTotalDamage();
            player.TakeDamage(totalDamage);
            enemy.ShowAttackDamage(totalDamage);
        }

        /// <summary>
        /// Display current stats for both characters
        /// </summary>
        private void DisplayerCharacterStats()
        {
            player.DisplayPlayerStats();
            enemy.DisplayEnemyStats();
        }

        /// <summary>
        /// Check if game should end (one character defeated)
        /// </summary>
        private bool CheckGameOver()
        {
            if (enemy.Health <= 0)
            {
                ShowGameWin();
                return true;
            }
            else if (player.Health <= 0)
            {
                ShowGameLose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Display victory screen
        /// </summary>
        private void ShowGameWin()
        {
            Console.Clear();
            Console.WriteLine("\n==================================================");
            Console.WriteLine("             PIZZA JUSTICE SERVED!                ");
            Console.WriteLine("==================================================");
            Console.WriteLine("The Dough Master has defeated the Crust Bandit!");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The perfect pizza has been reclaimed             ");
            Console.WriteLine("The honor of Italian cuisine is restored!         ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("    Bon appétit, and thanks for playing!          ");
            Console.WriteLine("==================================================");
        }

        /// <summary>
        /// Display game over screen
        /// </summary>
        private void ShowGameLose()
        {
            Console.Clear();
            Console.WriteLine("\n==================================================");
            Console.WriteLine("               PIZZA TRAGEDY!                ");
            Console.WriteLine("==================================================");
            Console.WriteLine("The Dough Master has been outmaneuvered!           ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The Crust Bandit escapes with your masterpiece ");
            Console.WriteLine("Your pizzeria's reputation is in shambles      ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("        Thanks for your valiant effort!          ");
            Console.WriteLine("   Perhaps it's time to switch to calzones...    ");
            Console.WriteLine("==================================================");
        }

        /// <summary>
        /// Check if both characters are still alive or not
        /// </summary>

        private bool AreCharactersAlive()
        {
            return player.Health > 0 && enemy.Health > 0;
        }

        /// <summary>
        /// Main game loop controlling the overall game flow
        /// </summary>
        public void GameLoop()
        {
            while (!isGameExited)
            {
                DisplayGameStory();
                StartMenu();
                if (!isGameExited)
                    RestartMenu();
            }
        }
    }
}