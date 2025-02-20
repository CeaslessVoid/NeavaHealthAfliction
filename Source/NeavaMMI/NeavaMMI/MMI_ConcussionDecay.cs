using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    public class MMI_ConcussionDecay : HediffWithComps
    {
        private const float DecayRatePerTick = 0.05f;

        public override void Tick()
        {
            base.Tick();

            if (GenTicks.IsTickInterval(60))
            {
                if (Severity > 0)
                {
                    Severity -= DecayRatePerTick;
                    if (Severity <= 0)
                    {
                        pawn.health.RemoveHediff(this);
                    }
                }
            }
        }
    }
}
