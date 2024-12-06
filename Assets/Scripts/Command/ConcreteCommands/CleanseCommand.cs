using Command.Actions;
using Command.Main;
using UnityEngine;

public class CleanseCommand : UnitCommand
{
    private const float hitChance = 0.2f;
    private bool willHitTarget;
    private int targetUnitPowerBeforeCleanse;  

    public CleanseCommand(CommandData commandData)
    {
        this.commandData = commandData;
        this.willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return Random.Range(0.0f, 1.0f) < hitChance;
    }

    public override void Execute()
    {
        targetUnitPowerBeforeCleanse = targetUnit.CurrentPower;
        GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.CurrentPower = targetUnitPowerBeforeCleanse;
        }
    }
}