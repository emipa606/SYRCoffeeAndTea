using RimWorld;
using Verse;

namespace CoffeeAndTea;

public class ThoughtWorker_Coffee : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        var firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(CoffeeAndTeaDefOf.SyrCoffeeHigh);
        if (firstHediffOfDef?.def.stages == null)
        {
            return ThoughtState.Inactive;
        }

        return Rand.ValueSeeded(p.thingIDNumber ^ 0x7D) >= 0.6f
            ? ThoughtState.ActiveAtStage(1)
            : ThoughtState.ActiveDefault;
    }
}