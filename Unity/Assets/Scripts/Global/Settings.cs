using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
	private bool field_inited = false;

	//private string field_path;
	//private Encoding field_encoding;

	private bool field_suspendSerialization = false;
	private volatile bool field_serializationNeeded = false;
	private Thread field_serializeThread = null;

	private string[] field_languages = new string[] { "AA", "EN", "RU", "DE", "FR", "IT", "ES" };
	public string[] Languages
	{
		get
		{
			return field_languages;
		}
	}
	private const string field_languageDefault = "AA" /* System language */;
	private string field_language;
	public string Language
	{
		get
		{
			return field_language;
		}
		set
		{
			if (!field_languages.Contains(value))
				return;

			if (value != field_languageDefault)
			{
				field_language = value;
			}
			else
			{
				string systemLanguage = Util.SystemLanguageToCountryCode(Application.systemLanguage);
				if (field_languages.Contains(systemLanguage))
				{
					field_language = systemLanguage;
				}
				else
				{
					field_language = "EN";
				}
			}
			Localization.language = field_language;
			Serialize();
		}
	}
	private const float field_musicVolumeDefault = 1;
	private float field_musicVolume;
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
			if (volume == field_musicVolume)
				return;

			field_musicVolume = volume;
			Global.AudioManager.MusicVolume = field_musicVolume;
			Serialize(1000);
		}
	}
	private const float field_soundVolumeDefault = 1;
	private float field_soundVolume;
	public float SoundVolume
	{
		get
		{
			return field_soundVolume;
		}
		set
		{
			float volume = value;
			if (volume < 0)
				volume = 0;
			if (volume > 1)
				volume = 1;
			if (volume == field_soundVolume)
				return;

			field_soundVolume = value;
			//Global.AudioManager.MusicVolume = field_musicVolume;
			Serialize(1000);
		}
	}
	private const float field_vibrationDefault = 1;
	private float field_vibration;
	public float Vibration
	{
		get
		{
			return field_vibration;
		}
		set
		{
			if (value < 0 || 1 < value)
				return;

			field_vibration = value;
			Serialize(1000);
		}
	}

	//public Settings()
	//{
	//}

	//void Start ()
	//{
	//	//field_path = Path.Combine(Application.streamingAssetsPath, "settings.txt");
	//	//field_encoding = new UTF8Encoding();

	//}

	public void Init()
	{
		if (field_inited)
			return;

		Deserialize();
		field_inited = true;
	}

	//void OnDestroy()
	void OnApplicationQuit()
	{
		Serialize();
	}
	
	void Update ()
	{
		if (field_serializationNeeded && !field_suspendSerialization)
		{
			Serialize();
			field_serializationNeeded = false;
		}
	}

	void Serialize(int param_timeToWaitInMilliseconds = 0)
	{
		if (field_suspendSerialization)
			return;

		if (param_timeToWaitInMilliseconds > 0)
		{
			if (field_serializeThread != null && field_serializeThread.IsAlive)
			{
				field_serializeThread.Abort();
			}
			field_serializeThread = new Thread(delegate()
			{
				Thread.Sleep(param_timeToWaitInMilliseconds);
				field_serializationNeeded = true;
			});
			field_serializeThread.Start();
			return;
		}

		Dictionary<string, object> settings = new Dictionary<string, object>();
		settings.Add("Language", field_language);
		settings.Add("MusicVolume", field_musicVolume);
		settings.Add("SoundVolume", field_soundVolume);
		settings.Add("Vibration", field_vibration);

		string settingsSerialized = JsonConvert.SerializeObject(settings, Formatting.None);
		PlayerPrefs.SetString("settings", settingsSerialized);
		PlayerPrefs.Save();

		Debug.Log("Settings written: " + settingsSerialized);
	}

	void Deserialize()
	{
		string settingsSerialized = PlayerPrefs.HasKey("settings") ? PlayerPrefs.GetString("settings") : "{}";
		Dictionary<string, object> settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(settingsSerialized);

		field_suspendSerialization = true;
		try
		{
			Language = settings.ContainsKey("Language") ? (string)(settings["Language"]) : field_languageDefault;
		}
		catch (Exception exception)
		{
			Debug.Log("Settings: couldn't read language value." + exception.StackTrace);
		}
		try
		{
			MusicVolume = settings.ContainsKey("MusicVolume") ? Convert.ToSingle((double)(settings["MusicVolume"])) : field_musicVolumeDefault;
		}
		catch (Exception exception)
		{
			Debug.Log("Settings: couldn't read music volume value." + exception.StackTrace);
		}
		try
		{
			SoundVolume = settings.ContainsKey("SoundVolume") ? Convert.ToSingle((double)(settings["SoundVolume"])) : field_soundVolumeDefault;
		}
		catch (Exception exception)
		{
			Debug.Log("Settings: couldn't read sound volume value." + exception.StackTrace);
		}
		try
		{
			Vibration = settings.ContainsKey("Vibration") ? Convert.ToSingle((double)(settings["Vibration"])) : field_vibrationDefault;
		}
		catch (Exception exception)
		{
			Debug.Log("Settings: couldn't read vibration value." + exception.StackTrace);
		}
		field_suspendSerialization = false;

		Debug.Log("Settings read: " + settingsSerialized);
	}

	//void Read()
	//{
	//	string text;
	//	if (field_path.Contains("://"))
	//	{
	//		var www = new WWW(field_path);
	//		text = www.text;
	//	}
	//	else
	//	{
	//		text = File.ReadAllText(field_path, field_encoding);
	//	}
	//}

	//void Write()
	//{
	//	string text = "";
	//	if (field_path.Contains("://"))
	//	{
	//		; // Can't write, Android and Web-player suck here
	//	}
	//	else
	//	{
	//		File.WriteAllText(field_path, text, field_encoding);
	//	}
	//}
}
