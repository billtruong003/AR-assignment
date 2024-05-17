using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace AssignmentLearn
{
    public class SceneController : Singleton<SceneController>
    {

        [SerializeField] private string loadingSceneName = "LoadingScene";
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
            yield return SceneManager.LoadSceneAsync(loadingSceneName, LoadSceneMode.Additive);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            SceneManager.UnloadSceneAsync(loadingSceneName);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

    }
}