using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugConsoleController : MonoBehaviour
{
    public static DebugConsoleController instance;

    #region Fields

    [Header("FPS Counter")]
    public bool _showFPS;

    public Vector2 FPSWindowPosition = new Vector2(1072f, 48f);

    public Color ConsoleColor = Color.black;

    //Hidden from inspector
    [HideInInspector]
    public float AverageFrameRate;

    [HideInInspector]
    public bool _showConsole;

    [HideInInspector]
    public bool _showHelp;

    private string _consoleInput;
    private Vector2 _scrollView;
    private float _guiY = 0;

    #endregion Fields

    #region Unity Messages

    private void Start() => Initialize();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ToggleConsole();

        if (_showConsole)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                HandleConsoleInput();
                _consoleInput = "";
            }
        }

        if (_showFPS) AverageFrameRate = (1.0f / Time.deltaTime);
    }

    private void OnGUI()
    {
        #region FPS Counter

        if (_showFPS)
        {
            GUI.Box(new Rect(FPSWindowPosition.x, _guiY + FPSWindowPosition.y, 160f, 64f), "");
            GUI.Label(new Rect((FPSWindowPosition.x + 8), (_guiY + FPSWindowPosition.y + 2f), 128f, 32f), $"Approx. Frame Rate");
            GUI.Label(new Rect((FPSWindowPosition.x + 8), (_guiY + FPSWindowPosition.y + 24f), 128f, 32f), $"FPS: { AverageFrameRate.ToString("n2") }");
        }

        #endregion FPS Counter

        if (!_showConsole) return;

        #region Help Window

        if (_showHelp)
        {
            GUI.Box(new Rect(0f, 0f, Screen.width, 128f), "");

            Rect _viewport = new Rect(0f, 0f, Screen.width - 36f, 16f * DebugCommandManager.instance.commandList.Count);

            #region Help scroll view; Rendering

            _scrollView = GUI.BeginScrollView(new Rect(0f, 0f + 8f, Screen.width, 96f), _scrollView, _viewport);

            for (int i = 0; i < DebugCommandManager.instance.commandList.Count; i++)
            {
                DebugCommandBase _command = DebugCommandManager.instance.commandList[i] as DebugCommandBase;
                string _commandLabel = $" - {_command.CommandFormat} :   {_command.CommandDescription}";
                Rect _labelRect = new Rect(8f, 16f * i, _viewport.width - 128f, 24f);
                Rect _labelSpace = new Rect(8f, 16f * i, _viewport.width - 128f, 8f);
                GUI.Label(_labelRect, _commandLabel);
                GUI.Label(_labelSpace, " - ");
            }

            GUI.EndScrollView();

            #endregion Help scroll view; Rendering

            _guiY = 128f;
        }

        #endregion Help Window

        _consoleInput = GUI.TextField(new Rect(8f, _guiY + 4f, Screen.width - 48f, 24f), _consoleInput);
        GUI.Label(new Rect(16f, _guiY + 32f, Screen.width - 64f, 32f), "DEBUG MENU");

        GUI.backgroundColor = ConsoleColor;
    }

    #endregion Unity Messages

    #region Utilities

    private void Initialize()
    {
        instance = this;
    }

    public void ToggleConsole()
    {
        if (_showConsole)
        {
            _showConsole = false;
            _showHelp = false;
            _guiY = 0f;
        }
        else
            _showConsole = true;
    }

    public void HandleConsoleInput()
    {
        string[] properties = _consoleInput.ToLower().Split(' ');
        var _commands = DebugCommandManager.instance.commandList;

        for (int i = 0; i < _commands.Count; i++)
        {
            DebugCommandBase commandBase = _commands[i] as DebugCommandBase;
            if (_consoleInput.Contains(commandBase.CommandId))
            {
                if (_commands[i] as DebugCommand != null)
                {
                    (_commands[i] as DebugCommand).Execute();
                }
                else if (_commands[i] as DebugCommand<int> != null)
                {
                    (_commands[i] as DebugCommand<int>).Execute(int.Parse(properties[1]));
                }
                else if (_commands[i] as DebugCommand<int, int> != null)
                {
                    (_commands[i] as DebugCommand<int, int>).Execute(int.Parse(properties[1]), int.Parse(properties[2]));
                }
            }
        }
    }

    #endregion Utilities
}