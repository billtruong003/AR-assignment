using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace AssignmentLearn
{
    public class LoadingText : MonoBehaviour
    {
        [SerializeField] private string dot = "";
        [SerializeField] private string loadingText = "LOADING";
        [SerializeField] private TextMeshProUGUI tmpText;
        private int count;

        private void Start()
        {
            StartCoroutine(loadingAnim());
        }

        private IEnumerator loadingAnim()
        {
            while (true)
            {
                count += 1;
                UpdateDot();
                tmpText.text = loadingText + dot;
                yield return new WaitForSeconds(1);
                if (count == 3)
                    count = 0;

            }
        }

        private void UpdateDot()
        {
            switch (count)
            {
                case 1:
                    dot = ".";
                    break;
                case 2:
                    dot = "..";
                    break;
                case 3:
                    dot = "...";
                    break;
            }
        }
    }
}