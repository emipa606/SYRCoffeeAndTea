using RimWorld;
using Verse;

namespace CoffeeAndTea;

public class ThoughtWorker_Tea : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        var firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(CoffeeAndTeaDefOf.SyrTeaHigh);
        if (firstHediffOfDef?.def.stages == null)
        {
            return ThoughtState.Inactive;
        }

        var num = Rand.ValueSeeded(p.thingIDNumber ^ 0x7D);
        if (num >= 0.2 && num < 0.6f)
        {
            return ThoughtState.ActiveAtStage(1);
        }

        return ThoughtState.ActiveDefault;
    }
}