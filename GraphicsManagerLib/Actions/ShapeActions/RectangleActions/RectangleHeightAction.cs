using GraphicsManagerLib.Conditions.ShapeCondition;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.ShapeActions.RectangleActions
{
    public class RectangleHeightAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Shape; } }
        public ShapeType ShapeType { get { return ShapeType.Rectangle; } }
        public RectangleType RectangleType { get { return RectangleType.Width; } } 
    }
}