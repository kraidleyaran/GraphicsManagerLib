using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.ShapeActions
{
    public interface IShapeAction : IGraphicAction
    {
        ShapeType ShapeType { get; }
    }
}