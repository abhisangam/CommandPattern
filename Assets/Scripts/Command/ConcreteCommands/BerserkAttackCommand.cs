using Command.Actions;
using Command.Main;
using UnityEngine;

public class BerserkAttackCommand : UnitCommand
{
    private const float hitChance = 0.66f;
    private bool willHitTarget;
    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        this.willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return Random.Range(0f, 1f) < hitChance;
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();
            targetUnit.RestoreHealth(actorUnit.CurrentPower * 2);
        }
        else
        {
            if (!actorUnit.IsAlive())
                actorUnit.Revive();
            actorUnit.RestoreHealth(actorUnit.CurrentPower * 2);
        }
    }
}