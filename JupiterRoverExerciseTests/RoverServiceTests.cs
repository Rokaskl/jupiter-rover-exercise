using Moq;

namespace JupiterRoverExerciseTests
{
    [TestFixture]
    public class RoverServiceTests
    {
        [Test]
        [TestCase("F")]
        [TestCase("L")]
        [TestCase("FRF")]
        [TestCase("LLLRRR")]
        [TestCase("BFBFBF")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateCommandsString_ValidInput_ReturnsTrue(string commandsString)
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            var actualValidationResult = roverSerive.ValidateCommandsString(commandsString);

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
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            var validationResult = roverSerive.ValidateCommandsString(commandsString);

            Assert.That(validationResult.Item1, Is.EqualTo(false));
        }

        [Test]
        [TestCase("BF")]
        [TestCase("BFBF")]
        [TestCase("BFBFBF")]
        [TestCase("BFBFBFBF")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_XCommandsBAndF_RoverMoveMethodCalledXTimes(string commandsString)
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            roverSerive.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            roverMock.Verify(x => x.Move(MovementCommand.B), Times.Exactly(commandsString.Length / 2));
            roverMock.Verify(x => x.Move(MovementCommand.F), Times.Exactly(commandsString.Length / 2));
        }

        [Test]
        [TestCase("LR")]
        [TestCase("LRLR")]
        [TestCase("LRLRLR")]
        [TestCase("LRLRLRLR")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_XCommandsLAndR_RoverRotateMethodCalledXTimes(string commandsString)
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            roverSerive.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            roverMock.Verify(x => x.Rotate(RotationCommand.L), Times.Exactly(commandsString.Length / 2));
            roverMock.Verify(x => x.Rotate(RotationCommand.R), Times.Exactly(commandsString.Length / 2));
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
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);
            var Ls = commandsString.Count(x => x.Equals('L'));
            var Rs = commandsString.Count(x => x.Equals('R'));
            var Fs = commandsString.Count(x => x.Equals('F'));
            var Bs = commandsString.Count(x => x.Equals('B'));

            roverSerive.ValidateAndExecuteCommandsFromCommandsString(commandsString);

            roverMock.Verify(x => x.Rotate(RotationCommand.L), Times.Exactly(Ls));
            roverMock.Verify(x => x.Rotate(RotationCommand.R), Times.Exactly(Rs));
            roverMock.Verify(x => x.Move(MovementCommand.F), Times.Exactly(Fs));
            roverMock.Verify(x => x.Move(MovementCommand.B), Times.Exactly(Bs));
        }

        [Test]
        [TestCase("")]
        [TestCase("LLLX")]
        [TestCase("XLLLFFF")]
        [TestCase("LLLRRXRFFFBBB")]
        [TestCase("X")]
        [TestCase("LRFBBBFR'`!.[]()1X")]
        [Parallelizable(ParallelScope.All)]
        public void ValidateAndExecuteCommandsFromCommandsString_InValidCommands_ThrowsInvalidCommandsListException(string commandsString)
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            Assert.That(() => roverSerive.ValidateAndExecuteCommandsFromCommandsString(commandsString),Throws.Exception.TypeOf<InvalidCommandsListException>());
        }

        [Test]
        public void GetPossition_CallsGetRoverCurrentPositionOnce()
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            roverSerive.GetPossition();

            roverMock.VerifyGet(x => x.CurrentPosition, Times.Once);

        }

        [Test]
        public void ResetPossition_CallsRoverResetPositionOnce()
        {
            var roverMock = new Mock<IRover>();
            var roverSerive = new RoverService(roverMock.Object);

            roverSerive.ResetPossition();

            roverMock.Verify(x => x.ResetPossition(null), Times.Once);
        }
    }
}