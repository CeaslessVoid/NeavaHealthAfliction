using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    public class InjuryHediffDef : HediffDef
    {
        public List<BodyPartTagDef> applyTag;

        public List<BodyPartGroupDef> applyGroup;

        public string extensionClass;

        public bool specialInjury;

        public IInjuryEffect GetExtensionClassInstance()
        {
            if (string.IsNullOrEmpty(extensionClass))
                return null;

            Type type = GenTypes.GetTypeInAnyAssembly(extensionClass);
            if (type == null || !typeof(IInjuryEffect).IsAssignableFrom(type))
            {
                ModUtils.Error($"Unable to find or assign {extensionClass} as a valid IModEffect.");
                return null;
            }

            return (IInjuryEffect)Activator.CreateInstance(type);
        }
    }
}
