using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AssignmentLearn
{
    public class DroneController : MonoBehaviour
    {
        [SerializeField] private float x;
        [SerializeField] private float y;


        [SerializeField] private MainManager mainManager;
        [SerializeField] private bool fixedRotation = true;
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            FixRotate();
        }

        private void Init()
        {
            StartCoroutine(GetMainManager());

        }

        private IEnumerator GetMainManager()
        {
            yield return new WaitUntil(() => MainManager.Instance != null);
            mainManager = MainManager.Instance;
        }

        private void FixRotate()
        {
            if (!fixedRotation)
                return;
            Vector3 drone = transform.position;
            transform.position.Set(drone.x, drone.y, 0);
            transform.rotation = Quaternion.identity;
        }
    }
}