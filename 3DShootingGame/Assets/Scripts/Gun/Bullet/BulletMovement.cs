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
    # endregion

    #region State
    private Transform target; // 弾丸が向かうトランスフォーム
    #endregion

    public Transform Target
    {
        set {  target = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        MoveBullet();
    }

    /// @biref 生存時間を開始します
    public void StartLifeTime()
    {
        StartCoroutine(WaitLifeTime());
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

    }
}
