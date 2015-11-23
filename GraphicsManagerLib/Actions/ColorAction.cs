using System;
using Microsoft.Xna.Framework;

namespace GraphicsManagerLib.Actions
{
    [Serializable]
    public class ColorAction : IGraphicAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public Color Value { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Color;} }

    }
}