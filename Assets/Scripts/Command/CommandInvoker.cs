using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CommandInvoker
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();


    public void ProcessCommand(ICommand connamdToProcess)
    {
        ExecuteCommand(connamdToProcess);
        RegisterCommand(connamdToProcess);
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }

    public void RegisterCommand(ICommand command) { commandRegistry.Push(command); }
}