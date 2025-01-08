using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr?dko?? poruszania si? gracza
    public float jumpForce = 5f; // Si?a skoku
    public Transform cameraTransform; // Transform kamery, która b?dzie pod??a? za graczem
    public Vector3 cameraOffset = new Vector3(0, 5, -10); // Offset kamery wzgl?dem gracza

    private Rigidbody rb; // Referencja do Rigidbody
    private bool isGrounded = true; // Flaga sprawdzaj?ca, czy gracz jest na ziemi

    void Start()
    {
        // Pobranie komponentu Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Pobieranie wej?cia z klawiatury
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Ruch gracza na podstawie wej?cia
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Przemieszczanie gracza
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Skok
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Przemieszczanie kamery za graczem
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + cameraOffset;
            cameraTransform.LookAt(transform.position); // Kamera patrzy na gracza
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzanie, czy gracz dotyka ziemi
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
