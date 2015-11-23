using System;
using Microsoft.Xna.Framework;

namespace GraphicsManagerLib.Conditions
{
    [Serializable]
    public class ColorCondition : IGraphicCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public Color Value { get; set; }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Color;} }

    }
}