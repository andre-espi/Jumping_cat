using UnityEngine;

public class Points : MonoBehaviour
{
    private bool pointGiven = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Evitar puntos múltiples
        if (pointGiven) return;

        // Captura el Rigidbody2D raíz del jugador
        Rigidbody2D rb = other.attachedRigidbody;

        // Verificamos que sea el objeto raíz del jugador
        if (rb != null && rb.CompareTag("Player"))
        {
            pointGiven = true;
            
            ScoreManager.Instance.IncreasePoints();
            AudioManager.Instance.PlaySound("Point");
            

            Debug.Log("✔ Punto otorgado una sola vez por salto.");

            gameObject.SetActive(false); // o Destroy(gameObject);
        }
    }
}
