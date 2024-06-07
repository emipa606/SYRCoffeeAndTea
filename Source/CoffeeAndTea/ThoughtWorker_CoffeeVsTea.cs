using RimWorld;
using Verse;

namespace CoffeeAndTea;

public class ThoughtWorker_CoffeeVsTea : ThoughtWorker
{
    protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
    {
        if (!p.RaceProps.Humanlike)
        {
            return ThoughtState.Inactive;
        }

        if (!other.RaceProps.Humanlike)
        {
            return ThoughtState.Inactive;
        }

        if (!RelationsUtility.PawnsKnowEachOther(p, other))
        {
            return ThoughtState.Inactive;
        }

        var num = Rand.ValueSeeded(p.thingIDNumber ^ 0x7D);
        var num2 = Rand.ValueSeeded(other.thingIDNumber ^ 0x7D);
        if (num < 0.2f || num2 < 0.2f)
        {
            return ThoughtState.Inactive;
        }

        switch (num)
        {
            case >= 0.6f when num2 < 0.6f:
            case < 0.6f when num2 >= 0.6f:
                return ThoughtState.ActiveAtStage(0);
            case < 0.6f when num2 < 0.6f:
                return ThoughtState.ActiveAtStage(1);
            case >= 0.6f when num2 >= 0.6f:
                return ThoughtState.ActiveAtStage(2);
            default:
                return ThoughtState.Inactive;
        }
    }
}