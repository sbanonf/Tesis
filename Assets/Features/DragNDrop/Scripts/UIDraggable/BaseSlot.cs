using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] bool isBase;

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableSign draggableSign = dropped.GetComponent<DraggableSign>();
            if (!isBase)
            {
                draggableSign.SetDNDState_InTarget();
                ValidateOnDrop(draggableSign);
                draggableSign.parentAfterDrag = transform;
            }
        }
    }

    protected virtual void ValidateOnDrop(DraggableSign draggableSign)
    {

    }
}
