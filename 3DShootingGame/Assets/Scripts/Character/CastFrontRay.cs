using UnityEngine;

/// <summary>
/// キャストフロントレイ
/// 
/// 前面のレイを飛ばす処理を行います
/// </summary>
public class CastFrontRay : MonoBehaviour
{
    #region Config
    [SerializeField] private float maxDistance = 10f; // レイの長さ
    #endregion

    #region State
    private RaycastHit hit; // 飛ばしたレイを入れる変数
    private Vector3 hitPosition; // レイが当たった座標
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /// @brief レイを飛ばします
    public Vector3 CastRay()
    {
        Vector3 origin = transform.position; // 発射地点
        Vector3 direction = transform.forward; // 飛ばす方向

        Debug.Log("飛ばす方向" + direction);

        // Raycastを実行
        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            // ヒットしたオブジェクトの名前を出力
            Debug.Log("レイオブジェクト: " + hit.collider.gameObject.name);

            // 当たった座標を取得
            hitPosition = hit.point;

            return hitPosition;
        }

        // レイが当たっていない場合
        // 最大距離の差分を加えた座標を返す
        Vector3 distance = direction * maxDistance;
        hitPosition = origin + distance;

        return hitPosition;
    }
}
