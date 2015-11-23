using System;
using GameGraphicsLib;

namespace GraphicsManagerLib.Actions
{
    [Serializable]
    public class AddAction : IGraphicAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public DrawParam DrawParam { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Add;} }
    }
}