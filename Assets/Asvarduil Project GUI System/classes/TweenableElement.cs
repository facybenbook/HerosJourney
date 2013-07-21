using UnityEngine;
using System.Collections;

/// <summary>
/// Base class for an element that can be tweened across the screen.
/// </summary>
public abstract class TweenableElement : AsvarduilGUICore, ITweenable
{
	#region Variables
	
	/// <summary>
	/// The GUI element's target position.
	/// </summary>
	public Vector2 TargetPosition;
	
	/// <summary>
	/// The GUI element's target color.
	/// </summary>
	public Color TargetTint;

	/// <summary>
	/// The speed at which to animate the GUI element.
	/// 0 causes the element to not tween
	/// 1 causes the element to instantaneously relocate.
	/// </summary>
	public float TweenRate;
	
	#endregion Variables
	
	#region Constructor
	
	public TweenableElement(Vector2 pos,     Vector2 targetPos,
		                    Color tint,      Color targetTint,
		                    float tweenRate, bool isRelative = false)
		: base(pos, tint, isRelative)
	{
		TargetPosition = targetPos;
		TargetTint = targetTint;
		TweenRate = tweenRate;
	}
	
	#endregion Constructor
	
	#region Inheritable Methods
	
	/// <summary>
	/// Moves the GUI element from the current position
	/// towards the target position based on the Tween Rate.
	/// </summary>
	public virtual void Tween()
	{
		Position = Vector2.Lerp(Position, TargetPosition, TweenRate);
		Tint = Color.Lerp(Tint, TargetTint, TweenRate);
	}
	
	#endregion Inheritable Methods
}
