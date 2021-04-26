using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameplayInteractions : MonoBehaviour
{
	public LayerMask interactable;
	public GameplayManger gameplay;
	public PlayerGridMovement grid;

	[Header("Audio")]
	public AudioManager voiceClips;

	private void Awake()
	{
		voiceClips.AudioRequest(1);
		grid = gameObject.GetComponent<PlayerGridMovement>();
	}

	public void PlayerInteractions (Vector3 direction)
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, direction, out hit, 1f, interactable))
		{
			
			switch (hit.collider.tag)
			{
				case "Enemy":
					if(gameplay.hasSword == true)
					{
						Destroy(hit.collider.gameObject);
						gameplay.hasSword = false;
					}
					grid.blocked = true;
					gameplay.DamagePlayer(1);
					gameplay.hasShield = false;
					voiceClips.AudioRequest(9);
					break;

				case "Key": gameplay.numbOfKeys++;
					Destroy(hit.collider.gameObject, 0.1f);
					voiceClips.AudioRequest(7);
					break;

				case "Lockblock": 
					if(gameplay.numbOfKeys > 0)
					{
						gameplay.numbOfKeys--;
						Destroy(hit.collider.gameObject);
						grid.blocked = true;
						
					}
					else
					{
						grid.blocked = true;
						voiceClips.AudioRequest(8);
					}
					break;

				case "Potion": if (gameplay.hasShield == true)
					{
						gameplay.hasShield = false;
						gameplay.DamagePlayer(-1);
						gameplay.hasShield = true;
					}
					else
					{
						gameplay.DamagePlayer(-1);
					}

					voiceClips.AudioRequest(4);
					Destroy(hit.collider.gameObject, 0.1f);
					break;

				case "Shield": gameplay.hasShield = true;
					Destroy(hit.collider.gameObject, 0.1f);
					voiceClips.AudioRequest(6);
					break;

				case "Sword": gameplay.hasSword = true;
					Destroy(hit.collider.gameObject, 0.1f);
					voiceClips.AudioRequest(5);
					break;

				case "Exit":
					
					grid.changingLevels = true;
					grid.playerAnim.Play("Next Floor");
					voiceClips.AudioRequest(3);
					break;

			}
		}
	}
}
