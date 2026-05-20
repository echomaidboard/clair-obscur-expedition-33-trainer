using System;
using System.Diagnostics;
using System.Linq;
using MemorySharp;

namespace ClairObscurTrainer.Core
{
    /// <summary>
    /// Manages memory reading/writing to the Expedition 33 game process.
    /// Uses MemorySharp library for safe memory operations.
    /// </summary>
    public class MemoryManager
    {
        private readonly string _processName;
        private Process? _process;
        private SharpMemory? _memory;

        // Known memory offsets for Expedition 33 (example values - would need reverse engineering)
        private const int HealthOffset = 0x00A1B2C0;
        private const int StaminaOffset = 0x00A1B2C4;
        private const int LuminescenceOffset = 0x00A1B2C8;
        private const int MaxHealthOffset = 0x00A1B2D0;

        public MemoryManager(string processName)
        {
            _processName = processName;
        }

        /// <summary>
        /// Attaches to the target process by name.
        /// </summary>
        /// <returns>True if attachment succeeded.</returns>
        public bool AttachToProcess()
        {
            try
            {
                var processes = Process.GetProcessesByName(_processName);
                if (processes.Length == 0)
                {
                    Console.WriteLine($"No process found with name '{_processName}'.");
                    return false;
                }

                _process = processes.First();
                _memory = new SharpMemory(_process);
                Console.WriteLine($"Attached to {_process.ProcessName} (PID: {_process.Id}).");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attachment error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Reads the current health value from game memory.
        /// </summary>
        public int GetHealth()
        {
            if (_memory == null) return 0;
            return _memory.Read<int>(new IntPtr(HealthOffset));
        }

        /// <summary>
        /// Sets the health value in game memory.
        /// </summary>
        public void SetHealth(int value)
        {
            _memory?.Write(new IntPtr(HealthOffset), value);
        }

        /// <summary>
        /// Reads the current stamina value.
        /// </summary>
        public int GetStamina()
        {
            if (_memory == null) return 0;
            return _memory.Read<int>(new IntPtr(StaminaOffset));
        }

        /// <summary>
        /// Sets the stamina value.
        /// </summary>
        public void SetStamina(int value)
        {
            _memory?.Write(new IntPtr(StaminaOffset), value);
        }

        /// <summary>
        /// Reads the current luminescence (special resource) value.
        /// </summary>
        public int GetLuminescence()
        {
            if (_memory == null) return 0;
            return _memory.Read<int>(new IntPtr(LuminescenceOffset));
        }

        /// <summary>
        /// Sets the luminescence value.
        /// </summary>
        public void SetLuminescence(int value)
        {
            _memory?.Write(new IntPtr(LuminescenceOffset), value);
        }

        /// <summary>
        /// Reads the maximum health value.
        /// </summary>
        public int GetMaxHealth()
        {
            if (_memory == null) return 100;
            return _memory.Read<int>(new IntPtr(MaxHealthOffset));
        }

        /// <summary>
        /// Detaches from the game process and releases resources.
        /// </summary>
        public void Detach()
        {
            _memory?.Dispose();
            _memory = null;
            _process = null;
        }
    }
}
