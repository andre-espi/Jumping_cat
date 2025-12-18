using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }  //Creamos una instancia estatica para poder llamar a sus metodos desde cualquier script

    public Rigidbody2D rb;
    public float jumpForce = 7f; // fuerza del salto

    public Animator animator;
    public bool enemyCollision = false, grounded;
    float startY;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        grounded = transform.position.y == startY;
    }
    public void SetAnimation(string name)
    {
        animator.Play(name);
        if (name == "PlayerJump")
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            grounded = false;
            AudioManager.Instance.PlaySound("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Enemy")
        {
            enemyCollision = true;
            GetComponent<BoxCollider2D>().enabled = false;
            AudioManager.Instance.PlaySound("Die");
            AudioManager.Instance.StopMusic();
        }
        
        else if (collider.tag == "Points")
        {

            ScoreManager.Instance.IncreasePoints();
            AudioManager.Instance.PlaySound("Point");
        }
        
    }


}
