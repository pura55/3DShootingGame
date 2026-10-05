using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーコントローラー
/// 
/// プレイヤーを操作する処理を担当します
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Config
    [SerializeField] private float walkVelocity = 1.0f; // 歩きの速度
    [SerializeField] private float runVelocity = 2.0f; // 走りの速度
    [SerializeField] private Animator myAnimator; // このコンポーネントのアニメーター
    [SerializeField] private CharacterController characterController; // キャラクターコントローラー
    #endregion

    #region State
    private Vector3 moveDirection = Vector3.zero; // 進行方向
    private Vector2 moveInput = Vector2.zero; // 入力する移動値
    private bool isRun = false; // 走知っているかどうかのフラグ
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤー操作
        ControlPlayer();

        // 処理反映
        ApplyChanges();
    }

    /// @brief 移動処理を行います
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// @brief 走りの判定を行います
    public void OnRun(InputAction.CallbackContext context)
    {
        isRun = context.ReadValueAsButton();
    }

    /// @brief プレイヤーの操作処理を行います
    private void ControlPlayer()
    {
        // 入力がないときは停止
        moveDirection = Vector3.zero;

        // Move入力を反映
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
    }

    /// @brief 処理を反映します
    private void ApplyChanges()
    {
        // 速度を反映
        float velocity;

        if (isRun)
        {
            velocity = runVelocity;
        }
        else
        {
            velocity = walkVelocity;
        }

        moveDirection *= velocity;

        // アニメーションにスピードを反映
        float speed = new Vector3(moveDirection.x, Vector3.zero.y, moveDirection.z).magnitude; // ジャンプはしないのでy軸は固定
        myAnimator.SetFloat("Speed", speed);

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
