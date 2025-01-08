using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Gracz, do którego przeciwnik ma i??
    public float speed = 3f; // Pr?dko?? przeciwnika
    private bool shouldMove = false; // Czy przeciwnik ma si? porusza?

    void Update()
    {
        if (shouldMove && player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void Activate()
    {
        shouldMove = true; // W??cza ruch
    }
}
