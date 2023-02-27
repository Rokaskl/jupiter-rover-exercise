namespace JupiterRoverExercise
{
    public class CommandsModel
    {
        /// <summary>
        /// Commands string. Valid commands are F (move forward), B (move backward), L (turn left), and R (turn right)
        /// </summary>
        /// <example>FLRB</example>
        public string Commands { get; set; } = String.Empty;
    }
}