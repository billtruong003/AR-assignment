using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace AssignmentLearn
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject gameOver;
        [SerializeField] private TextMeshProUGUI displayScore;
        [SerializeField] private Image DroneAnim;
        private MainManager mainManager;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            UpdateScore(0);
            StartCoroutine(GetMainManager());
        }

        private IEnumerator GetMainManager()
        {
            yield return new WaitUntil(() => MainManager.Instance != null);
            mainManager = MainManager.Instance;
        }
        public void UpdateScore(int score)
        {
            displayScore.text = "Score: " + score.ToString();
        }
        public void ChangeSceneMenu()
        {
            string sceneName = "Menu";
            mainManager.SetBackGameOver();
            SceneController.Instance.LoadSceneWithLoading(sceneName);
        }
        public void ReplayScene()
        {
            mainManager.SetBackGameOver();
            SceneController.Instance.ReloadSceneAsync();
        }
        public void GameOver()
        {
            StartCoroutine(Cor_GameOver());
        }
        public IEnumerator Cor_GameOver()
        {
            yield return new WaitForSeconds(2);
            gameOver.SetActive(true);
        }
    }
}