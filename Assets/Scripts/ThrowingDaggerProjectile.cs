using UnityEngine;

public class ThrowingDaggerProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int damage = 5;
    bool hitDetected = false;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3 (dir_x, dir_y);

        if(dir_x <= 0)
        {
            Vector3 scale = transform.localScale;
            Quaternion rotation = transform.localRotation;
            scale.x *= (-1);
            rotation.z *= (-1);
            transform.localScale = scale;
            transform.localRotation = rotation; ;
        }
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1.5f);

            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
                if (hitDetected == true)
                    Destroy(gameObject);
            }
        }
    }
}
