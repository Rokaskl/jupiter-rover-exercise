namespace JupiterRoverExercise;

public interface IRover
{
    void Move(MovementCommand movementDirection);
    void Rotate(RotationCommand rotationDirection);
}

public class Rover
{
    private (int, int, Direction) _currentPosition;
    public (int, int, Direction) CurrentPosition => _currentPosition;

    public Rover((int, int, Direction)? currentPossition = null)
    {
        _currentPosition = currentPossition ?? (0, 0, Direction.N);
    }

    public void Move(MovementCommand movementcommand)
    {
        switch ((movementcommand, _currentPosition.Item3))
        {
            case (MovementCommand.F, Direction.N):
            case (MovementCommand.B, Direction.S):
                _currentPosition.Item1++;
                break;
            case (MovementCommand.F, Direction.S):
            case (MovementCommand.B, Direction.N):
                _currentPosition.Item1--;
                break;
            case (MovementCommand.F, Direction.E):
            case (MovementCommand.B, Direction.W):
                _currentPosition.Item2++;
                break;
            case (MovementCommand.F, Direction.W):
            case (MovementCommand.B, Direction.E):
                _currentPosition.Item2--;
                break;

            default:
                throw new InvalidOperationException("Invalid movement command or current rover direction");
        };
    }

    public void Rotate(RotationCommand rotationDirection)
    {
        switch ((rotationDirection, _currentPosition.Item3))
        {
            case (RotationCommand.R, Direction.N):
            case (RotationCommand.L, Direction.S):
                _currentPosition.Item3 = Direction.E;
                break;
            case (RotationCommand.R, Direction.E):
            case (RotationCommand.L, Direction.W):
                _currentPosition.Item3 = Direction.S;
                break;
            case (RotationCommand.R, Direction.S):
            case (RotationCommand.L, Direction.N):
                _currentPosition.Item3 = Direction.W;
                break;
            case (RotationCommand.R, Direction.W):
            case (RotationCommand.L, Direction.E):
                _currentPosition.Item3 = Direction.N;
                break;

            default:
                throw new InvalidOperationException("Invalid rotation command or current rover direction");
        };
    }
}

public enum MovementCommand
{
    F,
    B
}

public enum RotationCommand
{
    R,
    L
}

public enum Direction
{
    N,
    E,
    S,
    W
}