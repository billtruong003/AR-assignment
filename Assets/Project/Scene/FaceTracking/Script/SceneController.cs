using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace AssignmentLearn
{
    public class SceneController : Singleton<SceneController>
    {

        [SerializeField] private string loadingSceneName = "LoadingScene";
        [SerializeField] private string LoadingBetweenScene = "LoadingBetween";
        [SerializeField] private string menuSceneName = "Menu";
        [SerializeField] private string gamePlayScene = "GamePlay";

        public void LoadScene(string sceneName, bool withLoading = false)
        {
            if (!withLoading)
            {
                SceneManager.LoadScene(sceneName);
                return;
            }
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(LoadingBetweenScene, LoadSceneMode.Additive);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncLoad.isDone);
            yield return new WaitForSeconds(2);
            SceneManager.UnloadSceneAsync(LoadingBetweenScene);
            SceneManager.UnloadSceneAsync(currentScene);
        }

        public void LoadSceneWithLoading(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        protected override void Awake()
        {
            base.Awake();
        }

    }
}