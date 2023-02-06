using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryScripts
{
	public class GridInventoryItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler,
		IEndDragHandler, IDragHandler
	{
		
		public ItemInCell item;
		
		private IInventoryDragHandler _dragHandler;

		internal void SetDragHandler(IInventoryDragHandler dragHandler)
		{
			_dragHandler = dragHandler;
		}
		

		public void OnPointerDown(PointerEventData eventData)
		{
			_dragHandler.OnPointerDown(eventData, this);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_dragHandler.OnPointerUp(eventData, this);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			
			_dragHandler.OnBeginDrag(eventData, this);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			
			_dragHandler.OnEndDrag(eventData, this);
		}

		public void OnDrag(PointerEventData eventData)
		{
			_dragHandler.OnDrag(eventData, this);
		}
	}
}