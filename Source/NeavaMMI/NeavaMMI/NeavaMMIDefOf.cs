using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    [DefOf]
    public static class NeavaMMIDefOf
    {
        public static InjuryHediffDef MMI_Concussion;

        public static InjuryHediffDef MMI_CerebralHemorrhage;

        public static InjuryHediffDef MMI_CerebralEdema;

        public static InjuryHediffDef MMI_TympanicRupture;

        public static InjuryHediffDef MMI_OccipitalNeuralgia;

        public static InjuryHediffDef MMI_Dislocations;

        public static HediffDef MMI_BlurredVision;

        public static HediffDef MMI_Headache;

        public static HediffDef MMI_Seizures;

        public static HediffDef MMI_Dyspnea;

        public static BodyPartDef Brain; // Why tf isn't this in base BodyPartDefOf???
    }
}
