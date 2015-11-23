using System;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class FrameAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public int Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Depth; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }  
    }
}