using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssignmentLearn
{
    public class MenuController : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(LoadingToInit());
        }
        private IEnumerator LoadingToInit()
        {
            yield return new WaitForSeconds(4f);
            SceneController.Instance.LoadScene("Menu");
        }
    }
}