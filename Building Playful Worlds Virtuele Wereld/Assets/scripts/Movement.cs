using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;

    Vector3 velocity;
    bool isGrounder;

    public GameObject fontein;
    public bool colli;

    public bool used = false;
    // Update is called once per frame
    void Update()
    {
        isGrounder = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounder && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounder == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Start()
    {
        colli = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hi)
    {
        if (hi.gameObject == fontein.gameObject && colli == false)
        {
            colli = true;
            Debug.Log("test");
            Switch t = fontein.GetComponent<Switch>();
            t.SwitchScript();

            // Force toevoegen aan de player, om interactie met het object duidelijker te maken. 

            float pushPower = 4.15f;
            Vector3 pushDir = transform.position - hi.transform.position;
            controller.Move(pushDir * pushPower);
        }
        else
        {
            colli = false;
        }
    }
}

