

using System;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class LoopAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public bool Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Loop; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }   
    }
}