using System;

namespace GraphicsManagerLib.Conditions.AnimationConditions
{
    [Serializable]
    public class FrameCountCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public int CompareValue { get; set; }
        public AnimationConditionType AnimationConditionType { get { return AnimationConditionType.FrameCount; } }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
    }
}