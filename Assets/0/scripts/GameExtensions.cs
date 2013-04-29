using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameExtensions
{
	public static bool isTouchingWall (this CharacterController characterController)
	{
		return (characterController.collisionFlags & CollisionFlags.Sides) != 0;
	}
	
	static readonly System.Random random = new System.Random ();

	public static void Shuffle<T> (this IList<T> list)
	{
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = random.Next (n + 1);
			T value = list [k];
			list [k] = list [n];
			list [n] = value;
		}
	}
	
	/// <summary>
	/// Taken from http://stackoverflow.com/questions/9033/hidden-features-of-c/407325#407325
	/// instead of doing (enum & value) == value you can now use enum.Has(value)
	/// </summary>
	/// <typeparam name="T">Type of enum</typeparam>
	/// <param name="type">The enum value you want to test</param>
	/// <param name="value">Flag Enum Value you're looking for</param>
	/// <returns>True if the type has value bit set</returns>
	public static bool Has<T> (this System.Enum type, T value)
	{
		return (((int)(object)type & (int)(object)value) == (int)(object)value);
	}
	
	//
	//checks if a renderer is visible from a specified camera
	//
	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
