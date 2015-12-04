using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameGraphicsLib;
using GameGraphicsLib.DrawableShapes;
using GraphicsManagerLib.Actions;
using GraphicsManagerLib.Actions.AnimationAction;
using GraphicsManagerLib.Actions.PositionActions;
using GraphicsManagerLib.Actions.ShapeActions;
using GraphicsManagerLib.Actions.ShapeActions.RectangleActions;
using GraphicsManagerLib.Conditions;
using GraphicsManagerLib.Conditions.AnimationConditions;
using GraphicsManagerLib.Conditions.AnimationConditions.Interfaces;
using GraphicsManagerLib.Conditions.PositionConditions;
using GraphicsManagerLib.Conditions.ShapeCondition;
using GraphicsManagerLib.Conditions.ShapeCondition.RectangleConditions;
using GraphicsManagerLib.GlobalEnums;
using Microsoft.Xna.Framework;
using ShapeType = GraphicsManagerLib.GlobalEnums.ShapeType;

namespace GraphicsManagerLib
{
    [Serializable]
    public class GraphicsManager
    {
        private Dictionary<string, IGraphicCondition> _conditions;
        private Dictionary<string, IGraphicAction> _actions;
        public GameGraphics GameGraphics;
        public GraphicsManager(Game game)
        {
            _conditions = new Dictionary<string, IGraphicCondition>();
            _actions = new Dictionary<string, IGraphicAction>();
            GameGraphics = new GameGraphics(game);
        }

        public GraphicsManager(GameGraphics gameGraphics)
        {
            _conditions = new Dictionary<string, IGraphicCondition>();
            _actions = new Dictionary<string, IGraphicAction>();
            GameGraphics = gameGraphics;
        }
        #region Conditions

        public bool AddCondition(IGraphicCondition condition)
        {
            if (_conditions.ContainsKey(condition.Name)) return false;
            _conditions.Add(condition.Name, condition);
            return true;
        }

        public bool RemoveCondition(string name)
        {
            return _conditions.Remove(name);
        }

        public void ClearConditions()
        {
            _conditions.Clear();
            _conditions = new Dictionary<string, IGraphicCondition>();
        }

        public bool? EvaluateCondition(string name)
        {
            if (!_conditions.ContainsKey(name)) throw new Exception("Graphic Condition " + name + " does not exist");
            return EvaluateCondition(_conditions[name]);
        }
        private bool? EvaluateCondition(IGraphicCondition condition)
        {
            if (!GameGraphics.DoesDrawableExist(condition.DrawableName)) return null;
            switch (condition.GraphicConditionType)
            {
                case GraphicConditionType.Animation:
                    IAnimationCondition animationCondition = (IAnimationCondition) condition;
                    return EvaluateAnimationCondition(animationCondition);
                case GraphicConditionType.Position:
                    IPositionCondition positionCondition = (IPositionCondition) condition;
                    return EvaluatePositionCondition(positionCondition);
                case GraphicConditionType.Shape:
                    IShapeCondition shapeCondition = (IShapeCondition) condition;
                    return EvaluateShapeCondition(shapeCondition);
                case GraphicConditionType.String:
                    StringCondition stringCondition = (StringCondition) condition;
                    return EvaluateStringCondition(stringCondition);
            }
            return null;
        }

        private bool? EvaluatePositionCondition(IPositionCondition condition)
        {
            IDrawn drawable = GameGraphics.GetDrawable(condition.DrawableName);
            switch (condition.PositionType)
            {
                case PositionType.X:
                    return CompareFloatValues(drawable.PositionX, condition.Operator, condition.CompareValue);
                case PositionType.Y:
                    return CompareFloatValues(drawable.PositionY, condition.Operator, condition.CompareValue);
            }
            return null;
        }
        private bool? EvaluateAnimationCondition(IAnimationCondition condition)
        {
            Animation animation = GameGraphics.GetDrawAnimation(condition.DrawableName);
            switch (condition.AnimationConditionType)
            {
                case AnimationConditionType.Status:
                    StatusCondition statusCondition = (StatusCondition) condition;
                    switch (statusCondition.Operator)
                    {
                        case Operator.Equal:
                            return animation.Status == statusCondition.CompareValue;
                        case Operator.NotEqual:
                            return animation.Status != statusCondition.CompareValue;
                        default:
                            return null;
                    }
                case AnimationConditionType.Looped:
                    LoopedCondition loopedCondition = (LoopedCondition) condition;
                    return CompareBoolValues(animation.IsLoop, loopedCondition.Operator, loopedCondition.CompareValue);

                case AnimationConditionType.Depth:
                    DepthCondition depthCondition = (DepthCondition) condition;
                    return CompareFloatValues(animation.Depth, depthCondition.Operator, depthCondition.CompareValue);

                case AnimationConditionType.Frame:
                    FrameCondition frameCondition = (FrameCondition) condition;
                    return CompareIntValues(animation.Frame, frameCondition.Operator, frameCondition.CompareValue);

                case AnimationConditionType.FramesPerSecond:
                    FramesPerSecondCondition fpsCondition = (FramesPerSecondCondition) condition;
                    return CompareIntValues(animation.FramesPerSecond, fpsCondition.Operator,fpsCondition.CompareValue );

                case AnimationConditionType.FrameHeight:
                    FrameHeightCondition heightCondition = (FrameHeightCondition) condition;
                    return CompareFloatValues(animation.GetCurrentFrame().TextureSource.Height, heightCondition.Operator,heightCondition.CompareValue);

                case AnimationConditionType.FrameWidth:
                    FrameWidthCondition widthCondition = (FrameWidthCondition) condition;
                    return CompareFloatValues(animation.GetCurrentFrame().TextureSource.Width, widthCondition.Operator,widthCondition.CompareValue);
            }
            return null;
        }

        private bool? EvaluateShapeCondition(IShapeCondition condition)
        {
            switch (condition.ShapeConditionType)
            {
                case ShapeType.Rectangle:
                    IRectangleCondition rectangleCondition = (IRectangleCondition) condition;
                    return EvaluateRectangleCondition(rectangleCondition);
                case ShapeType.Line:
                    LineCondition lineCondition = (LineCondition) condition;
                    return EvaluauteLineCondition(lineCondition);
            }
            return null;
        }
        private bool? EvaluateRectangleCondition(IRectangleCondition condition)
        {
            DrawnRectangle rectangle = (DrawnRectangle)GameGraphics.GetDrawShape(condition.DrawableName);
            switch (condition.RectangleConditionType)
            {
                case RectangleType.Height:
                    RectangleHeightCondition heightCondition = (RectangleHeightCondition) condition;
                    return CompareIntValues(rectangle.Height, heightCondition.Operator, heightCondition.CompareValue);
                case RectangleType.Width:
                    RectangleWidthCondition widthCondition = (RectangleWidthCondition) condition;
                    return CompareIntValues(rectangle.Width, widthCondition.Operator, widthCondition.CompareValue );
            }
            return null;
        }

        private bool? EvaluauteLineCondition(LineCondition condition)
        {
            DrawnLine line = (DrawnLine) GameGraphics.GetDrawShape(condition.DrawableName);
            float lineDisatance = Vector2.Distance(new Vector2(line.PositionX, line.PositionY), new Vector2(line.EndX, line.EndY));
            float compareDistance = Vector2.Distance(new Vector2(line.PositionX, line.PositionY), new Vector2(condition.EndX, condition.EndY));
            return CompareFloatValues(lineDisatance, condition.Operator, compareDistance);
        }

        private bool? EvaluateStringCondition(StringCondition condition)
        {
            DrawnString drawString = (DrawnString)GameGraphics.GetDrawShape(condition.DrawableName);
            switch (condition.Operator)
            {
                case Operator.Equal:
                    return drawString.Value == condition.CompareValue;
                case Operator.NotEqual:
                    return drawString.Value != condition.CompareValue;                    
                default:
                    return null;
            }
        }

        private bool? EvaluateColorCondition(ColorCondition condition)
        {
            IDrawn drawObject = GameGraphics.GetDrawable(condition.DrawableName);
            switch (drawObject.DrawnType)
            {
                case DrawnType.Animation:
                    return null;
                case DrawnType.Shape:
                    IDrawnShape shape = (IDrawnShape) drawObject;
                    return CompareColorValues(shape.Color, condition.Operator, condition.Value);
                case DrawnType.String:
                    DrawnString drawString = (DrawnString) drawObject;
                    return CompareColorValues(drawString.Color, condition.Operator, condition.Value);
                    
            }
            return null;
        }

        private static bool? CompareIntValues(int value1, Operator inputOperator, int value2)
        {
            switch (inputOperator)
            {
                case Operator.Equal:
                    return value1 == value2;
                case Operator.NotEqual:
                    return value1 != value2;
                case Operator.GreaterThan:
                    return value1 > value2;
                case Operator.GreaterThanOrEqualTo:
                    return value1 >= value2;
                case Operator.LessThan:
                    return value1 < value2;
                case Operator.LessThanOrEqualTo:
                    return value1 <= value2;
            }
            return null;
        }
        private static bool? CompareFloatValues(float value1, Operator inputOperator, float value2)
        {
            switch (inputOperator)
            {
                case Operator.Equal:
                    return value1 == value2;
                case Operator.NotEqual:
                    return value1 != value2;
                case Operator.GreaterThan:
                    return value1 > value2;
                case Operator.GreaterThanOrEqualTo:
                    return value1 >= value2;
                case Operator.LessThan:
                    return value1 < value2;
                case Operator.LessThanOrEqualTo:
                    return value1 <= value2;
            }
            return null;
        }

        private static bool? CompareStringValues(string value1, Operator inputOperator, string value2)
        {
            switch (inputOperator)
            {
                case Operator.Equal:
                    return value1 == value2;
                case Operator.NotEqual:
                    return value1 != value2;
                default:
                    return null;
            }
        }

        private static bool? CompareBoolValues(bool value1, Operator inputOperator, bool value2)
        {
            switch (inputOperator)
            {
                case Operator.Equal:
                    return value1 == value2;
                case Operator.NotEqual:
                    return value1 != value2;
                default:
                    return null;
            }
        }

        private static bool? CompareColorValues(Microsoft.Xna.Framework.Color value1, Operator inputOperator, Microsoft.Xna.Framework.Color value2)
        {
            switch (inputOperator)
            {
                case Operator.Equal:
                    return value1 == value2;
                case Operator.NotEqual:
                    return value1 != value2;
                default:
                    return null;
            }
        }
        #endregion
        #region Actions

        public bool AddAction(IGraphicAction action)
        {
            if (_actions.ContainsKey(action.Name)) return false;
            _actions.Add(action.Name, action);
            return true;
        }

        public bool RemoveAction(string name)
        {
            return _actions.Remove(name);
        }

        public void ClearActions()
        {
            _actions.Clear();
            _actions = new Dictionary<string, IGraphicAction>();
        }


        public bool? ExecuteAction(string name)
        {
            if (!_actions.ContainsKey(name)) return false;
            return ExecuteAction(_actions[name]);
        }
        public bool? ExecuteAction(IGraphicAction action)
        {
            
            switch (action.GraphicActionType)
            {
                case GraphicActionType.Animation:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    IAnimationAction animationAction = (IAnimationAction) action;
                    return ExecuteAnimationAction(animationAction);
                case GraphicActionType.Shape:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    IShapeAction shapeAction = (IShapeAction) action;
                    return ExecuteShapeAction(shapeAction);
                case GraphicActionType.String:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    StringAction stringAction = (StringAction) action;
                    return ExecuteStringAction(stringAction);
                case GraphicActionType.Position:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    IPositionAction positionAction = (IPositionAction) action;
                    return ExecutePositionAction(positionAction);
                case GraphicActionType.Color:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    ColorAction colorAction = (ColorAction) action;
                    return ExecuteColorAction(colorAction);
                case GraphicActionType.Add:
                    if (GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    AddAction addAction = (AddAction) action;
                    return ExecuteAddAction(addAction);
                case GraphicActionType.Remove:
                    if (!GameGraphics.DoesDrawableExist(action.Drawable)) return false;
                    RemoveAction removeAction = (RemoveAction) action;
                    return ExecuteRemoveAction(removeAction);
                default:
                    return null;
            }
        }

        private bool? ExecuteAddAction(AddAction action)
        {
            return GameGraphics.AddToDrawList(action.DrawParam);
        }

        private bool? ExecuteRemoveAction(RemoveAction action)
        {
            return GameGraphics.RemoveFromDrawList(action.Drawable);
        }

        private bool? ExecuteAnimationAction(IAnimationAction action)
        {
            Animation animation = GameGraphics.GetDrawAnimation(action.Drawable);
            switch (action.AnimationActionType)
            {
                case AnimationActionType.Depth:
                    DepthAction depthAction = (DepthAction)action;
                    animation.Depth = depthAction.Value;
                    break;
                case AnimationActionType.Frame:
                    FrameAction frameAction = (FrameAction)action;
                    animation.Frame = frameAction.Value;
                    break;
                case AnimationActionType.FramesPerSecond:
                    FramesPerSecondAction framesPerSecondAction = (FramesPerSecondAction)action;
                    animation.FramesPerSecond = framesPerSecondAction.Value;
                    break;
                case AnimationActionType.Loop:
                    LoopAction loopAction = (LoopAction)action;
                    switch (loopAction.Value)
                    {
                        case true:
                            if (!animation.IsLoop)
                            {
                                animation.Loop();
                            }
                            break;
                        case false:
                            if (animation.IsLoop)
                            {
                                animation.Loop();
                            }
                            break;
                    }
                    break;
                case AnimationActionType.Rotation:
                    RotationAction rotationAction = (RotationAction)action;
                    animation.Rotation = rotationAction.Value;
                    break;
                case AnimationActionType.Scale:
                    ScaleAction scaleAction = (ScaleAction) action;
                    animation.Scale = scaleAction.Value;
                    break;
                case AnimationActionType.Status:
                    StatusAction statusAction = (StatusAction)action;
                    switch (statusAction.Value)
                    {
                        case AnimationStatus.Paused:
                            if (!animation.IsPaused) animation.Pause();
                            break;
                        case AnimationStatus.Playing:
                            if (animation.Status != AnimationStatus.Playing) animation.Play();
                            break;
                        case AnimationStatus.Stopped:
                            if (animation.Status != AnimationStatus.Stopped) animation.Stop();
                            break;
                    }
                    break;
            }
            return GameGraphics.SetLoadedDrawn(animation, action.Drawable);
        }

        private bool? ExecuteShapeAction(IShapeAction action)
        {
            IDrawnShape shape = GameGraphics.GetDrawShape(action.Drawable);
            switch (action.ShapeType)
            {
                case ShapeType.Rectangle:
                    DrawnRectangle rectangle = (DrawnRectangle) shape;
                    IRectangleAction rectangleAction = (IRectangleAction) action;
                    switch (rectangleAction.RectangleType)
                    {
                        case RectangleType.Height:
                            rectangle.Size = new Size(rectangle.Size.Width, rectangleAction.Value);
                            break;
                        case RectangleType.Width:
                            rectangle.Size = new Size(rectangleAction.Value, rectangle.Size.Height);
                            break;
                    }
                    GameGraphics.SetLoadedDrawn(rectangle, rectangleAction.Drawable);
                    return true;                    
                case ShapeType.Line:
                    DrawnLine line = (DrawnLine) shape;
                    LineAction lineAction = (LineAction) action;
                    line.EndX = lineAction.EndX;
                    line.EndY = lineAction.EndY;
                    return GameGraphics.SetLoadedDrawn(line, lineAction.Drawable);
            }
            return null;
        }

        private bool? ExecuteStringAction(StringAction action)
        {
            DrawnString drawString = GameGraphics.GetDrawString(action.Drawable);
            drawString.Value = action.Value;
            return GameGraphics.SetLoadedDrawn(drawString, action.Drawable);
        }

        private bool? ExecutePositionAction(IPositionAction action)
        {
            IDrawn drawObject = GameGraphics.GetDrawable(action.Drawable);
            switch (action.PositionType)
            {
                case PositionType.X:
                    drawObject.PositionX = action.Value;
                    break;
                case PositionType.Y:
                    drawObject.PositionY = action.Value;
                    break;
            }
            return GameGraphics.SetLoadedDrawn(drawObject, action.Drawable);
        }

        private bool? ExecuteColorAction(ColorAction action)
        {
            IDrawn drawObject = GameGraphics.GetDrawable(action.Drawable);
            switch (drawObject.DrawnType)
            {
                case DrawnType.Animation:
                    return true;
                case DrawnType.Shape:
                    IDrawnShape shape = (IDrawnShape)drawObject;
                    shape.Color = action.Value;
                    return GameGraphics.SetLoadedDrawn(shape);
                case DrawnType.String:
                    DrawnString drawString = (DrawnString) drawObject;
                    drawString.Color = action.Value;
                    return GameGraphics.SetLoadedDrawn(drawString);
            }
            return null;
        }
        #endregion
    }
}
