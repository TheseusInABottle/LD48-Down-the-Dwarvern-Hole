using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inputs")]
public class Inputs : ScriptableObject
{
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode options;
	public KeyCode instructions;

	public KeyCode checkKey(string key)
	{
		switch (key)
		{
			case "moveUp":
				return moveUp;
			case "moveDown":
				return moveDown;
			case "moveLeft":
				return moveLeft;
			case "moveRight":
				return moveRight;
			case "options":
				return options;
			case "instructions":
				return instructions;
			default:
				return KeyCode.None;
		}
	}
}
