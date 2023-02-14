namespace JupiterRoverExercise;

public interface IRoverMovementService
{
    void ValidateAndExecuteCommandsFromCommandsString(string commandsString);
    void ValidateCommandsString(string commandsString);
}

public class RoverMovementService : IRoverMovementService
{
    public void ValidateAndExecuteCommandsFromCommandsString(string commandsString)
    {
        throw new NotImplementedException();
    }

    public void ValidateCommandsString(string commandsString)
    {
        throw new NotImplementedException();
    }
}