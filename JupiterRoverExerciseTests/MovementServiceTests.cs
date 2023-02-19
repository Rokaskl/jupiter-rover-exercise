using Moq;

namespace JupiterRoverExerciseTests
{
    public class MovementServiceTests
    {
        private IMovementService _movementService;
        private Mock<IRover> _roverMock;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _roverMock = new Mock<IRover>();
            _movementService = new MovementService(_roverMock.Object);
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

        [Test]
        [TestCase("BF")]
        [TestCase("BFBF")]
        [TestCase("BFBFBF")]
        [TestCase("BFBFBFB")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_XCommandsBAndF_RoverMoveMethodCalledXTimes(string commandsString)
        {
            _movementService.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            _roverMock.Verify(x => x.Move(MovementCommand.B), Times.Exactly(commandsString.Length / 2));
            _roverMock.Verify(x => x.Move(MovementCommand.F), Times.Exactly(commandsString.Length / 2));
        }

        [Test]
        [TestCase("LR")]
        [TestCase("LRLR")]
        [TestCase("LRLRLR")]
        [TestCase("LRLRLRLR")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_XCommandsLAndR_RoverRotateMethodCalledXTimes(string commandsString)
        {
            _movementService.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            _roverMock.Verify(x => x.Rotate(RotationCommand.L), Times.Exactly(commandsString.Length / 2));
            _roverMock.Verify(x => x.Rotate(RotationCommand.R), Times.Exactly(commandsString.Length / 2));
        }

        [Test]
        [TestCase("L")]
        [TestCase("LLL")]
        [TestCase("LLLFFF")]
        [TestCase("LLLRRRFFFBBB")]
        [TestCase("RRRBBB")]
        [TestCase("LRFBBBFR")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_ValidXCommands_RoverRotateAndMoveMethodsCalledXTimes(string commandsString)
        {
            var Ls = commandsString.Count(x => x.Equals('L'));
            var Rs = commandsString.Count(x => x.Equals('R'));
            var Fs = commandsString.Count(x => x.Equals('F'));
            var Bs = commandsString.Count(x => x.Equals('B'));

            _movementService.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            _roverMock.Verify(x => x.Rotate(RotationCommand.L), Times.Exactly(Ls));
            _roverMock.Verify(x => x.Rotate(RotationCommand.R), Times.Exactly(Rs));
            _roverMock.Verify(x => x.Move(MovementCommand.F), Times.Exactly(Fs));
            _roverMock.Verify(x => x.Move(MovementCommand.B), Times.Exactly(Bs));
        }

        [Test]
        [TestCase("")]
        [TestCase("LLLX")]
        [TestCase("XLLLFFF")]
        [TestCase("LLLRRXRFFFBBB")]
        [TestCase("X")]
        [TestCase("LRFBBBFR'`!.[]()1X")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_InValidCommands_RoverRotateAndMoveMethodsNeverCalled(string commandsString)
        {
            _movementService.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            _roverMock.Verify(x => x.Move(It.IsAny<MovementCommand>()), Times.Never);
            _roverMock.Verify(x => x.Rotate(It.IsAny<RotationCommand>()), Times.Never);
        }
    }
}