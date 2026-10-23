using UnityEngine;

/// <summary>
/// キャラクターの体力クラス
/// 
/// 体力の基本機能を記載します
/// </summary>
public abstract class CharacterHealth : MonoBehaviour, IDamageable
{
    #region Config
    [SerializeField] protected int myHealth; // 体力
    #endregion

    /// @brief ダメージを受ける処理を行います
    public virtual void TakeDamage(int amount)
    {
        myHealth -= amount;

        // 0未満にならないよう補正
        if(myHealth < 0 )
        {
            myHealth = 0;
        }

        Debug.Log("現在の体力：" +  myHealth);
    }
}
