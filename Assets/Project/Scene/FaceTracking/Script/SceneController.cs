using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace AssignmentLearn
{
    public class SceneController : Singleton<SceneController>
    {

        [SerializeField] private string loadingSceneName = "LoadingScene";
        [SerializeField] private string loadingBetweenScene = "LoadingBetween";
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
            yield return SceneManager.LoadSceneAsync(loadingBetweenScene, LoadSceneMode.Additive);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncLoad.isDone);
            BringLoadingSceneToFront();
            SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.UnloadSceneAsync(loadingBetweenScene);
        }
        private void BringLoadingSceneToFront()
        {
            Scene targetScene = SceneManager.GetSceneByName(loadingBetweenScene);
            if (targetScene.IsValid() && targetScene.isLoaded)
            {
                SceneManager.SetActiveScene(targetScene);
            }
        }

        public void LoadSceneWithLoading(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        public void ReloadSceneAsync()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
        private IEnumerator ReloadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(loadingBetweenScene, LoadSceneMode.Additive);

            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
            yield return new WaitUntil(() => asyncUnload.isDone);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncLoad.isDone);

            SceneManager.UnloadSceneAsync(loadingBetweenScene);
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