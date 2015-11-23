using System;

namespace GraphicsManagerLib.Actions
{
    [Serializable]
    public class RemoveAction
    {
        public string Name { get; set; }
        public string Drawable { get; set; }
        public GraphicActionType GraphicActionType { get { return GraphicActionType.Remove; } } 
    }
}