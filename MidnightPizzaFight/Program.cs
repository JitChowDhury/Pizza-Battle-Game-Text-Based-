using System;
using static Program;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.GameLoop();

    }

    public class Player
    {
        private int health = 100;
        private int maxHealth = 100;
        private int attackDamage = 20;
        private int healingCapacity = 15;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public Player()
        {
            spawnPlayer();
        }


        private void spawnPlayer()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("   DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST   ");
            Console.WriteLine("==================================================\n");
            Console.WriteLine("\nDough Master: That scoundrel won't escape with my creation!\n");
        }
        private int generateRandomInRange(int min, int max)
        {
            Random rand = new Random();
            int random = rand.Next(min, max + 1);
            return random;
        }
        public int CalculateTotalDamage()
        {
            int additionalDamage = generateRandomInRange(5, 15);
            int totalDamage = attackDamage + additionalDamage;
            return totalDamage;
        }

        public int CalculateTotalHeal()
        {
            int additionalHeal = generateRandomInRange(10, 20);
            int totalHeal = healingCapacity + additionalHeal;
            return totalHeal;
        }



        public void TakeDamage(int damageRecieved) => Health -= damageRecieved;
        public void Heal(int healAmount) => Health += healAmount;

        public void ShowAttackDamage(int totalDamage)
        {
            Console.WriteLine("               PIZZA BATTLE                     ");
            Console.WriteLine("============================================");
            Console.WriteLine("Dough Master's attack dealt " + totalDamage + " damage! ");
            Console.WriteLine("--------------------------------------------");
        }

        public void ShowHeal(int healAmount)
        {
            if (Health >= maxHealth)
            {
                Console.WriteLine("               PIZZA BATTLE                     ");
                Console.WriteLine("============================================");
                Console.WriteLine("     Dough Master is bursting with energy!      ");
                Console.WriteLine("--------------------------------------------");
            }
            else
            {
                Console.WriteLine("               PIZZA BATTLE                    ");
                Console.WriteLine("============================================");
                Console.WriteLine("Dough Master's heal restored " + healAmount + " hp!  ");
                Console.WriteLine("--------------------------------------------");
            }
        }

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
    public class Enemy
    {
        private int health = 150;
        private int maxHealth = 150;
        private int attackDamage = 15;


        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public Enemy()
        {
            spawnEnemy();
        }
        private void spawnEnemy()
        {
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("               CRUST BANDIT: NEMESIS OF ITALIAN CUISINE");
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("\n\nYou'll never catch me, flour face!");
        }
        private int generateRandomNumberInRange(int min, int max)
        {
            Random rand = new Random();
            int random = rand.Next(min, max + 1);
            return random;
        }
        public int CalculateTotalDamage()
        {
            int additionalDamage = generateRandomNumberInRange(5, 15);
            int totalDamage = attackDamage + additionalDamage;
            return totalDamage;
        }
        public void TakeDamage(int damageRecieved) => Health -= damageRecieved;
        public void ShowAttackDamage(int totalDamage)
        {
            Console.WriteLine("               PIZZA BATTLE                     ");
            Console.WriteLine("============================================");
            Console.WriteLine("Enemy's attack dealt " + totalDamage + " damage! ");
            Console.WriteLine("--------------------------------------------");
        }
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
    class Game
    {
        Player player;
        Enemy enemy;
        bool isGameExited;

        private void DisplayGameStory()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("              MIDNIGHT PIZZA FIGHT           ");
            Console.WriteLine("================================================");
            Console.WriteLine("In a bustling pizzeria on a busy Friday night...\n------------------------------------------------\nYou,the Dough Master,created your magnum opus -\nthe perfect pizza Suddenly,a sneaky Crust Bandit\nsnactches your masterpiece!\n------------------------------------------------\n\nFueled by passion for your craft,you give chase...\n------------------------------------------------\nThrough winding alleys and crowded streets, you\npursue the pizza pilferer. Finally, the thief is\ncornered in a dead-end alley. It's time to recover\nyour stolen slice!\n------------------------------------------------\n" +
                "                    FIGHT!                   ");
        }

        private void SpawnCharacters()
        {
            player = new Player();
            enemy = new Enemy();
        }

        private void ProcessBattleLoop()
        {
            do
            {
                ShowBattleOptions();
                ProcesBattleInput();
            }
            while (AreCharactersAlive());
        }
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

        private void ProcesBattleInput()
        {
            string PlayerChoice = GetInput();
            Console.Clear();

            switch (PlayerChoice)
            {
                case "A":
                    PlayerAttack();
                    if (CheckGameOver())
                        break;
                    EnemyAttack();
                    if (CheckGameOver())
                        break;
                    DisplayerCharacterStats();
                    break;
                case "H":
                    PlayerHeal();
                    EnemyAttack();
                    if (CheckGameOver())
                        break;
                    DisplayerCharacterStats();
                    break;

                default:

                    break;


            }
        }

        private string GetInput()
        {
            string input = Console.ReadLine();
            return input.ToUpper();
        }

        private void InvalidInput() => Console.WriteLine("Invalid Input! please try again");

        private void StartMenu()
        {
            
            Console.WriteLine("==================================================");
            Console.WriteLine("     Press S to Get Your Masterpiece BACK...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");
            ProcessStartMenuInput();
        }

        private void ProcessStartMenuInput()
        {
            string startGame = GetInput();
            if (startGame == "S")
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

        private void RestartMenu()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("     Press R to Restart...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");
            ProcessRestartMenuInput();
        }

        private void ProcessRestartMenuInput()
        {
            string restartGame = GetInput();
            if (restartGame == "R")
            {
                isGameExited = false;
                
            }
            else
            { 
             ExitGame();
            }
        }

        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing Midnight Pizza Fight!");
            isGameExited = true;
        }
        private void PlayerAttack()
        {
            int totalDamage = player.CalculateTotalDamage();
            enemy.TakeDamage(totalDamage);
            player.ShowAttackDamage(totalDamage);
        }
        private void PlayerHeal()
        {
            int totalHeal = player.CalculateTotalHeal();
            player.Heal(totalHeal);
            player.ShowHeal(totalHeal);
        }

        private void EnemyAttack()
        {
            int totalDamage = enemy.CalculateTotalDamage();
            player.TakeDamage(totalDamage);
            enemy.ShowAttackDamage(totalDamage);
        }

        private void DisplayerCharacterStats()
        {
            player.DisplayPlayerStats();
            enemy.DisplayEnemyStats();
        }

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

        private bool AreCharactersAlive()
        {
            return player.Health > 0 && enemy.Health > 0;
        }

        public void GameLoop()
        {
            while (!isGameExited)
            {
                DisplayGameStory();
                StartMenu();
                if(!isGameExited)
                RestartMenu();

            }
        }
    }
}