using Command.Actions;
using Command.Main;

public class AttackStanceCommand: UnitCommand
{
    private bool willHitTarget;
    public AttackStanceCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.CurrentPower = (int)(targetUnit.CurrentPower * (1.0f / 1.2f));
        }
    }
}