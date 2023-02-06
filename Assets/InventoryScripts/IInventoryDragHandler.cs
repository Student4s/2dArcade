using UnityEngine.EventSystems;

namespace InventoryScripts
{
	public interface IInventoryDragHandler
	{
		internal void OnPointerDown(PointerEventData eventData, GridInventoryItem item);
		internal void OnPointerUp(PointerEventData eventData, GridInventoryItem item);
		internal void OnBeginDrag(PointerEventData eventData, GridInventoryItem item);
		internal void OnEndDrag(PointerEventData eventData, GridInventoryItem item);
		internal void OnDrag(PointerEventData eventData, GridInventoryItem item);
	}
}