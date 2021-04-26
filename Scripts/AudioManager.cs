using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public AudioMixer musicVolume;
	public AudioMixer sfxVolume;
	public AudioMixer voicesVolume;

	public AudioSource music;
	public AudioSource sfx;
	public AudioSource voices;

	[Header("IntroExit Clips")]
	public AudioClip[] startClips; //Case 1 clips
	public AudioClip[] deathClips; //Case 2 clips
	public AudioClip[] nextFloorClips; //Case 3 clips

	[Header("Item Clips")]
	public AudioClip[] potionClips; //Case 4 clips
	public AudioClip[] swordClips; //Case 5 clips
	public AudioClip[] shieldClips; //Case 6 clips
	public AudioClip[] keyClips; //Case 7 clips
	public AudioClip[] doorClips; //Case 8 clips

	[Header("Enemy Clips")]
	public AudioClip[] enemies; //Case 9 clips


	private void Start()
	{
		
	}

	public void SetMusicVolume(float volume)
	{
		musicVolume.SetFloat("Volume", volume);
	}
	public void SetSFXVolume(float volume)
	{
		sfxVolume.SetFloat("Volume", volume);
	}
	public void SetVoiceVolume(float volume)
	{
		voicesVolume.SetFloat("Volume", volume);
	}

	public void AudioRequest(int x)
	{
		switch (x)
		{
			case 1:
				int a = Random.Range(0, 5);
				voices.clip = startClips[a];
				voices.Play();
				break;

			case 2:
				int b = Random.Range(0, 5);
				voices.clip = deathClips[b];
				voices.Play();
				break;

			case 3:
				int c = Random.Range(0, 5);
				voices.clip = nextFloorClips[c];
				voices.Play();
				break;

			case 4:
				int d = Random.Range(0, 5);
				voices.clip = potionClips[d];
				voices.Play();
				break;

			case 5:
				int e = Random.Range(0, 5);
				voices.clip = swordClips[e];
				voices.Play();
				break;

			case 6:
				int f = Random.Range(0, 5);
				voices.clip = shieldClips[f];
				voices.Play();
				break;

			case 7:
				int g = Random.Range(0, 5);
				voices.clip = keyClips[g];
				voices.Play();
				break;

			case 8:
				int h = Random.Range(0, 5);
				voices.clip = doorClips[h];
				voices.Play();
				break;

			case 9:
				int i = Random.Range(0, 5);
				voices.clip = enemies[i];
				voices.Play();
				break;
		}
	}

	public void PlayTestSFX()
	{

	}

	public void PlayTestVoice()
	{
		int y = Random.Range(1, 9);
		AudioRequest(y);
		voices.Play();
	}
}
