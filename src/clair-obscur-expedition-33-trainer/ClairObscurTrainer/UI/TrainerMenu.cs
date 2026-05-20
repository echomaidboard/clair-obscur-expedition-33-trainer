using System;
using ClairObscurTrainer.Core;

namespace ClairObscurTrainer.UI
{
    /// <summary>
    /// Console-based user interface for the trainer.
    /// Allows the user to modify game stats interactively.
    /// </summary>
    public class TrainerMenu
    {
        private readonly MemoryManager _memoryManager;

        public TrainerMenu(MemoryManager memoryManager)
        {
            _memoryManager = memoryManager;
        }

        /// <summary>
        /// Displays the interactive menu and handles user input.
        /// </summary>
        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Clair Obscur: Expedition 33 Trainer ===");
                Console.WriteLine($"Health: {_memoryManager.GetHealth()} / {_memoryManager.GetMaxHealth()}");
                Console.WriteLine($"Stamina: {_memoryManager.GetStamina()}");
                Console.WriteLine($"Luminescence: {_memoryManager.GetLuminescence()}");
                Console.WriteLine();
                Console.WriteLine("1. Set Health to Max");
                Console.WriteLine("2. Set Stamina to Max");
                Console.WriteLine("3. Set Luminescence to Max");
                Console.WriteLine("4. Custom Health Value");
                Console.WriteLine("5. Custom Stamina Value");
                Console.WriteLine("6. Custom Luminescence Value");
                Console.WriteLine("7. Refresh Values");
                Console.WriteLine("8. Exit");
                Console.Write("\nSelect option: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _memoryManager.SetHealth(_memoryManager.GetMaxHealth());
                        Console.WriteLine("Health set to maximum.");
                        break;
                    case "2":
                        _memoryManager.SetStamina(100);
                        Console.WriteLine("Stamina set to maximum.");
                        break;
                    case "3":
                        _memoryManager.SetLuminescence(100);
                        Console.WriteLine("Luminescence set to maximum.");
                        break;
                    case "4":
                        Console.Write("Enter health value (0-999): ");
                        if (int.TryParse(Console.ReadLine(), out int health))
                            _memoryManager.SetHealth(Math.Clamp(health, 0, 999));
                        break;
                    case "5":
                        Console.Write("Enter stamina value (0-999): ");
                        if (int.TryParse(Console.ReadLine(), out int stamina))
                            _memoryManager.SetStamina(Math.Clamp(stamina, 0, 999));
                        break;
                    case "6":
                        Console.Write("Enter luminescence value (0-999): ");
                        if (int.TryParse(Console.ReadLine(), out int luminescence))
                            _memoryManager.SetLuminescence(Math.Clamp(luminescence, 0, 999));
                        break;
                    case "7":
                        // Just refresh display
                        break;
                    case "8":
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
