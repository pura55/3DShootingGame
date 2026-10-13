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

    [SerializeField] private GameObject havingWeapon; // 持っている武器
    #endregion

    #region State
    private bool isShooting = false; // 発射フラグ
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShooting)
        {
            return;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("発射中");
        }
    }

    /// @brief 発射の入力を行います
    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }
}
