using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class CheckInput : GrabbableEvents
    {
        public TestTubeHolder Ac;

        public GameObject h1, h2;
        public override void OnTrigger(float triggerValue)
        {
            if (triggerValue > 0)
            {
                doWork(triggerValue);
            }
            else
            {
                doRest();
            }

            base.OnTrigger(triggerValue);
        }

        void doWork(float triggerValue)
        {
            Ac.isPos = true;
            h1.transform.localEulerAngles = new Vector3(0, -4, 0);
            h2.transform.localEulerAngles = new Vector3(0, 4, 0);
        }

        void doRest()
        {
            Ac.isPos = false;
            h1.transform.localEulerAngles = new Vector3(0, -10, 0);
            h2.transform.localEulerAngles = new Vector3(0, 10, 0);
        }
    }
}


