using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssignmentLearn
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Dictionary<Scenes, string> nameScenes = new()
            {
                { Scenes.PLAY, "GamePlay" },
                { Scenes.SHOP, "GamePlay" },
            };
        public void ChangeScenePlay()
        {
            string sceneName = GetSceneName(Scenes.PLAY);
            SceneController.Instance.LoadSceneWithLoading(sceneName);
        }
        public void ChangeSceneShop()
        {
            string sceneName = GetSceneName(Scenes.SHOP);
            SceneController.Instance.LoadSceneWithLoading(sceneName);
        }
        public void QuitGame()
        {
            SceneController.Instance.QuitGame();
        }

        private enum Scenes{
            PLAY,
            SHOP,
        }
        private string GetSceneName(Scenes scene)
        {
            if (nameScenes.TryGetValue(scene, out string sceneName))
            {
                return sceneName;
            }
            else
            {
                Debug.LogWarning($"Scene name for {scene} not found.");
                return null;
            }
        }
    }
}