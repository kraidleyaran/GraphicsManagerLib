using System;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Conditions.ShapeCondition.RectangleConditions
{
    [Serializable]
    public class RectangleWidthCondition : IRectangleCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public int CompareValue { get; set; }
        public GraphicConditionType GraphicConditionType { get { return  GraphicConditionType.Shape; } }
        public ShapeType ShapeConditionType { get { return ShapeType.Rectangle; } }
        public RectangleType RectangleConditionType { get { return RectangleType.Width; } }
    }
}