using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LEVEL_TYPES
{
    PLATFORMING,
    MENU,
    SHOP
}

public class GameModeBase : MonoBehaviour
{
    public static GameModeBase instance;
    public GameObject PlayerStart;
    public GameObject Player;
    public LEVEL_TYPES LevelType;
    public bool IsPaused;

    private Transform currentCheckpoint;

    private void Start()
    {
        instance = this;
        currentCheckpoint = PlayerStart.transform;
        SpawnPlayer();
    }

    public void PauseGame() => IsPaused = true;

    public void UnpauseGame() => IsPaused = false;

    public virtual void SpawnPlayer()
    {
        if (LevelType != LEVEL_TYPES.PLATFORMING)
            return;
        else Instantiate(Player, currentCheckpoint.position, Quaternion.identity);
    }

    public virtual void SetCheckPoint(Transform _transform) => currentCheckpoint = _transform;
}