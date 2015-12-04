using System;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.PositionActions
{
    [Serializable]
    public class PositionXAction : IPositionAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Position; } }
        public PositionType PositionType { get { return PositionType.X;} }
    }
}