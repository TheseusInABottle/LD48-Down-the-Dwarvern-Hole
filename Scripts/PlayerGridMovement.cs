using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
	public GameplayManger gameplay;
	public Animator playerAnim;

	[Header("Player Movement Variables")]
	public bool isMoving; //Tells if the player is walking between tiles
	public bool blocked = false; //If true the player will not attempt to move to the directed tile
	public bool changingLevels = false;
	public LayerMask walls = 6; //Objects on this layer prevent the player from moving into the desired tile

	public PlayerGameplayInteractions gpi;

	private Vector3 startPosition, targetPosition;
	private float moveTime = 0.2f; //Amount of time it takes the player to walk between tiles

	private void Awake()
	{
		gpi = gameObject.GetComponent<PlayerGameplayInteractions>();
	}

	// Update is called once per frame
	void Update()
    {
		if (gameplay.nextFloor.deathAnim == true)
		{
			playerAnim.Play("Player Death");
		}

		if (gameplay.isDead == false && changingLevels == false)
		{
			//Checks the pressed key against the inputs to decide what direction to move
			if (InputManager.instance.InputDown("moveUp") && !isMoving)
			{
				playerAnim.Play("Move Up");
				StartCoroutine(MovePlayer(Vector3.up));
			}

			if (InputManager.instance.InputDown("moveDown") && !isMoving)
			{
				playerAnim.Play("Move Down");
				StartCoroutine(MovePlayer(Vector3.down));
			}

			if (InputManager.instance.InputDown("moveLeft") && !isMoving)
			{
				playerAnim.Play("Move Left");
				StartCoroutine(MovePlayer(Vector3.left));
			}

			if (InputManager.instance.InputDown("moveRight") && !isMoving)
			{
				playerAnim.Play("Move Right");
				StartCoroutine(MovePlayer(Vector3.right));
			}
		}

	}

	private IEnumerator MovePlayer(Vector3 direction)
	{
		isMoving = true;

		float elapsedTime = 0;

		startPosition = transform.position;
		targetPosition = startPosition + direction;

		if(Physics.Raycast(transform.position, direction, 1f, walls))
		{
			blocked = true;
		}
		else
		{
			blocked = false;
		}

		gpi.PlayerInteractions(direction);

		if (blocked == false)
		{
			while (elapsedTime < moveTime)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / moveTime));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			transform.position = targetPosition;
		}

		isMoving = false;
	}
}
