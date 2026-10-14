using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ’eŠÛ‚Ìƒ_ƒ[ƒW‚ğ—^‚¦‚Ü‚·
/// </summary>
public class BulletDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("’eŠÛ‚ª“–‚½‚è‚Ü‚µ‚½: –¼‘O" + collision.gameObject.name);
        DeleteBullet();
    }

    /// @brief ’eŠÛ‚ğíœ‚µ‚Ü‚·
    private void DeleteBullet()
    {
        Destroy(gameObject);
    }
}
