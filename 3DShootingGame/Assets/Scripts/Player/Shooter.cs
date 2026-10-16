using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// シューター
/// 
/// キャラクターの発射の入力処理を担当します
/// </summary>
public class Shooter : MonoBehaviour
{
    #region Config

    [SerializeField] private GameObject havingWeapon; // 持っている武器
    #endregion

    #region State
    private bool isShooting = false; // 発射フラグ
    #endregion

    // 発射フラグを取得します
    public bool IsShooting
    {
        get {  return isShooting; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShooting && havingWeapon == null)
        {
            return;
        }

        //Debug.Log("発射中");
    }

    /// @brief 発射の入力を行います
    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }
}
