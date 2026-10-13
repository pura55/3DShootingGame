using UnityEngine;
using System.Collections;

/// <summary>
/// シュートバレット
/// 
/// 弾丸を発射する処理を行います
/// </summary>
public class ShootBullet : MonoBehaviour
{
    #region Config
    [SerializeField] private GameObject bullet; // 弾丸のオブジェクト
    [SerializeField] private float shootRate = 0.2f; // 発射レート
    [SerializeField] Shooter shooter; // シューター
    [SerializeField] Vector3 shootingPosition = new Vector3(1f,1f, 1f); // 発射する座標
    [SerializeField] private float shootPositionSize = 0.01f; // 発射場所のサイズ
    #endregion

    #region State 
    private bool isShot = false; // 発射したかどうかのフラグ
    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 発射許可が下りていない場合処理を抜ける
        if(!shooter.IsShooting)
        {
            return;
        }

        if(!isShot)
        {
            GenerateBullet();
            Debug.Log("発射を規制します");
            isShot = true;
        }
        else
        {
            StartCoroutine(WaitNextShooot());
        }

    }

    /// @brief 次の発射処理を待機します
    private IEnumerator WaitNextShooot()
    {
        yield return new WaitForSeconds(shootRate);

        Debug.Log("発射が解除されました");

        isShot = false;
    }

    /// @ 弾丸を生成します
    private void GenerateBullet()
    {
        GameObject generatedBullet = Instantiate(bullet, transform.position + shootingPosition, transform.rotation);

        //generatedBullet.Target() = bullet;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(shootingPosition, shootPositionSize);
    }
}
