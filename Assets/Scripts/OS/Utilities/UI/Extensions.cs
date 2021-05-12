using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OS.Utilities.UI
{
	public static class Extensions
	{
		public static void SetSprite(this Image image, Sprite sprite)
		{
			image.sprite = sprite;
			image.enabled = image.sprite;
		}

		public static bool IsWithinScreenBounds(this RectTransform rectTransform)
		{
			return IsWithinScreenBounds(rectTransform, Vector3.zero);
		}

		public static bool IsWithinScreenBounds(this RectTransform rectTransform, Vector3 offset)
		{
			Vector3[] corners = new Vector3[4];
			int visibleCorners = 0;
			
			rectTransform.GetWorldCorners(corners);
			
			Rect rect = new Rect(0,0,Screen.width, Screen.height);
			
			foreach(Vector3 corner in corners)
			{
				
				if(!rect.Contains(corner + offset))
				{
					continue;
				}
				
				visibleCorners++;
			}

			return visibleCorners == 4;
		}
		
		public static bool IsPointerOverSpecificGameObject(this EventSystem eventSystem, GameObject obj)
		{
			PointerEventData eventDataCurrentPosition = new PointerEventData(eventSystem) { position = Input.mousePosition };

			var results = new List<RaycastResult>();

			eventSystem.RaycastAll(eventDataCurrentPosition, results);

			return results.Count > 0 && results[0].gameObject == obj;
		}
		
		public static bool IsPointerOverSpecificGameObjectOrChild(this EventSystem eventSystem, GameObject obj)
		{
			PointerEventData eventDataCurrentPosition = new PointerEventData(eventSystem) { position = Input.mousePosition };

			var results = new List<RaycastResult>();

			eventSystem.RaycastAll(eventDataCurrentPosition, results);

			return results.Count > 0 && (results[0].gameObject == obj || results[0].gameObject.CheckParentRecursive(obj));
		}

	}
}
