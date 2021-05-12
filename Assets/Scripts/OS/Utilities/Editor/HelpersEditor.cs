using UnityEditor;
using UnityEngine;

namespace OS.Utilities.Editor
{
	public static class HelpersEditor
	{
		[MenuItem("Tools/Helpers/Get Random Long")]
		private static void GetRandomLong()
		{
			long randomLong = Helpers.RandomLong();
			GUIUtility.systemCopyBuffer = randomLong.ToString();
			Debug.Log($"[<color='#fc220f'>TOOLS</color>] Added {randomLong} to clipboard!");
		}
	}
}
