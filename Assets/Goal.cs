using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(UI_SceneLoader))]
public class Goal : MonoBehaviour
{
    [SerializeField] Animator baseAnimator;
    [SerializeField] Animator flagAnimator;

    bool isPlayerCollided = false;

   // [SerializeField] UI_SceneLoader sceneLoader;

    Coroutine currentCoroutine=null;

    private void Awake()
    {
        flagAnimator.enabled = false;
       // sceneLoader = GetComponent<UI_SceneLoader>();
    }
    
    public void FlapFlag()
    {
        flagAnimator.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isPlayerCollided)
            {
                baseAnimator.SetTrigger("Flap");
                GameManager.Instance.isGameFinished = true;
                //collision.GetComponent<PlayerController>().FinishLevel();
                if (currentCoroutine == null)
                    currentCoroutine = StartCoroutine(DelaySceneLoading(3));
                isPlayerCollided = true;
            }
        }
    }

    IEnumerator DelaySceneLoading(float delay)
    {
        yield return new WaitForSeconds(delay);
        //sceneLoader.SceneLoad_ToTitleScene();
        currentCoroutine = null;
    }
}
