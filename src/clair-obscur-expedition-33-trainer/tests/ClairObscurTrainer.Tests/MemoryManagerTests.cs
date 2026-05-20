using System;
using ClairObscurTrainer.Core;
using Xunit;

namespace ClairObscurTrainer.Tests
{
    /// <summary>
    /// Unit tests for the MemoryManager class.
    /// These tests validate logic without attaching to a real process.
    /// </summary>
    public class MemoryManagerTests
    {
        [Fact]
        public void AttachToProcess_WhenProcessNotFound_ReturnsFalse()
        {
            // Arrange: Use a non-existent process name
            var manager = new MemoryManager("NonExistentProcess");

            // Act
            bool result = manager.AttachToProcess();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetHealth_WhenNotAttached_ReturnsZero()
        {
            // Arrange
            var manager = new MemoryManager("TestProcess");

            // Act
            int health = manager.GetHealth();

            // Assert
            Assert.Equal(0, health);
        }

        [Fact]
        public void SetHealth_WhenNotAttached_DoesNotThrow()
        {
            // Arrange
            var manager = new MemoryManager("TestProcess");

            // Act & Assert: Should not throw exception
            var exception = Record.Exception(() => manager.SetHealth(50));
            Assert.Null(exception);
        }

        [Fact]
        public void GetStamina_WhenNotAttached_ReturnsZero()
        {
            var manager = new MemoryManager("TestProcess");
            int stamina = manager.GetStamina();
            Assert.Equal(0, stamina);
        }

        [Fact]
        public void GetMaxHealth_WhenNotAttached_ReturnsDefault()
        {
            var manager = new MemoryManager("TestProcess");
            int maxHealth = manager.GetMaxHealth();
            Assert.Equal(100, maxHealth);
        }

        [Fact]
        public void Detach_WhenNotAttached_DoesNotThrow()
        {
            var manager = new MemoryManager("TestProcess");
            var exception = Record.Exception(() => manager.Detach());
            Assert.Null(exception);
        }
    }
}
