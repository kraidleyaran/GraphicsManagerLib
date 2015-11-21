using GraphicsManagerLib.Conditions.AnimationConditions.Interfaces;

namespace GraphicsManagerLib.Conditions.AnimationConditions
{
    public class LoopedCondition : IAnimationCondition
    {        
        public string Name { get; set; }
        public string DrawableName { get; set; }

        public Operator Operator { get; set; }
        public bool CompareValue { get; set; }
        public AnimationConditionType AnimationConditionType { get { return AnimationConditionType.Looped; } }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
    }
}