namespace GraphicsManagerLib.Actions.AnimationAction
{
    public class FramesPerSecondAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public int Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Depth; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }  
    }
}