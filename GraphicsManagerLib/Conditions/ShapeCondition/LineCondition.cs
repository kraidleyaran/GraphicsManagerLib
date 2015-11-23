using System;
using GraphicsManagerLib.GlobalEnums;
using Microsoft.Xna.Framework;

namespace GraphicsManagerLib.Conditions.ShapeCondition
{
    [Serializable]
    public class LineCondition : IShapeCondition
    {
        public LineCondition()
        {
            
        }

        public LineCondition(string name, string drawableName, Operator inputOperator,
            float endX, float endY)
        {
            Name = name;
            DrawableName = drawableName;
            Operator = inputOperator;
            EndX = endX;
            EndY = endY;
        }
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public float EndX { get; set; }
        public float EndY { get; set; }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Shape; } }
        public ShapeType ShapeConditionType { get { return ShapeType.Line; } }

    }
}