namespace GraphicsManagerLib.Actions
{
    public class StringAction : IGraphicAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public string Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.String; } } 
    }
}