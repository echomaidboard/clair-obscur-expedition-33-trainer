using System;
using ClairObscurTrainer.Core;
using ClairObscurTrainer.UI;

namespace ClairObscurTrainer
{
    /// <summary>
    /// Entry point for the Clair Obscur: Expedition 33 Trainer.
    /// Provides in-memory manipulation of game values for educational purposes.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clair Obscur: Expedition 33 Trainer v1.0");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Attaching to game process 'Expedition33.exe'...");

            var memoryManager = new MemoryManager("Expedition33");
            if (!memoryManager.AttachToProcess())
            {
                Console.WriteLine("Failed to attach to game. Ensure the game is running.");
                return;
            }

            var menu = new TrainerMenu(memoryManager);
            menu.Show();

            memoryManager.Detach();
            Console.WriteLine("Trainer closed.");
        }
    }
}
