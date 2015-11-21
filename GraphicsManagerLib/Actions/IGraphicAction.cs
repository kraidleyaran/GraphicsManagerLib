namespace GraphicsManagerLib.Actions
{
    public interface IGraphicAction
    {
        string Name { get; set; }
        string Drawable { get; set; }
        GraphicActionType GraphicActionType { get; }
    }
}