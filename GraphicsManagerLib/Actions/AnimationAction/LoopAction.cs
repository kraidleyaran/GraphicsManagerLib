

namespace GraphicsManagerLib.Actions.AnimationAction
{
    public class LoopAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public bool Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Depth; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }   
    }
}