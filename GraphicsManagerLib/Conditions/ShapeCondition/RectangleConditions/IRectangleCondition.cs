using GraphicsManagerLib.Conditions.AnimationConditions;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Conditions.ShapeCondition.RectangleConditions
{
    public interface IRectangleCondition : IShapeCondition
    {
        RectangleType RectangleConditionType { get; } 
    }
}