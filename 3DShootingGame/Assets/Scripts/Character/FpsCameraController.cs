using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// FPSカメラコントローラー
/// 
/// FPS視点のカメラをコントロールします
/// </summary>
public class FpsCameraController : MonoBehaviour
{
    #region Config
    [SerializeField] protected float cameraSensitivity = 0.2f; // カメラ感度
    [SerializeField] protected float viewingAngle = 60f; // 縦方向の視野角
    [SerializeField] protected Transform characterHead; // 操作するキャラの頭
    #endregion

    #region State
    protected Vector3 lookDirection = Vector3.zero; // 視点の移動方向
    protected Vector2 lookInput = Vector2.zero; // 入力する視点の移動値
    protected Camera fpsCamera; // fps視点のカメラ
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpsCamera = GetComponent<PlayerInput>().camera;
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamera();
        // 入力がない場合は処理を抜ける
        if (lookDirection == Vector3.zero)
        {
            return;
        }

        ApplyChange();
    }

    /// @brief 視点移動を行います
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    /// @brief カメラの操作処理を行います
    protected void ControlCamera()
    {
        //lookDirection = Vector3.zero;

        lookDirection.x -= lookInput.y * cameraSensitivity;
        lookDirection.y += lookInput.x * cameraSensitivity;
    }

    /// @brief 処理を反映します
    protected void ApplyChange()
    {
        // 視野角の固定

        // 頭の視点方向
        Vector3 headDirection = new Vector3(lookDirection.x, 0, 0);

        // 上下の視野角を固定
        headDirection.x = Mathf.Clamp(headDirection.x, -viewingAngle, viewingAngle);

        characterHead.localRotation = Quaternion.Euler(headDirection);

        // 体の視点方向
        Vector3 BodyDirection = new Vector3(0, lookDirection.y, 0);

        transform.rotation = Quaternion.Euler(BodyDirection);
    }
}
