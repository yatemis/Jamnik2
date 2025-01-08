using UnityEngine;

public class BarrierTrigger : MonoBehaviour
{
    public EnemyMovement[] enemies; // Tablica wrog�w
    public Transform player; // Referencja do gracza

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdza, czy gracz przekroczy? trigger
        {
            foreach (EnemyMovement enemy in enemies)
            {
                enemy.Activate(); // Aktywuje ruch wrog�w
            }
        }
    }
}

