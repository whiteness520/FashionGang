using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public GameObject itemInSlot;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDropItem item = dropped.GetComponent<DragDropItem>();

        if (item == null) return;

        if (transform.childCount > 0)
        {
            Transform currentItem = transform.GetChild(0);
            currentItem.SetParent(item.originalParent);
            item.originalParent.GetComponent<InventorySlot>().itemInSlot = itemInSlot;
            currentItem.localPosition = Vector3.zero;
        }

        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;

        itemInSlot = item.transform.gameObject;
    }
}
