using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Conditions.ShapeCondition
{
    public interface IShapeCondition : IGraphicCondition
    {
        ShapeType ShapeConditionType { get; } 
    }
}