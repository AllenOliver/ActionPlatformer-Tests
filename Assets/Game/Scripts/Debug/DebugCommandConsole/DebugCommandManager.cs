using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugCommandManager : MonoBehaviour

{
    [Header("Player Cache")]

    #region Player Component Cache

    public GameObject _player;

    #endregion Player Component Cache

    #region Create Commands and Command List

    public static DebugCommand SHOW_HELP;
    public static DebugCommand HIDE_HELP;
    public static DebugCommand RELOAD_SCENE;
    public static DebugCommand TOGGLE_FPS;
    public static DebugCommand<string> OPEN_SCENE;

    public List<object> commandList;

    #endregion Create Commands and Command List

    public static DebugCommandManager instance;

    private void Awake()
    {
        instance = this;
        if (_player)
        {
        }
        else
        {
            Debug.LogError("Ria is not set in the DebugManager! Ria Console commands will not work!");
        }

        #region Create Commands

        OPEN_SCENE = new DebugCommand<string>("open_scene", "Opens a Scene. (Must be in build settings!)", "open_scene <scene name>", (_sceneName) => { OpenScene_Command(_sceneName); });
        RELOAD_SCENE = new DebugCommand("reload_scene", "Reloads the currently running Scene", "reload_scene", () => { ReloadScene_Command(); });
        TOGGLE_FPS = new DebugCommand("toggle_fps", "Displays a window with the current FPS", "toggle_fps", () => { ToggleFPS_Command(); });
        SHOW_HELP = new DebugCommand("show_help", "Opens the command list", "show_help", () => { Help_Command(); });
        HIDE_HELP = new DebugCommand("hide_help", "Closes the command list", "hide_help", () => { HelpOff_Command(); });

        // ==== Add new commands below ====

        #endregion Create Commands

        commandList = new List<object>
        {
            // == Built in Commands that are useful for any game c: ==
            OPEN_SCENE,
            RELOAD_SCENE,
            SHOW_HELP,
            HIDE_HELP,
            TOGGLE_FPS,

            // ==== Add new commands below ====
        };
    }

    #region ====== Built in Commands ======

    private void OpenScene_Command(string _name) => SceneManager.LoadScene(_name);

    private void ToggleFPS_Command() => DebugConsoleController.instance._showFPS = !DebugConsoleController.instance._showFPS;

    private void ReloadScene_Command() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    private void Help_Command() => DebugConsoleController.instance._showHelp = true;

    private void HelpOff_Command() => DebugConsoleController.instance._showHelp = false;

    #endregion ====== Built in Commands ======

    //====== ADD NEW COMMANDS HERE ======
}