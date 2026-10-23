using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 弾丸のダメージを与えます
/// </summary>
public class BulletDamage : MonoBehaviour
{
    #region Config
    [SerializeField] private int hitDamage = 20; // 当たった時のダメージ
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(collision);
            DeleteBullet();
        }

        Debug.Log("弾丸が当たりました: 名前" + collision.gameObject.name);
        DeleteBullet();
    }
    
    /// @brief ダメージを与える処理を行います
    private void DealDamage(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(hitDamage);
        }
    }


    /// @brief 弾丸を削除します
    private void DeleteBullet()
    {
        Destroy(gameObject);
    }
}
