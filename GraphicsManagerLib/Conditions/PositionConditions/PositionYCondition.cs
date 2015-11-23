using System;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Conditions.PositionConditions
{
    [Serializable]
    public class PositionYCondition : IPositionCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public float CompareValue { get; set; }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
        public PositionType PositionType { get { return PositionType.Y; } }
    }
}