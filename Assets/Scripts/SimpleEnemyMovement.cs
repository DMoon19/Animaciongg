using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidad de movimiento
    private Transform targetPlayer; // El jugador al que va a seguir
    private Rigidbody rb; // Referencia al Rigidbody

    public int cantidad = 10; // Daño infligido

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody

        // Encuentra todos los jugadores con el tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {
            int randomIndex = Random.Range(0, players.Length);
            targetPlayer = players[randomIndex].transform;
            Debug.Log("Jugador seleccionado para seguir: " + targetPlayer.name);
        }
        else
        {
            Debug.LogWarning("No se encontraron jugadores con el tag 'Player'.");
        }
    }

    void FixedUpdate() // Usa FixedUpdate para trabajar con la física
    {
        if (targetPlayer != null)
        {
            Vector3 targetPosition = targetPlayer.position;
            MoveTowardsPlayer(targetPosition);
        }
    }

    void MoveTowardsPlayer(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;

        // Usa MovePosition para mover al Rigidbody
        rb.MovePosition(newPosition);

        Debug.Log("Posición del enemigo: " + rb.position);
    }

    // Detecta la colisión con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthAndDamage health = other.GetComponent<HealthAndDamage>();
            if (health != null)
            {
                health.RestarVida(cantidad);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthAndDamage health = other.GetComponent<HealthAndDamage>();
            if (health != null)
            {
                health.RestarVida(cantidad);
            }
        }
    }
}
