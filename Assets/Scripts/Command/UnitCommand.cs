using Command.Player;
using System.Collections;
using UnityEngine;

public struct CommandData
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    public CommandData(int actorUnitID, int targetUnitID, int actorPlayerID, int targetPlayerID)
    {
        ActorUnitID = actorUnitID;
        TargetUnitID = targetUnitID;
        ActorPlayerID = actorPlayerID;
        TargetPlayerID = targetPlayerID;

    }
}

public abstract class UnitCommand : ICommand
{
    public CommandData commandData;

    protected UnitController actorUnit;
    protected UnitController targetUnit;

    public abstract void Execute();

    public abstract void Undo();

    public abstract bool WillHitTarget();

    public void SetActorUnit(UnitController actorUnit)
    {
        this.actorUnit = actorUnit;
    }

    public void SetTargetUnit(UnitController targetUnit)
    {
        this.targetUnit = targetUnit;
    }
}