using OS.Utilities;
using OS.Utilities.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OS.Portfolio.VirtualOS.UI
{
	public abstract class Draggable : Interactable, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[Header("References")] 
		[SerializeField] protected RectTransform _rectTransform;
		[SerializeField] protected GameObject _dragObject;

		protected bool _canDrag = false;
		protected bool _isBeingDragged = false;
		
		public override void SingleClick(PointerEventData eventData)
		{
			_canDrag = EventSystem.current.IsPointerOverSpecificGameObject(_dragObject);
		}

		public override void DoubleClick(PointerEventData eventData)
		{
			_canDrag = EventSystem.current.IsPointerOverSpecificGameObject(_dragObject);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_canDrag = false;
		}
		
		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!_canDrag)
			{
				return;
			}
			
			_isBeingDragged = true;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!_isBeingDragged || !_canDrag)
			{
				return;
			}

			if (!_rectTransform.IsWithinScreenBounds(eventData.delta))
			{
				return;
			}
			
			_rectTransform.position += (Vector3)eventData.delta;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			_isBeingDragged = false;
		}
	}
}
