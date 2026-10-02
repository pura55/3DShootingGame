using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// シューター
/// 
/// 発射処理全般を担当します
/// </summary>
public class Shooter : MonoBehaviour
{
    #region Config
    [SerializeField] private int rate;
    [SerializeField] private GameObject havingWeapon; // 持っている武器
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    /// @brief 発射処理を行います
    private void Shoot()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            Debug.Log("発射中");
        }
    }
}
