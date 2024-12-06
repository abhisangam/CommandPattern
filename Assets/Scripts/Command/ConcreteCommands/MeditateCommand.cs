using Command.Actions;
using Command.Main;

public class MeditateCommand: UnitCommand
{
    private bool willHitTarget;
    public MeditateCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            var healthIncreased = targetUnit.CurrentMaxHealth - (int)(targetUnit.CurrentMaxHealth * (1.0f / 1.2f));
            targetUnit.CurrentMaxHealth -= healthIncreased;
            targetUnit.TakeDamage(healthIncreased);
        }
    }
}