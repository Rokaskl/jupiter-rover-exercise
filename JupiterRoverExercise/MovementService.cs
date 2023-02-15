namespace JupiterRoverExercise;

public interface IMovementService
{
    void ValidateAndExecuteCommandsFromCommandsString(string commandsString);
    (bool,string) ValidateCommandsString(string commandsString);
}

public class MovementService : IMovementService
{
    public void ValidateAndExecuteCommandsFromCommandsString(string commandsString)
    {
        throw new NotImplementedException();
    }

    public (bool, string) ValidateCommandsString(string commandsString)
    {
        throw new NotImplementedException();
    }
}