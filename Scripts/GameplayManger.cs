using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManger : MonoBehaviour
{
	public Inputs playerBindings;
	private static int sceneCount = 0;

	[Header("Player Values")]
	public int hitPoints = 3; //Corisonds to the number of hearts the player has
	public int numbOfKeys = 0; //Corrisonds to the number of keys the player has (keys open locked doors)
	public bool hasSword = false; //If the player has a sword they can kill enemies
	public bool hasShield = false; //If the player has a shield they don't take damage from bumbing into enemies
	public bool isDead = false; //If true the player is dead and the try again screen appears
	public NextFloorCheck nextFloor;

	[Header("UI Game Objects")]
	public GameObject[] hearts; //These objects are the heart shaped meshes in the top right
	public GameObject swordIcon; //This is the icon to indicate that the player has picked up a sword
	public GameObject shieldIcon; //This is the icon to indicate that the player has picked up a shield
	public Text keys; // This is the text displaying how many keys the player has
	public Text options; // This is the text informaing the player what button to press to access the options menu
	public Text optionClose;
	public GameObject optionsPanel;
	public bool inOptions = false; //This checks if the options menu is currently open
	public Text information; // This is the text telling the player what button to press to open the information panel
	public Text infoClose;
	public GameObject infoPanel;
	public bool inInformation = false; // This is the text checking if the information panel is currently on display
	public Animator optionsAnimation;
	public Animator infoAnim;
	public Text gameOver;
	public Button deadRestart;
	public Button nextLevel;

	public AudioManager audioEffect;



    // Update is called once per frame
    void Update()
    {


		if (isDead == true)
		{
			
			gameOver.text = "Game Over";
			deadRestart.gameObject.SetActive(true);
			
		}
		else
		{
			gameOver.text = "";
			deadRestart.gameObject.SetActive(false);
			switch (hitPoints)
			{
				case 3: hearts[0].SetActive(true); hearts[1].SetActive(true); hearts[2].SetActive(true); break;
				case 2: hearts[0].SetActive(true); hearts[1].SetActive(true); hearts[2].SetActive(false); break;
				case 1: hearts[0].SetActive(true); hearts[1].SetActive(false); hearts[2].SetActive(false); break;
				case 0: hearts[0].SetActive(false); hearts[1].SetActive(false); hearts[2].SetActive(false); audioEffect.AudioRequest(2);
					nextFloor.deathAnim = true; isDead = true; break;
			}
		}

		if(hasShield == true)
		{
			shieldIcon.SetActive(true);
		}
		else
		{
			shieldIcon.SetActive(false);
		}

		if (hasSword == true)
		{
			swordIcon.SetActive(true);
		}
		else
		{
			swordIcon.SetActive(false);
		}

		keys.text = ": 0" + numbOfKeys.ToString();
		options.text = "Press " + playerBindings.options.ToString() + " for Options";
		optionClose.text = "Press " + playerBindings.options.ToString() + " to Close";
		information.text = "Press " + playerBindings.instructions.ToString() + " for Information";
		infoClose.text = "Press " + playerBindings.instructions.ToString() + " to Close";

		if (nextFloor.nextFloorPlease == true)
		{
			Scene current = SceneManager.GetActiveScene();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (InputManager.instance.InputDown("options") && inInformation == false && isDead == false)
		{
			inOptions = !inOptions;
			inInformation = false;
			if(inOptions == true)
			{
				optionsAnimation.Play("Slide In");
			}
			else
			{
				optionsAnimation.Play("Slide Out");
			}
		}

		if (InputManager.instance.InputDown("instructions") && inOptions == false && isDead == false)
		{
			inInformation = !inInformation;
			inOptions = false;
			if (inInformation == true)
			{
				infoAnim.Play("Slide In");
			}
			else
			{
				infoAnim.Play("Slide Out");
			}
		}
	}


	// Deals damage to the players HP and checks if they have a shield
	public void DamagePlayer(int damage)
	{
		if(hasShield == true)
		{
			damage = 0;
		}

		hitPoints -= damage;

		if(hitPoints >= 3)
		{
			hitPoints = 3;
		}
	}

	public void ReloadLevel()
	{
		Scene current = SceneManager.GetActiveScene();
		SceneManager.LoadScene(current.name);
	}

	public void LoadNextLevel()
	{
		sceneCount++;
		if(sceneCount < 5)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

	}
}
