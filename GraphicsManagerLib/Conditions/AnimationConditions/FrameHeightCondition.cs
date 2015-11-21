﻿using GraphicsManagerLib.Conditions.AnimationConditions.Interfaces;

namespace GraphicsManagerLib.Conditions.AnimationConditions
{
    public class FrameHeightCondition : IAnimationCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public float CompareValue { get; set; }
        public AnimationConditionType AnimationConditionType { get { return AnimationConditionType.FrameHeight; } }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
    }
}