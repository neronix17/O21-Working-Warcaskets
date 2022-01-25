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
    public class WorkingWarcasketsSettings : ModSettings
    {
        public Dictionary<WorkTags, bool> workTagsSet = new Dictionary<WorkTags, bool>();
        public float workSpeed = 1f;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Collections.Look<WorkTags, bool>(ref workTagsSet, "workTagsSet", LookMode.Value);
            Scribe_Values.Look(ref workSpeed, "workSpeed", 1f);
        }
    }
}
