using UnityEngine;

/// <summary>
/// プレイヤーの体力クラス
/// </summary>
public class PlayerHealth : CharacterHealth
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }
}
