using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    private bool touched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetCheckpoint();
        }
    }

    private void SetCheckpoint()
    {
        if (!touched)
        {
            touched = true;
            GameModeBase.instance.SetCheckPoint(transform);
        }
    }
}