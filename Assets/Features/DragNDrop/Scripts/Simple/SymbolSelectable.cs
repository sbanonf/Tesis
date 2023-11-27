using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolSelectable : MonoBehaviour
{
    [SerializeField] private Transform currentTransform;
    public Transform CurrentTransform => currentTransform;

    [SerializeField] private Vector3 initialPosition;
    public Vector3 InitialPosition => initialPosition;

    [SerializeField] private Transform targetTransform;
    public Transform TargetTransform => targetTransform;

    [SerializeField] private DND_Symbol_Type _symbolType;
    [SerializeField] private int index;

    [SerializeField] private DND_Symbol_State _symbolState;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Sprite idle, selected;

    private Coroutine currentCoroutine = null;

    public DND_Symbol_Type SymbolType
    {
        get => _symbolType;
        set => _symbolType = value;
    }

    public DND_Symbol_State SymbolState
    {
        get => _symbolState;
        set => _symbolState = value;
    }

    public string UniqueID { get => "" + _symbolType + index; }

    private Vector3 screenSpace;
    private Vector3 offset;

    [SerializeField] private Collider2D collider;
    
    //public void Collider_Deactivate()
    //{
    //    collider.enabled = false;
    //}
    
    //public void Collider_Activate()
    //{
    //    collider.enabled = true;
    //}
    
    public void Initialize()
    {
        currentTransform = transform;
        initialPosition = this.transform.position;
        sprite.sprite = idle;
        collider = GetComponent<Collider2D>();
    }
    
    private void OnMouseDown()
    {
        if (_symbolState == DND_Symbol_State.Placed)
        {
            sprite.sprite = selected;
            SymbolManager._instance.SetSelectable_Active(this);
            screenSpace = SymbolManager._instance.main.WorldToScreenPoint(currentTransform.position);
            offset = currentTransform.position -
                     SymbolManager._instance.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                         screenSpace.z));
            currentTransform.localScale = Vector2.one * SymbolUtils.maxScale;
        }
        else if(_symbolState == DND_Symbol_State.InTarget)
        {
            currentTransform.localScale = Vector2.one * SymbolUtils.maxScale;
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Reset(SymbolManager._instance.GetInitialPos(UniqueID)));
        }
    }

    private void OnMouseDrag()
    {
        if (_symbolState == DND_Symbol_State.Active)
        {
            var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            
            var currentPosition = SymbolManager._instance.main.ScreenToWorldPoint(currentScreenSpace) + offset;

            currentTransform.position = currentPosition;
        }
    }
    
    private void OnMouseUp()
    {
        sprite.sprite = idle;
        if (_symbolState == DND_Symbol_State.Active)
        {
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Checking(OverlapChecking()));
        }
        else if (_symbolState == DND_Symbol_State.InTarget)
        {
            //Reset by coroutine
            currentTransform.localScale = Vector2.one * SymbolUtils.maxScale;
            if (currentCoroutine == null)
                currentCoroutine = StartCoroutine(Reset(SymbolManager._instance.GetInitialPos(UniqueID)));
        }
    }

    public void _Reset()
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(Reset(SymbolManager._instance.GetInitialPos(UniqueID)));
    }

    private Vector3 OverlapChecking()
    {
        Collider2D tempCollider = Physics2D.OverlapCapsule(currentTransform.position, SymbolUtils.collisionCapsule, CapsuleDirection2D.Vertical, 0 , SymbolManager._instance.collisionLayer);
        //Collider2D tempCollider = Physics2D.OverlapCircle(currentTransform.position, SymbolUtils.collisionRadius, SymbolManager._instance.collisionLayer);
        if (tempCollider)
        {
            targetTransform = tempCollider.transform;
            SlotChecker tempSlotChecker = tempCollider.GetComponent<SlotChecker>();
            tempSlotChecker.isTriggered = true;
            //tempSlotChecker.CheckTargetSymbol(_symbolType);
            return tempCollider.transform.position;
        }
        return currentTransform.transform.position;
    }

    private bool OverlapChecking_ResetCheck()
    {
        Collider2D tempCollider = Physics2D.OverlapCapsule(currentTransform.position, SymbolUtils.collisionCapsule, CapsuleDirection2D.Vertical, 0, SymbolManager._instance.collisionLayer);

        //Collider2D tempCollider = Physics2D.OverlapCircle(currentTransform.position, SymbolUtils.collisionRadius, SymbolManager._instance.collisionLayer);
        return tempCollider;
    }

    private void IsFull()
    {
        Collider2D temp = Physics2D.OverlapCircle(currentTransform.position, SymbolUtils.checkEmptyRadius,
            SymbolManager._instance.checkEmptyLayer);

        if (temp != null)
        {
            SymbolSelectable tempSelectable = temp.gameObject.GetComponent<SymbolSelectable>();
            SymbolManager._instance.ResetSelectable(tempSelectable);
        }
    }

    private IEnumerator Checking(Vector3 targetPos)
    {
        //if(SymbolManager._instance.version2)
        IsFull();
        
        yield return Translate(targetPos);
        yield return Scale(true);

        // SoundManager._instance.Run_SFX(SoundManager.SoundType.Selection1);
        
        if (OverlapChecking_ResetCheck())
        {
            _symbolState = DND_Symbol_State.InTarget;
            gameObject.layer = SymbolUtils.placedLayer;
        }
        else
        {
            yield return Translate(SymbolManager._instance.GetInitialPos(UniqueID));
            _symbolState = DND_Symbol_State.Placed;
            gameObject.layer = SymbolUtils.resetLayer;
        }
        
        if(currentCoroutine != null)
            currentCoroutine = null;
    }

    private IEnumerator Reset(Vector3 targetPos)
    {
        yield return Translate(targetPos);
        yield return Scale(true);

        yield return null;
        _symbolState = DND_Symbol_State.Placed;
        gameObject.layer = SymbolUtils.resetLayer;

        currentCoroutine = null;
    }

    private IEnumerator Translate(Vector3 targetPos)
    {
        while ((targetPos - currentTransform.position).sqrMagnitude > Mathf.Epsilon)
        {
            currentTransform.position = Vector3.MoveTowards(currentTransform.position, targetPos, SymbolUtils.moveSpeed * Time.deltaTime);
            yield return null;
        } 
        currentTransform.position = targetPos;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0);
        Gizmos.DrawWireSphere(transform.position, SymbolUtils.collisionRadius);

        Gizmos.color = new Color(0,0,1);
        Gizmos.DrawWireSphere(transform.position,SymbolUtils.checkEmptyRadius);

    }
}
