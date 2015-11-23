using System;
using GameGraphicsLib.DrawableShapes;
using GraphicsManagerLib.GlobalEnums;
using ShapeType = GraphicsManagerLib.GlobalEnums.ShapeType;

namespace GraphicsManagerLib.Actions.ShapeActions.RectangleActions
{
    [Serializable]
    public class RectangleWidthAction : IRectangleAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public int Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Shape;} }
        public ShapeType ShapeType { get { return ShapeType.Rectangle;} }
        public RectangleType RectangleType { get { return RectangleType.Width;} }
    }
}