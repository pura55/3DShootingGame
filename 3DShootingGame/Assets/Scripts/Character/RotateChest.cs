using UnityEngine;

/// <summary>
/// ローテートチェスト
/// 
/// 胴体の回転処理を行います
/// </summary>
public class RotateChest : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform; // カメラ
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = cameraTransform.rotation;
    }
}
