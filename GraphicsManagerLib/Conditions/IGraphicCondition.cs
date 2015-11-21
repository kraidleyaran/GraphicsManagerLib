namespace GraphicsManagerLib.Conditions
{
    public interface IGraphicCondition
    {
        string Name { get; set; }
        string DrawableName { get; set; }
        Operator Operator { get; set; }
        GraphicConditionType GraphicConditionType { get; }
    }
}