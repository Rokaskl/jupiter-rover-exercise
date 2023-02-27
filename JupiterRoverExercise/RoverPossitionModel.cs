namespace JupiterRoverExercise
{
    public record struct RoverPossitionModel(int X, int Y, Direction Direction);
   
    public static class RoverPossitionModelExtentions
    {
        public static RoverPossitionModel FromTupleToRoverPossitionModel(this (int, int, Direction) posstionTuple) => new()
        { X = posstionTuple.Item1, Y = posstionTuple.Item2, Direction = posstionTuple.Item3 };
    }
}