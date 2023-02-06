using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryScripts
{
	public class InventoryDragHandler : MonoBehaviour, IInventoryDragHandler
	{
		[SerializeField] private Canvas neutralCanvas;

		private void Start()
		{
			foreach (GridInventoryItem item in GetComponentsInChildren<GridInventoryItem>())
			{
				item.SetDragHandler(this);
			}
		}


		void IInventoryDragHandler.OnPointerDown(PointerEventData eventData, GridInventoryItem item)
		{
		}

		void IInventoryDragHandler.OnPointerUp(PointerEventData eventData, GridInventoryItem item)
		{
		}

		void IInventoryDragHandler.OnBeginDrag(PointerEventData eventData, GridInventoryItem item)
		{
			item.item.transform.SetParent(neutralCanvas.transform);
			item.item.canvasGroup.blocksRaycasts = false;
			item.item.canvasGroup.alpha = 0.6f;
		}

		void IInventoryDragHandler.OnEndDrag(PointerEventData eventData, GridInventoryItem item)
		{
			//item.transform.SetParent(transform);
			item.item.canvasGroup.blocksRaycasts = true;
			item.item.canvasGroup.alpha = 1f;
		}

		void IInventoryDragHandler.OnDrag(PointerEventData eventData, GridInventoryItem item)
		{
			item.item.rect.anchoredPosition += eventData.delta / neutralCanvas.scaleFactor;
		}
	}
}