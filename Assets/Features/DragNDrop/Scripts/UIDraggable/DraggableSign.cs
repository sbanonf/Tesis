using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DraggableSign : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [Header("Background Image")]
    [SerializeField] Image img;
    [SerializeField] Sprite idle, active;

    [Header("Character Image")]
    [SerializeField] Image charImg;

    [HideInInspector] public Transform parentAfterDrag;
    public Transform initialParentAfterDrag;

    Coroutine currentCoroutine = null;
    [SerializeField] Transform currentTransform;
    [SerializeField] private DND_Symbol_Type _symbolType;
    public DND_Symbol_Type SymbolType => _symbolType;

    [SerializeField] private DND_Symbol_State _symbolState;
    public DND_Symbol_State SymbolState => _symbolState;


    public void InitializeDraggableOption(DND_Symbol_Type _symbol, Sprite _sprite)
    {
        _symbolType = _symbol;
        charImg.sprite = _sprite;
    }

    private void Start()
    {
        img.sprite = idle;
        currentTransform = transform;
    }

    public void SetDNDState_InTarget()
    {
        _symbolState = DND_Symbol_State.InTarget;
    }

    public void SetDNDState_Reset()
    {
        _symbolState = DND_Symbol_State.Placed;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_symbolState == DND_Symbol_State.Placed)
        {
            img.sprite = active;
            transform.localScale = Vector2.one * SymbolUtils.maxScale;
        }
        else if (_symbolState == DND_Symbol_State.InTarget)
        {
            currentTransform.localScale = Vector2.one * SymbolUtils.maxScale;
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Reset());
            transform.SetParent(initialParentAfterDrag);
            img.raycastTarget = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_symbolState == DND_Symbol_State.Placed)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            img.raycastTarget = false;
            _symbolState = DND_Symbol_State.Active;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_symbolState == DND_Symbol_State.Active)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        img.sprite = idle;
        if (_symbolState == DND_Symbol_State.InTarget)
        {
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Checking());
            transform.SetParent(parentAfterDrag);
            img.raycastTarget = true;
        }

        //Debug.Log(eventData.ToString());
        GameObject dropped = eventData.pointerEnter;
        if (dropped == null || dropped.GetComponent<ItemSlot>() == null)
        {
            //Debug.Log(eventData.ToString());
            currentTransform.localScale = Vector2.one * SymbolUtils.maxScale;
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Reset());
            transform.SetParent(initialParentAfterDrag);
            img.raycastTarget = true;
        }
    }

    public void ResetDraggable()
    {
        _symbolState = DND_Symbol_State.Placed;
        //if (currentCoroutine == null)
        //    currentCoroutine = StartCoroutine(Reset());
        transform.SetParent(initialParentAfterDrag);
        img.raycastTarget = true;
    }

    private IEnumerator Reset()
    {
        _symbolState = DND_Symbol_State.Placed;
        yield return Scale(true);

        yield return null;

        currentCoroutine = null;
    }

    IEnumerator Checking()
    {
        //yield return Translate(targetPos);
        yield return Scale(true);

        if (currentCoroutine != null)
            currentCoroutine = null;
    }

    private IEnumerator Scale(bool fromMaxToMin)
    {
        float scale = fromMaxToMin ? SymbolUtils.maxScale : SymbolUtils.minScale;
        currentTransform.localScale = Vector3.one * scale;

        float timeStep = Time.deltaTime * SymbolUtils.timeStep;

        if (fromMaxToMin)
        {
            while (scale > SymbolUtils.minScale)
            {
                currentTransform.localScale = Vector3.one * scale;
                scale -= timeStep;
                yield return null;
            }

            scale = SymbolUtils.minScale;
        }
        else
        {
            while (scale < SymbolUtils.maxScale)
            {
                currentTransform.localScale = Vector3.one * scale;
                scale += timeStep;
                yield return null;
            }

            scale = SymbolUtils.maxScale;
        }

        currentTransform.localScale = Vector3.one * scale;
    }

}
