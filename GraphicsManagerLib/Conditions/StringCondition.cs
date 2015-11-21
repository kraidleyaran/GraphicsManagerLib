using System.Runtime.InteropServices;

namespace GraphicsManagerLib.Conditions
{
    public class StringCondition : IGraphicCondition
    {
        public StringCondition()
        {
            
        }

        public StringCondition(string name, string drawableName, Operator inputOperator, string compareValue)
        {
            Name = name;
            DrawableName = drawableName;
            Operator = inputOperator;
            CompareValue = compareValue;
        }
        public string Name { get; set; }
        public string DrawableName { get; set; }
        public Operator Operator { get; set; }
        public string CompareValue { get; set; }
        public GraphicConditionType GraphicConditionType { get { return GraphicConditionType.String; } }
    }
}