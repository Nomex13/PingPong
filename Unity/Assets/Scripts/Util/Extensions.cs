using UnityEngine;
using System.Collections;

public static class Extensions
{
	public static bool HasRigidbody(this GameObject param_gameObject)
	{
		return (param_gameObject.rigidbody != null);
	}
	public static string GetCode(this SystemLanguage param_systemLanguage)
	{
		switch (param_systemLanguage)
		{
			case SystemLanguage.Afrikaans: return "";
			case SystemLanguage.Arabic: return "";
			case SystemLanguage.Basque: return "";
			case SystemLanguage.Belarusian: return "";
			case SystemLanguage.Bulgarian: return "";
			case SystemLanguage.Catalan: return "";
			case SystemLanguage.Chinese: return "";
			case SystemLanguage.Czech: return "";
			case SystemLanguage.Danish: return "";
			case SystemLanguage.Dutch: return "";
			case SystemLanguage.English: return "EN";
			case SystemLanguage.Estonian: return "";
			case SystemLanguage.Faroese: return "";
			case SystemLanguage.Finnish: return "";
			case SystemLanguage.French: return "FR";
			case SystemLanguage.German: return "DE";
			case SystemLanguage.Greek: return "";
			case SystemLanguage.Hebrew: return "";
			//case SystemLanguage.Hugarian:		return "";
			case SystemLanguage.Hungarian: return "";
			case SystemLanguage.Icelandic: return "";
			case SystemLanguage.Indonesian: return "";
			case SystemLanguage.Italian: return "IT";
			case SystemLanguage.Japanese: return "";
			case SystemLanguage.Korean: return "";
			case SystemLanguage.Latvian: return "";
			case SystemLanguage.Lithuanian: return "";
			case SystemLanguage.Norwegian: return "";
			case SystemLanguage.Polish: return "";
			case SystemLanguage.Portuguese: return "";
			case SystemLanguage.Romanian: return "";
			case SystemLanguage.Russian: return "RU";
			case SystemLanguage.SerboCroatian: return "";
			case SystemLanguage.Slovak: return "";
			case SystemLanguage.Slovenian: return "";
			case SystemLanguage.Spanish: return "ES";
			case SystemLanguage.Swedish: return "";
			case SystemLanguage.Thai: return "";
			case SystemLanguage.Turkish: return "";
			case SystemLanguage.Ukrainian: return "";
			case SystemLanguage.Unknown: return "";
			case SystemLanguage.Vietnamese: return "";
			default: return "";
		}
	}
}
