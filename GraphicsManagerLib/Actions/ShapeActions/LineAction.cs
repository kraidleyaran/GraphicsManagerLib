using System;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.ShapeActions
{
    [Serializable]
    public class LineAction :  IShapeAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float EndX { get; set; }
        public float EndY { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Shape; } }
        public ShapeType ShapeType { get { return ShapeType.Line; } }
    }
}