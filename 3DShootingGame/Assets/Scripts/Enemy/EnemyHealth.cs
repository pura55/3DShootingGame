using UnityEngine;

/// <summary>
/// “G‚Ì‘Ì—ÍƒNƒ‰ƒX
/// </summary>
public class EnemyHealth : CharacterHealth
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

        // ‘Ì—Í‚ª0‚Ìê‡íœ‚µ‚Ü‚·
        if(myHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
