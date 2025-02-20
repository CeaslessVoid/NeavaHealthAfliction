using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Main.HarmonyInstance.Patch(
                original: AccessTools.Method(typeof(DamageWorker_AddInjury), "ApplyDamageToPart"),
                postfix: new HarmonyMethod(typeof(HarmonyPatches), nameof(TakeDamagePatch))
            );
        }

        public static void TakeDamagePatch(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result)
        {

            ModUtils.Msg(dinfo.HitPart.def.bleedRate);

            if (!pawn.RaceProps.Humanlike)
            {
                return;
            }

            HashSet<InjuryHediffDef> injuries = new HashSet<InjuryHediffDef>();

            if (dinfo.HitPart.def.tags != null)
            {
                foreach (var tag in dinfo.HitPart.def.tags)
                {
                    if (NeavaMMI_GameComponent.bodyPartTags.TryGetValue(tag, out var hediffList))
                    {
                        foreach (var hediff in hediffList)
                        {
                            injuries.Add(hediff);
                        }
                    }
                }
            }

            if (dinfo.HitPart.groups != null)
            {
                foreach (var group in dinfo.HitPart.groups)
                {
                    if (NeavaMMI_GameComponent.bodyPartGroup.TryGetValue(group, out var hediffList))
                    {
                        foreach (var hediff in hediffList)
                        {
                            injuries.Add(hediff);
                        }
                    }
                }
            }

            HashSet<IInjuryEffect> injuries2 = new HashSet<IInjuryEffect>();

            foreach (var injuryDef in injuries)
            {
                var extension = injuryDef.GetExtensionClassInstance();
                if (extension != null)
                {
                    extension.ApplyEffect(__instance, dinfo, pawn, result, ref injuries2);
                }
            }

            foreach (IInjuryEffect extrainjury in injuries2)
            {
                extrainjury.ApplyEffect(__instance, dinfo, pawn, result, ref injuries2);
            }

        }
    }
}
