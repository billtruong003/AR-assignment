using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssignmentLearn
{
    public class TrackingPose : Singleton<TrackingPose>
    {
        [SerializeField] private Transform trackingBall;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override void Awake()
        {
            base.Awake();
        }

    }
}