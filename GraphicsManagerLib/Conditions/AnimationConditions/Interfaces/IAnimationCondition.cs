using System.Security.Cryptography.X509Certificates;

namespace GraphicsManagerLib.Conditions.AnimationConditions.Interfaces
{
    public interface IAnimationCondition : IGraphicCondition
    {
        AnimationConditionType AnimationConditionType { get; }
    }
}