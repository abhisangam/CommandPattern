using Command.Main;
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

    public void Undo()
    {
        if (!RegistryEmpty() && CommandBelongsToActivePlayer()) 
        {
            UnitCommand lastCommand = commandRegistry.Pop() as UnitCommand;
            lastCommand.Undo();
            Debug.Log("Actor PlayerID " + lastCommand.commandData.ActorPlayerID);
            Debug.Log("Actor UnitID " + lastCommand.commandData.ActorUnitID);
            Debug.Log("Target PlayerID " + lastCommand.commandData.TargetPlayerID);
            Debug.Log("Target UnitID " + lastCommand.commandData.TargetUnitID);
        }
    }

    public void RegisterCommand(ICommand command) { commandRegistry.Push(command); }

    private bool RegistryEmpty() => commandRegistry.Count == 0;

    private bool CommandBelongsToActivePlayer()
    {
        return (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
    }
    
}