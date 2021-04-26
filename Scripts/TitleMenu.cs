using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
	private bool inInformation;
	private bool inOptions;
	public Animator optionsAnimation;
	public Animator infoAnim;
	public Inputs keys;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (InputManager.instance.InputDown("options") && inInformation == false)
		{
			inOptions = !inOptions;
			inInformation = false;
			if (inOptions == true)
			{
				optionsAnimation.Play("Slide In");
			}
			else
			{
				optionsAnimation.Play("Slide Out");
			}
		}

		if (InputManager.instance.InputDown("instructions") && inOptions == false)
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
}
