namespace JupiterRoverExerciseTests
{
    public class RoverTests
    {
        [Test]
        [TestCase(0, 0, Direction.N, MovementCommand.F, 1, 0, Direction.N)]
        [TestCase(-1, 3, Direction.N, MovementCommand.F, 0, 3, Direction.N)]
        [TestCase(0, 0, Direction.S, MovementCommand.F, -1, 0, Direction.S)]
        [TestCase(1, 0, Direction.E, MovementCommand.F, 1, 1, Direction.E)]
        [TestCase(5, 2, Direction.W, MovementCommand.F, 5, 1, Direction.W)]
        [TestCase(0, -2, Direction.W, MovementCommand.F, 0, -3, Direction.W)]
        [TestCase(0, 0, Direction.N, MovementCommand.B, -1, 0, Direction.N)]
        [TestCase(-1, 3, Direction.N, MovementCommand.B, -2, 3, Direction.N)]
        [TestCase(0, 0, Direction.S, MovementCommand.B, 1, 0, Direction.S)]
        [TestCase(1, 0, Direction.E, MovementCommand.B, 1, -1, Direction.E)]
        [TestCase(5, 2, Direction.W, MovementCommand.B, 5, 3, Direction.W)]
        [TestCase(0, -2, Direction.W, MovementCommand.B, 0, -1, Direction.W)]
        [Parallelizable(ParallelScope.All)]
        public void Move_CorrectPossitionChange(int startingX, int startingY, Direction startingDirection,
            MovementCommand movementCommand, int endX, int endY, Direction endDirection)
        {
            (int, int, Direction) startingPossition = new(startingX, startingY, startingDirection);
            Rover rover = new(startingPossition);

            rover.Move(movementCommand);

            (int, int, Direction) expectedEndPossition = (endX, endY, endDirection);
            Assert.That(rover.CurrentPosition, Is.EqualTo(expectedEndPossition));
        }

        [Test]
        [TestCase(0, 0, Direction.N, RotationCommand.R, 0, 0, Direction.E)]
        [TestCase(0, -3, Direction.E, RotationCommand.R, 0, -3, Direction.S)]
        [TestCase(-2, 0, Direction.S, RotationCommand.R, -2, 0, Direction.W)]
        [TestCase(-1, 3, Direction.W, RotationCommand.R, -1, 3, Direction.N)]
        [TestCase(0, 0, Direction.N, RotationCommand.L, 0, 0, Direction.W)]
        [TestCase(0, -3, Direction.W, RotationCommand.L, 0, -3, Direction.S)]
        [TestCase(-2, 0, Direction.S, RotationCommand.L, -2, 0, Direction.E)]
        [TestCase(-1, 3, Direction.E, RotationCommand.L, -1, 3, Direction.N)]
        [Parallelizable(ParallelScope.All)]
        public void Rotate_CorrectPossitionChange(int startingX, int startingY, Direction startingDirection,
    RotationCommand rotationDirection, int endX, int endY, Direction endDirection)
        {
            (int, int, Direction) startingPossition = new(startingX, startingY, startingDirection);
            Rover rover = new(startingPossition);

            rover.Rotate(rotationDirection);

            (int, int, Direction) expectedEndPossition = (endX, endY, endDirection);
            Assert.That(rover.CurrentPosition, Is.EqualTo(expectedEndPossition));
        }
    }
}