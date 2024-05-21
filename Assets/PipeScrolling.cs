using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScrolling : MonoBehaviour
{
    [SerializeField] private float deadZone = 6f;
    [SerializeField][Range(0, 5)] private float moveSpeed = 1f;
    [SerializeField] public MapScrolling mapScroll;
    private Vector3 poseUpdate;
    // Update is called once per frame
    void Update()
    {
        ScrollingPipes();
    }
    private void ScrollingPipes()
    {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            mapScroll.ReturnPipeToPool(gameObject);
        }
    }
    public void AssignMapScroll(MapScrolling mapScrollAssign)
    {
        mapScroll = mapScrollAssign;
    }
}
