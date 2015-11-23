using System;
using GraphicsManagerLib.Conditions.AnimationConditions.Interfaces;

namespace GraphicsManagerLib.Conditions.AnimationConditions
{
    [Serializable]
    public class FramesPerSecondCondition : IAnimationCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public int CompareValue { get; set; }
        public AnimationConditionType AnimationConditionType { get { return AnimationConditionType.FramesPerSecond; } }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
    }
}