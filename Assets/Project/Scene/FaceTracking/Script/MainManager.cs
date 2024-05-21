using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
namespace AssignmentLearn
{
    public class MainManager : Singleton<MainManager>
    {
        public float x, y;
        [Header("Scoring")]
        [SerializeField] public int score;
        private Vector3 poseTrackingBall;
        private TrackingPose trackingPose;
        public bool GameOver;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            GameOver = false;
            score = 0;
            UpdateScore();
            Debug.Log("InitMainManager");
        }

        public void GameDone(Vector3 dronePose)
        {
            Debug.Log("Game Over! Final Score: " + score);
            GameOver = true;
            VFXManager.Instance.activeFlashSmoke(dronePose);
            UIManager.Instance.GameOver();
        }

        public void AddScore()
        {
            score += 1;
            UpdateScore();
        }

        private void UpdateScore()
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateScore(score);
            }
        }

        public void SetBackGameOver()
        {
            GameOver = false;
        }
    }
}