using System;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class DepthAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Depth; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation;} }
    }
}