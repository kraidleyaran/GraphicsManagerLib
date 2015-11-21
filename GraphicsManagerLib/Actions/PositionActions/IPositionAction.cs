using System.Security.Cryptography.X509Certificates;
using GraphicsManagerLib.GlobalEnums;

namespace GraphicsManagerLib.Actions.PositionActions
{
    public interface IPositionAction : IGraphicAction
    {
        float Value { get; set;  }
        PositionType PositionType { get; }
    }
}