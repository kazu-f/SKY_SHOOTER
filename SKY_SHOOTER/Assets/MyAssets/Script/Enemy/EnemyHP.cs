using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int m_HP = 3;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void DeathEnemy()
    {
        Destroy(gameObject);
    }

    bool IsDead()
    {
        return m_HP <= 0;
    }
}
