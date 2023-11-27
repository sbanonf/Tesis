using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] bool isBase;
    [SerializeField] bool isSimpleDraggable = true;
    [SerializeField] Transform sonContainer;

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 1)
        {
            GameObject dropped = eventData.pointerDrag;

            if (isSimpleDraggable)
            {
                DraggableSign draggableSign = dropped.GetComponent<DraggableSign>();
                if (!isBase)
                {
                    print("IsBase");
                    draggableSign.SetDNDState_InTarget();
                    ValidateOnDrop(draggableSign);
                    draggableSign.parentAfterDrag = transform;
                    print("OutBase");
                }
            }
            else
            {
                DraggableSign_Puzzle draggableSign = dropped.GetComponent<DraggableSign_Puzzle>();
                if (!isBase)
                {
                    draggableSign.SetDNDState_InTarget();
                    ValidateOnDrop(draggableSign);
                    draggableSign.parentAfterDrag = sonContainer;
                    draggableSign.ResetDraggablePresetAnchor();
                }
            }

        }
    }

    protected virtual void ValidateOnDrop(DraggableSign draggableSign)
    {

    }
    protected virtual void ValidateOnDrop(DraggableSign_Puzzle draggableSign)
    {

    }
}
