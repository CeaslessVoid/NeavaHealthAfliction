using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    public class MMI_CerebralHemorrhage : Hediff_Injury
    {
        private const float GrowthRatePerTick = 0.1f;

        public override void Tick()
        {
            base.Tick();

            if (GenTicks.IsTickInterval(600))
            {
                if (!this.IsTended())
                {
                    Severity += GrowthRatePerTick;
                    if (Severity >= 1)
                    {
                        Severity = 1;

                    }
                }
                else
                {
                    Severity -= GrowthRatePerTick;
                    if (Severity <= 0)
                    {
                        pawn.health.RemoveHediff(this);
                    }
                }

                if (Severity >= 0.4)
                {
                    if (Rand.Chance(0.5f))
                    {
                        IInjuryEffect seizures = new MMI_SeizuresApply();

                        seizures.ApplyEffect(null, new DamageInfo(), pawn, null, ref NeavaMMI_GameComponent.dummyIInjuryEffect);

                    }
                }

            }
        }
    }

    public class MMI_CerebralEdema : Hediff_Injury
    {
        private const float GrowthRatePerTick = 0.05f;

        public override void Tick()
        {
            base.Tick();

            if (GenTicks.IsTickInterval(600))
            {
                if (!this.IsTended())
                {
                    Severity += GrowthRatePerTick;
                    if (Severity >= 1)
                    {
                        Severity = 1;

                    }
                }
                else
                {
                    Severity -= GrowthRatePerTick;
                    if (Severity <= 0)
                    {
                        pawn.health.RemoveHediff(this);
                    }
                }
            }
        }

        public override void PostRemoved()
        {
            base.PostRemoved();

            Hediff dyspnea = pawn.health.hediffSet.hediffs
                .FirstOrDefault(h => h.def == NeavaMMIDefOf.MMI_Dyspnea);

            if (dyspnea != null)
            {
                pawn.health.RemoveHediff(dyspnea);
            }

        }
    }
}
