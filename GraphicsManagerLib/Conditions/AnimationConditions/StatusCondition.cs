using GameGraphicsLib;
using GraphicsManagerLib.Conditions.AnimationConditions.Interfaces;

namespace GraphicsManagerLib.Conditions.AnimationConditions
{
    public class StatusCondition : IAnimationCondition
    {
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public AnimationStatus CompareValue { get; set; }
        public AnimationConditionType AnimationConditionType { get { return AnimationConditionType.Status; } }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.Animation; } }
    }
}