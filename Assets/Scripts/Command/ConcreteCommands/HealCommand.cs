using Command.Actions;
using Command.Main;
using Command.Player;

public class HealCommand : UnitCommand
{
    private bool willHitTarget;
    public HealCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.TakeDamage(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}