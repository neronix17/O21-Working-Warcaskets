using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace WorkingWarcaskets
{
    public static class WorkingWarcasketsUtils
    {
        public static WorkTags GetDisabledTags(Dictionary<WorkTags, bool> workTagsSet)
        {
            WorkTags disabledWorkTags = WorkTags.None;
            foreach (KeyValuePair<WorkTags, bool> workTagsPair in workTagsSet)
            {
                if (!workTagsPair.Value)
                {
                    disabledWorkTags |= workTagsPair.Key;
                }
            }

            return disabledWorkTags;
        }

        public static void SetWarcasketTags(WorkTags disabled)
        {
            DefDatabase<TraitDef>.GetNamed("VFEP_WarcasketTrait").disabledWorkTags = disabled;
        }

        public static void SetWarcasketWorkSpeed(float multiplier)
        {
            if(multiplier != 1f)
            {
                DefDatabase<VFEPirates.WarcasketDef>.GetNamed("VFEP_Warcasket_Bodysuit").SetStatBaseValue(StatDefOf.WorkSpeedGlobal, multiplier);
            }
        }
    }
}
