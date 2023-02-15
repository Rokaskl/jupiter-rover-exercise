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

    public void Move(MovementCommand movementDirection)
    {
        throw new NotImplementedException();
    }

    public void Rotate(RotationCommand rotationDirection)
    {
        throw new NotImplementedException();
    }
}

public enum MovementCommand
{
    F = 1,
    B = -1
}

public enum RotationCommand
{
    R = 1,
    L = -1
}

public enum Direction
{
    N = 0,
    E = 1,
    S = 2,
    W = 3
}