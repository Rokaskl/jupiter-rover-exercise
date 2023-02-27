namespace JupiterRoverExercise
{
    public class RoverPossitionModel
    {
        /// <summary>
        /// X coordinate of current rover location 
        /// </summary>
        /// <example>1</example>
        public int X { get; set; }
        /// <summary>
        /// Y coordinate of current rover location 
        /// </summary>
        /// <example>-1</example>
        public int Y { get; set; }
        /// <summary>
        /// The direction rover is currently facing
        /// </summary>
        /// <example>N</example>
        public Direction Direction { get; set; }
    }
   
    public static class RoverPossitionModelExtentions
    {
        public static RoverPossitionModel FromTupleToRoverPossitionModel(this (int, int, Direction) posstionTuple) => new()
        { X = posstionTuple.Item1, Y = posstionTuple.Item2, Direction = posstionTuple.Item3 };
    }
}