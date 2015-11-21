using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Conditions.PositionConditions
{
    public interface IPositionCondition : IGraphicCondition
    {
        PositionType PositionType { get; }
        float CompareValue { get; set; }
    }
}