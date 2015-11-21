using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.ShapeActions.RectangleActions
{
    public interface IRectangleAction : IShapeAction
    {
        RectangleType RectangleType { get; }
        int Value { get; set; }
    }
}