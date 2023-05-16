using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    [SerializeField] List<Checkpoint> checkPoints = new List<Checkpoint>();

    [SerializeField] int index=0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetIndex(int checkpointIndex)
    {
        index = checkpointIndex;
    }

    public Transform GetCurrentPoint()
    {
        return checkPoints[index].checkpointPosition;
    }
}
