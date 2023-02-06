using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryScripts
{
    public class DropHandler : MonoBehaviour, IDropHandler
    {
        [SerializeField] private GridInventoryItem cell;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
            {
                return;
            }

            GameObject a = eventData.pointerDrag;
            
            ItemInCell itemb = a.GetComponent<GridInventoryItem>().item;

            cell.item = itemb;
            itemb.transform.SetParent(transform);
            itemb.rect.anchoredPosition = Vector2.zero;
        }
    }
}