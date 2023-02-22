namespace JupiterRoverExercise;

public interface IRoverService
{
    void ValidateAndExecuteCommandsFromCommandsString(string commandsString);
    (bool, string) ValidateCommandsString(string commandsString);
    (int,int,Direction) GetPossition();
}

public class RoverService : IRoverService
{
    private readonly IRover _rover;

    public RoverService(IRover rover)
    {
        _rover = rover;
    }

    public void ValidateAndExecuteCommandsFromCommandsString(string commandsString)
    {
        var validationResult = ValidateCommandsString(commandsString);
        if (!validationResult.Item1) throw new InvalidCommandsListException(validationResult.Item2);

        foreach (char symbol in commandsString.ToCharArray())
        {
            if (Enum.TryParse(symbol.ToString(), out MovementCommand movementCommand))
            {
                _rover.Move(movementCommand);
                continue;
            }

            if (Enum.TryParse(symbol.ToString(), out RotationCommand rotationCommand))
            {
                _rover.Rotate(rotationCommand);
                continue;
            }
        }
    }

    public (bool, string) ValidateCommandsString(string commandsString)
    {
        if (string.IsNullOrEmpty(commandsString)) return (false, "Commands list is empty");

        //Find invalid commands and build error message
        var invalidChars = new List<char>();
        foreach (char symbol in commandsString.ToCharArray())
        {
            // symbol is not letter or its not MovementCommand or RotationCommand
            if (!char.IsLetter(symbol) || IsNotMovementOrRotationCommand(symbol))
                invalidChars.Add(symbol);
        }
        if (invalidChars.Count != 0) return (false, string.Join(' ', "Commands list includes invalid commands :", string.Join(',', invalidChars)));

        return (true, string.Empty);
    }

    private static bool IsNotMovementOrRotationCommand(char symbol) =>
        !Enum.IsDefined(typeof(MovementCommand), symbol.ToString()) &&
        !Enum.IsDefined(typeof(RotationCommand), symbol.ToString());

    public (int, int, Direction) GetPossition()
    {
        throw new NotImplementedException();
    }
}