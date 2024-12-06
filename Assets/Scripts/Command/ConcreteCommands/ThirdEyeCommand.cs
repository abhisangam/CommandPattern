using Command.Actions;
using Command.Main;

public class ThirdEyeCommand : UnitCommand
{
    private bool willHitTarget;
    public ThirdEyeCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, this.willHitTarget);
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            int healthConverted = targetUnit.CurrentHealth - (int)(targetUnit.CurrentHealth * (1.0f / 0.75f));
            targetUnit.RestoreHealth(healthConverted);
            targetUnit.CurrentPower -= healthConverted;
        }
    }
}