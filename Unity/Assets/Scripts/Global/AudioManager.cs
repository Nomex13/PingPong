using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	private bool field_inited = false;

	public AudioClip MusicMenu;
	public AudioClip MusicGame;
	public AudioClip SoundPing1;
	public AudioClip SoundPing2;
	public AudioClip SoundPing3;
	public AudioClip SoundPing4;
	private int field_soundPingIndexLast = 0;

	private AudioSource field_musicAudioSource;
	private AudioSource field_soundAudioSource;
	private List<AudioSource> field_soundAudioSources = new List<AudioSource>();
	private AudioClip field_musicPlayingAudioClip;

	private float field_musicVolume = 1;
	public float MusicVolume
	{
		get
		{
			return field_musicVolume;
		}
		set
		{
			float volume = value;
			if (volume < 0)
				volume = 0;
			if (volume > 1)
				volume = 1;
			if (volume == field_musicAudioSource.volume)
				return;

			field_musicVolume = volume;
			field_musicAudioSource.volume = field_musicVolume;
		}
	}

	void Start ()
	{
		field_musicAudioSource = gameObject.AddComponent<AudioSource>();
		field_musicAudioSource.loop = false;
		field_musicAudioSource.ignoreListenerVolume = true;
		field_musicAudioSource.ignoreListenerPause = true;
		field_musicAudioSource.playOnAwake = false;

		field_soundAudioSource = gameObject.AddComponent<AudioSource>();
		field_soundAudioSource.loop = false;
		field_soundAudioSource.ignoreListenerVolume = true;
		field_soundAudioSource.ignoreListenerPause = true;
		field_soundAudioSource.playOnAwake = false;
	}
	
	void Update ()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	public void PlayMusicMenu()
	{
		if (field_musicPlayingAudioClip == MusicMenu)
			return;

		StopMusic();
		PlayMusic(MusicMenu);
	}

	public void PlayMusicGame()
	{
		if (field_musicPlayingAudioClip == MusicGame)
			return;

		StopMusic();
		PlayMusic(MusicGame);
	}

	public void PlaySoundPing()
	{
		field_soundPingIndexLast++;
		if (field_soundPingIndexLast > 4)
			field_soundPingIndexLast = 0;
	}

	void PlaySound(AudioClip param_audioClip)
	{
		if (param_audioClip == null)
			return;

		field_soundAudioSource.PlayOneShot(field_musicPlayingAudioClip);
	}

	public void PlayMusic(AudioClip param_audioClip)
	{
		if (field_musicPlayingAudioClip == param_audioClip || param_audioClip == null)
			return;

		field_musicPlayingAudioClip = param_audioClip;
		StartCoroutine("MusicLoop");
	}

	public void StopMusic()
	{
		Debug.Log("Music stopped");
		StopCoroutine("MusicLoop");
		field_musicAudioSource.Stop();
		field_musicPlayingAudioClip = null;
	}

	public void StopSounds()
	{
		for (int i = 0; i < field_soundAudioSources.Count; i++)
		{
			field_soundAudioSources[i].Stop();
		}
	}

	IEnumerator MusicLoop()
	{
		while (true)
		{
			if (field_musicPlayingAudioClip == null)
			{
				//Debug.Log("Music is null");
				break;
			}
			//Debug.Log("repeat in " + field_musicPlayingAudioClip.length);
			field_musicAudioSource.Stop();
			field_musicAudioSource.PlayOneShot(field_musicPlayingAudioClip);
			yield return StartCoroutine(Util.WaitForRealSeconds(field_musicPlayingAudioClip.length));
		}
	}
}
