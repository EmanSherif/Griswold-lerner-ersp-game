using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rbEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy.velocity = transform.right* -1 * speed;

        Destroy(gameObject, 0.2f);
    }


}
