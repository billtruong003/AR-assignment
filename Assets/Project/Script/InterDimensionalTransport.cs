using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterDimensionalTransport : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Transform device;
    [SerializeField] private bool wasInFront;
    [SerializeField] private bool isInOtherWorld = false;
    private bool hasCollided = false;
    void Start()
    {
        SetMat(false);
    }

    private void SetMat(bool fullRender)
    {
        int stencilValue = fullRender ? (int)CompareFunction.NotEqual : (int)CompareFunction.Equal;
        SimpDebugger("stencilValue", stencilValue);
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", stencilValue);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
            return;

        // Chỉ thay đổi trạng thái nếu chưa có va chạm trước đó
        if (!hasCollided)
        {
            isInOtherWorld = !isInOtherWorld;
            SetMat(isInOtherWorld);
            SimpDebugger("isInOtherWorld", isInOtherWorld);
            hasCollided = true; // Đặt cờ khi có va chạm
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
            return;

        hasCollided = false; // Đặt lại cờ khi rời khỏi va chạm
    }

    void OnDestroy()
    {
        SetMat(true);
    }

    void SimpDebugger<T>(string name, T var)
    {
        Debug.Log($"{name}: {var}");
    }

}
