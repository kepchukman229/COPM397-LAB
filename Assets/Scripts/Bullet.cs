using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Bullet : MonoBehaviour
{

    private float timer;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("What is the other. " + other.gameObject.name, other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Destroy(gameObject);
            BulletObjectPool.Instance.ReturnToPool(this);
        }
    }


    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            BulletObjectPool.Instance.ReturnToPool(this);
        }
    }
}
