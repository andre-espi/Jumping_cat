using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed *  Time.deltaTime);
        if (transform.position.x < -11) Destroy(gameObject);
    }
}
