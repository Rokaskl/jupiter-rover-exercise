using Moq;

namespace JupiterRoverExerciseTests
{
    public class MovementServiceTests
    {
        private readonly IMovementService _movementService;

        public MovementServiceTests()
        {
            var roverMock = new Mock<IRover>();
            _movementService = new MovementService(roverMock.Object);
        }

        [Test]
        [TestCase("F")]
        [TestCase("L")]
        [TestCase("FRF")]
        [TestCase("LLLRRR")]
        [TestCase("BFBFBF")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateCommandsString_ValidInput_ReturnsTrue(string commandsString)
        {
            var actualValidationResult = _movementService.ValidateCommandsString(commandsString);

            (bool, string) expectedValidationResult = new(true, "");
            Assert.That(actualValidationResult, Is.EqualTo(expectedValidationResult));
        }

        [Test]
        [TestCase("A")]
        [TestCase("RFA")]
        [TestCase("R1F")]
        [TestCase("R!F")]
        [TestCase("R_F")]
        [TestCase("R'F")]
        [TestCase("R``''/;!~@#$%^&*F")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateCommandsString_InvalidInput_ReturnsFalse(string commandsString)
        {
            var validationResult = _movementService.ValidateCommandsString(commandsString);

            Assert.That(validationResult.Item1, Is.EqualTo(false));
        }
    }
}