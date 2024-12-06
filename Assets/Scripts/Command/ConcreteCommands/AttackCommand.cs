using Command.Actions;
using Command.Main;

public class AttackCommand: UnitCommand
{
    private bool willHitTarget;
    public AttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        this.willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return true;
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();

            targetUnit.RestoreHealth(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}