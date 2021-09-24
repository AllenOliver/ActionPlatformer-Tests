using System;
using UnityEngine;

public class DebugCommandBase
{
    public string CommandId { get; }
    public string CommandDescription { get; }
    public string CommandFormat { get; }

    public DebugCommandBase(string _id, string _description, string _format)
    {
        CommandId = _id;
        CommandDescription = _description;
        CommandFormat = _format;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action commandAction;

    public DebugCommand(string _id, string _description, string _format, Action _command) : base(_id, _description, _format)
    {
        this.commandAction = _command;
    }

    public void Execute() => commandAction?.Invoke();
}

public class DebugCommand<T1> : DebugCommandBase
{
    private Action<T1> commandAction;

    public DebugCommand(string _id, string _description, string _format, Action<T1> _command) : base(_id, _description, _format)
    {
        this.commandAction = _command;
    }

    public void Execute(T1 _val) => commandAction?.Invoke(_val);
}

public class DebugCommand<T1, T2> : DebugCommandBase
{
    private Action<T1, T2> commandAction;

    public DebugCommand(string _id, string _description, string _format, Action<T1, T2> _command) : base(_id, _description, _format)
    {
        this.commandAction = _command;
    }

    public void Execute(T1 _valX, T2 _valY) => commandAction?.Invoke(_valX, _valY);
}