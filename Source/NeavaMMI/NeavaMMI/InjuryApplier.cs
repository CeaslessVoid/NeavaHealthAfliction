using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NeavaMMI
{
    public class MMI_ConcussionApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            if (dinfo.Amount < 7 || (dinfo.Def == DamageDefOf.Blunt || dinfo.Def == DamageDefOf.Bomb || dinfo.Def == DamageDefOf.Crush))
            {
                return;
            }

            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, BodyPartDefOf.Head);

            if (headPart == null)
            {
                return;
            }

            float severity = dinfo.Amount / 20f;

            HediffDef hediffDef = NeavaMMIDefOf.MMI_Concussion;

            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            hediff.Severity = severity;
            pawn.health.AddHediff(hediff, headPart);

            injuries2.Add(new MMI_HeadacheApply());

            if (severity > 0.2)
                injuries2.Add(new MMI_BlurredVisionApply());

        }

    }

    public class MMI_BlurredVisionApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, BodyPartDefOf.Head);

            if (headPart == null)
            {
                return;
            }

            HediffDef hediffDef = NeavaMMIDefOf.MMI_BlurredVision;

            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            pawn.health.AddHediff(hediff, headPart);
        }
    }

    public class MMI_HeadacheApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, BodyPartDefOf.Head);

            if (headPart == null)
            {
                return;
            }

            HediffDef hediffDef = NeavaMMIDefOf.MMI_Headache;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            pawn.health.AddHediff(hediff, headPart);
        }
    }

    public class MMI_CerebralHemorrhageApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {

            HediffDef hediffDef = NeavaMMIDefOf.MMI_CerebralHemorrhage;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, dinfo.HitPart);
            hediff.Severity = 0.1f;
            pawn.health.AddHediff(hediff, dinfo.HitPart);

            injuries2.Add(new MMI_HeadacheApply());
            injuries2.Add(new MMI_CerebralEdemaApply());
            injuries2.Add(new MMI_DyspneaApply());
        }
    }

    public class MMI_CerebralEdemaApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            HediffDef hediffDef = NeavaMMIDefOf.MMI_CerebralEdema;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, dinfo.HitPart);
            hediff.Severity = 0.1f;
            pawn.health.AddHediff(hediff, dinfo.HitPart);
        }
    }

    public class MMI_SeizuresApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            HediffDef hediffDef = NeavaMMIDefOf.MMI_CerebralEdema;

            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, NeavaMMIDefOf.Brain);

            if (headPart == null)
            {
                return;
            }

            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            pawn.health.AddHediff(hediff, headPart);
        }

    }

    public class MMI_DyspneaApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, NeavaMMIDefOf.Brain);

            if (headPart == null)
            {
                return;
            }

            HediffDef hediffDef = NeavaMMIDefOf.MMI_Dyspnea;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            pawn.health.AddHediff(hediff, headPart);
        }
    }

    public class MMI_TympanicRuptureApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            if (dinfo.Amount < 6)
                return;

            HediffDef hediffDef = NeavaMMIDefOf.MMI_TympanicRupture;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, dinfo.HitPart);
            pawn.health.AddHediff(hediff, dinfo.HitPart);
        }
    }

    public class MMI_OccipitalNeuralgiaApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            if (dinfo.Amount < 6)
                return;

            if (Rand.Chance(0.75f))
                return;

            BodyPartRecord headPart = NeavaMMI_GameComponent.GetBodyPart(pawn, BodyPartDefOf.Head);

            HediffDef hediffDef = NeavaMMIDefOf.MMI_OccipitalNeuralgia;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, headPart);
            pawn.health.AddHediff(hediff, headPart);
        }
    }

    public class MMI_DislocationsApply : IInjuryEffect
    {
        public void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2)
        {
            if (dinfo.Amount < 15 && (dinfo.Def == DamageDefOf.Blunt || dinfo.Def == DamageDefOf.Bomb || dinfo.Def == DamageDefOf.Crush))
                return;

            if (Rand.Chance(0.25f))
                return;

            HediffDef hediffDef = NeavaMMIDefOf.MMI_Dislocations;
            Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn, dinfo.HitPart);
            pawn.health.AddHediff(hediff, dinfo.HitPart);
        }
    }

}
