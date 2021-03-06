﻿using System;

namespace GraphicsManagerLib.Actions.AnimationAction
{
    [Serializable]
    public class FramesPerSecondAction : IAnimationAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public int Value { get; set; }
        public AnimationActionType AnimationActionType { get { return AnimationActionType.FramesPerSecond; } }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Animation; } }  
    }
}