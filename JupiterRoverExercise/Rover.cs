namespace JupiterRoverExercise;

public interface IRover
{
    void Move(MovementDirection movementDirection);
    void Rotate(RotationDirection rotationDirection);
}
public class Rover
{
    private readonly Tuple<int, int, Direction> _currentPosition;
    public Tuple<int, int, Direction> CurrentPosition => _currentPosition;

    public Rover()
    {
        _currentPosition = new(0, 0, Direction.N);
    }

    public void Move(MovementDirection movementDirection)
    {
        throw new NotImplementedException();
    }

    public void Rotate(RotationDirection rotationDirection)
    {
        throw new NotImplementedException();
    }
}
public enum MovementDirection
{
    F = 1,
    B = -1
}

public enum RotationDirection
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