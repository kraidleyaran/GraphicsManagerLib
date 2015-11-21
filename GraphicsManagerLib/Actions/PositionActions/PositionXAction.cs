﻿using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.PositionActions
{
    public class PositionXAction : IPositionAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType; } }
        public PositionType PositionType { get { return PositionType.X;} }
    }
}