using System.Collections;
using System.Collections.Generic;
using AssignmentLearn;
using UnityEngine;
using UnityEngine.UIElements;

public class MapScrolling : MonoBehaviour
{
    [SerializeField] private Transform aRCam;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector3 poseUpdate;
    [SerializeField] private float yLim = 2;
    [SerializeField] private float xLim = 6;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private Stack<GameObject> pipePool = new Stack<GameObject>();
    [SerializeField] private int poolSize = 10;
    [SerializeField] private PipeScrolling pipeScrolling;
    [SerializeField] private MapConfig mapConfig;
    [SerializeField] private PipeType mapDecide;
    // Start is called before the first frame update
    void Start()
    {
        InitMap();
        InitPipes();
        StartCoroutine(SpawnPipes());
    }

    // Update is called once per frame
    void Update()
    {
        fixPose();
    }

    private void fixPose()
    {
        float posZ = aRCam.position.z;
        poseUpdate = new Vector3(0, 0, posZ + 5);
        transform.position = poseUpdate;
        Debug.Log("Update Pose");
    }

    private void InitMap()
    {
        GameObject pipe = mapConfig.GetPrefabPipe(mapDecide);
        pipePrefab = pipe;
    }
    private IEnumerator SpawnPipes()
    {
        while (!MainManager.Instance.GameOver)
        {
            yield return new WaitForSeconds(2);

            float spawnX = -6f;
            float spawnY = Random.Range(-yLim, yLim);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

            GameObject pipe = GetPipeFromPool();
            if (pipe != null)
            {
                pipe.transform.localPosition = spawnPosition;
                pipe.SetActive(true);
            }

            Debug.Log($"Spawn Pipes At: ({spawnX}, {spawnY})");
        }
    }

    private void InitPipes()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject pipes = Instantiate(pipePrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            pipeScrolling = pipes.GetComponent<PipeScrolling>();
            pipeScrolling.AssignMapScroll(this);

            pipes.SetActive(false);
            pipePool.Push(pipes);
        }
    }

    private GameObject GetPipeFromPool()
    {
        if (pipePool.Count > 0)
        {
            return pipePool.Pop();
        }
        else
        {
            Debug.LogWarning("Pipe pool is empty!");
            return null;
        }
    }

    public void ReturnPipeToPool(GameObject pipe)
    {
        pipe.SetActive(false);
        pipePool.Push(pipe);
    }
}
