using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectile;

    public float projectileSpeed = 10f;
    public float health = 150f;

    void Update()
    {
        Vector3 startPosition = transform.position + new Vector3(0,-1f,0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
    }
	
    void OnTriggerEnter2D(Collider2D collider)
    {
       Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if(health <= 0)
            {
                Destroy(gameObject);
            }
           
        }
    }



}
