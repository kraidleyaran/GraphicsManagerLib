namespace GraphicsManagerLib.Actions.AnimationAction
{
    public interface IAnimationAction : IGraphicAction
    {
        AnimationActionType AnimationActionType { get; }
    }
}