using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr?dko?? poruszania si? gracza
    public Transform cameraTransform; // Transform kamery, która b?dzie pod??a? za graczem
    public Vector3 cameraOffset = new Vector3(0, 5, -10); // Offset kamery wzgl?dem gracza

    void Update()
    {
        // Pobieranie wej?cia z klawiatury
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Ruch gracza na podstawie wej?cia
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Przemieszczanie gracza
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Przemieszczanie kamery za graczem
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + cameraOffset;
            cameraTransform.LookAt(transform.position); // Kamera patrzy na gracza
        }
    }
}