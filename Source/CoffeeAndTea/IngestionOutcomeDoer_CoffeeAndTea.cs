using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CoffeeAndTea;

public class IngestionOutcomeDoer_CoffeeAndTea : IngestionOutcomeDoer
{
    public readonly float severity = -1f;
    public bool divideByBodySize;

    public HediffDef hediffDefAdd;

    public HediffDef hediffDefRemove;
    public ChemicalDef toleranceChemical;

    protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
    {
        var hediff = HediffMaker.MakeHediff(hediffDefAdd, pawn);
        var num = !(severity > 0f) ? hediffDefAdd.initialSeverity : severity;
        if (divideByBodySize)
        {
            num /= pawn.BodySize;
        }

        AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize_NewTemp(pawn, toleranceChemical, ref num, true);
        hediff.Severity = num;
        pawn.health.AddHediff(hediff);
        var hediff2 = pawn.health.hediffSet.hediffs.Find(h => h.def == hediffDefRemove);
        if (hediff2 != null)
        {
            pawn.health.RemoveHediff(hediff2);
        }
    }

    public override IEnumerable<StatDrawEntry> SpecialDisplayStats(ThingDef parentDef)
    {
        foreach (var item in hediffDefAdd.SpecialDisplayStats(StatRequest.ForEmpty()))
        {
            yield return item;
        }
    }
}