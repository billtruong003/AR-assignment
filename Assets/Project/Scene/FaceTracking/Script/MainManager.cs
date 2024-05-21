using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace AssignmentLearn
{
    public class MainManager : Singleton<MainManager>
    {
        public float x, y;
        private Vector3 poseTrackingBall;
        private TrackingPose trackingPose;
        private bool GameOver;
        void Start()
        {
            GameOver = false;
        }

        void Update()
        {
        }

        private void GameDone()
        {
            GameOver = true;
        }

        protected override void Awake()
        {
            base.Awake();
        }
        // #TODO: REMOVE IN CASE
        public void processPosing()
        {
            if (TrackingPose.Instance == null)
                return;
            poseTrackingBall = TrackingPose.Instance.GetPoseTrackingBall();
            this.x = poseTrackingBall.x;
            this.y = poseTrackingBall.y;
        }
    }
}