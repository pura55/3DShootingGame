using UnityEngine;
using System.Collections;

/// <summary>
/// バレットムーブメント
/// 
/// 弾丸の移動処理を行います
/// </summary>
public class BulletMovement : MonoBehaviour
{

    # region Config
    [SerializeField] private float lifeTime = 10.0f; // 弾丸の生存時間
    [SerializeField] private float speed = 10f; // 進行速度
    # endregion

    #region State
    private Vector3 moveDirection; // 進行方向
    #endregion

    public Vector3 MoveDirection
    {
        set {  moveDirection = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitLifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDirection == null)
        {
            return;
        }

        MoveBullet();
    }

    /// @brief生存時間が終了するまで待機します
    private IEnumerator WaitLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }

    /// @brief 弾丸を移動させます
    private void MoveBullet()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
