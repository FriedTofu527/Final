using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public static float speedG = 4;
    private bool shift = false;
    private bool ctrl = false;
    public static float x;
    public static float z;
    public static float y;
    private float horizontalInput;
    private float verticalInput;
    private float jumpCount;
    private Vector3 jump;
    Rigidbody body;
    public GameObject Sphere;
    public AudioSource soundPlayer;
    public AudioClip crash;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        jump = new Vector3(0, 60, 0);
        soundPlayer = GetComponent<AudioSource>();
        jumpCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;
        y = transform.position.y;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 relativeForward = verticalInput * forward;
        Vector3 relativeRight = horizontalInput * right;
        Vector3 relativeMovement = relativeForward + relativeRight;

        shift = Input.GetKey(KeyCode.LeftShift);
        ctrl = Input.GetKey(KeyCode.LeftControl);

        if (shift)
        {
            speedG = 6;
        }

        else if (ctrl)
        {
            speedG = 2;
        }

        else
        {
            speedG = 4;
        }

        if (Physics.Raycast(transform.position, -Vector3.up, 0.5f) && jumpCount == 0)
        {
            jumpCount = 2;
        }

        transform.eulerAngles = new Vector3(0, moveCamera.yaw, 0);
        transform.Translate(speedG * relativeMovement * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            body.AddForce(jump, ForceMode.Impulse);
            soundPlayer.PlayOneShot(jumpSound, 1);
            jumpCount--;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Sphere, transform.position, Quaternion.Euler(moveCamera.pitch, moveCamera.yaw / 2, 0));
            soundPlayer.PlayOneShot(crash, 1);
        }
    }
}
