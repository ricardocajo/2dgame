using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 40f;
    private float horizontal;
    private float vertical;
    //private bool is_facing_right = true;
    [SerializeField] private Rigidbody2D rb;
    public Joystick joystick;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Flip_Horizontal();
    }

    private void FixedUpdate()
    {
        if(joystick.joystickVec.y != 0 || joystick.joystickVec.x != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
        }
        else
        {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }

    /*private void Flip_Horizontal()
    {
        if(is_facing_right && horizontal < 0f || !is_facing_right && horizontal > 0f)
        {
            is_facing_right = !is_facing_right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }*/
}
