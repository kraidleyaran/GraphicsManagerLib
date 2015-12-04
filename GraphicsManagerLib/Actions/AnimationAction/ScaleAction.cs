using System;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class ScaleAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public float Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Scale; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }  
    }
}