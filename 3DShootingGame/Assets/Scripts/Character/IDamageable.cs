using UnityEngine;

/// <summary>
/// ダメージを受けるのに必要な機能を搭載します
/// </summary>
public interface IDamageable
{
    /// @brief ダメージを受ける処理を行います
    /// @param ダメージ量
    void TakeDamage(int amount);
}
