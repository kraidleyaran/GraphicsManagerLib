using System;
using GameGraphicsLib;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class StatusAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public AnimationStatus Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.Status; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }  
    }
}