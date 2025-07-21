using System.Collections.Generic;
using HarmonyLib;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace CoffeeAndTea;

public class CoffeeAndTeaCore : Mod
{
    private static bool policiesAdded;
    private static string currentVersion;

    public CoffeeAndTeaCore(ModContentPack content) : base(content)
    {
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "SyrCoffeeAndTeaCategory".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        if (policiesAdded)
        {
            GUI.color = Color.green;
            listingStandard.Label("SyrCoffeeAndTeaPoliciesAdded".Translate());
            GUI.color = Color.white;
            listingStandard.Gap(24f);
        }

        if (listingStandard.ButtonText("SyrCoffeeAndTeaAddPolicies".Translate(),
                "SyrCoffeeAndTeaAddPoliciesTooltip".Translate()))
        {
            SoundDefOf.Designate_PlanRemove.PlayOneShotOnCamera();
            addNewPolicies();
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("SyrCoffeeAndTeaCurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    private static void addNewPolicies()
    {
        if (Current.ProgramState != ProgramState.Playing)
        {
            return;
        }

        foreach (var allPolicy in Current.Game.drugPolicyDatabase.AllPolicies)
        {
            var value = Traverse.Create(allPolicy).Field("entriesInt").GetValue<List<DrugPolicyEntry>>();
            if (value.Find(i => i.drug == CoffeeAndTeaDefOf.SyrCoffee) == null)
            {
                value.Add(new DrugPolicyEntry
                {
                    drug = CoffeeAndTeaDefOf.SyrCoffee,
                    allowedForJoy = true,
                    allowedForAddiction = true
                });
            }

            if (value.Find(i => i.drug == CoffeeAndTeaDefOf.SyrTea) == null)
            {
                value.Add(new DrugPolicyEntry
                {
                    drug = CoffeeAndTeaDefOf.SyrTea,
                    allowedForJoy = true,
                    allowedForAddiction = true
                });
            }

            if (value.Find(i => i.drug == CoffeeAndTeaDefOf.SyrHotChocolate) == null)
            {
                value.Add(new DrugPolicyEntry
                {
                    drug = CoffeeAndTeaDefOf.SyrHotChocolate,
                    allowedForJoy = true
                });
            }

            value.SortBy(e => e.drug.GetCompProperties<CompProperties_Drug>().listOrder);
            Traverse.Create(allPolicy).Field("entriesInt").SetValue(value);
            policiesAdded = true;
        }
    }
}