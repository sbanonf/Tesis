using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio
    public Transform endPoint; // Punto final
    public float moveSpeed = 3f;

    private Vector3 nextPosition;
    private bool movingToEndPoint = true;
    private Transform playerTransform;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        nextPosition = endPoint.position;
    }

    void Update()
    {
        if (movingToEndPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            if (transform.position == endPoint.position)
            {
                movingToEndPoint = false;
                nextPosition = startPoint.position;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            if (transform.position == startPoint.position)
            {
                movingToEndPoint = true;
                nextPosition = endPoint.position;
            }
        }

        if (isPlayerOnPlatform && playerTransform != null)
        {
            playerTransform.position += transform.position - transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            playerTransform = collision.transform;
            playerTransform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            playerTransform.parent = null;
            playerTransform = null;
        }
    }
}
