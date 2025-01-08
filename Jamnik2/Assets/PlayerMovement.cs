using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr?dko?? ruchu postaci
    public float laneWidth = 3f; // Odleg?o?? mi?dzy torami (dla lewo-prawo)

    private Vector3 targetPosition; // Pozycja, do której posta? ma si? poruszy?

    void Start()
    {
        // Ustaw pozycj? startow? postaci
        targetPosition = transform.position;
    }

    void Update()
    {
        // Obs?uga wej?cia gracza
        if (Input.GetKeyDown(KeyCode.W)) // Przód
        {
            targetPosition += Vector3.forward * laneWidth;
        }
        if (Input.GetKeyDown(KeyCode.S)) // Ty?
        {
            targetPosition += Vector3.back * laneWidth;
        }
        if (Input.GetKeyDown(KeyCode.A)) // Lewo
        {
            targetPosition += Vector3.left * laneWidth;
        }
        if (Input.GetKeyDown(KeyCode.D)) // Prawo
        {
            targetPosition += Vector3.right * laneWidth;
        }

        // Ruch postaci w stron? docelowej pozycji
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
