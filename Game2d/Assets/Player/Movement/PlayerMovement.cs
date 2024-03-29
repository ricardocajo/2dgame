using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private static PlayerMovement _instance;

    public static PlayerMovement Instance { get { return _instance; } }

    private float speed = 3.5f;
    private float knockback_time = 0.4f;
    private Vector2 knockback_difference;
    private bool knocked_back = false;
    private float horizontal;
    private float vertical;
    private bool is_facing_right = true;
    private Rigidbody2D rb;
    private Animator animator;
    public Joystick joystick;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            //Check DontDestroyOnLoad if want to persist across scenes
            //DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update() {
        //TODO This is always 0 ????
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if(knocked_back) {
            rb.AddForce(knockback_difference, ForceMode2D.Force);
        }
        if(joystick.joystickVec.y != 0 || joystick.joystickVec.x != 0) {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
            Flip_Horizontal();
        }
        else {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        animator.SetFloat("Speed",Mathf.Max(Mathf.Abs(joystick.joystickVec.y), Mathf.Abs(joystick.joystickVec.x))); 
    }

    public void DoKnockback() {
        Vector2 difference = transform.position - GameEvents.Instance.GetEnemyInContactPosition();
        knockback_difference = difference.normalized * GameEvents.Instance.GetEnemyKnockBackForce();
        knocked_back = true;
        animator.SetBool("TakeHit", true);
        StartCoroutine(Unknockback());
     }

    private IEnumerator Unknockback() {
        yield return new WaitForSeconds(knockback_time);
        knocked_back = false;
        animator.SetBool("TakeHit", false);
    }

    private void Flip_Horizontal() {
        // joystick.joystickVec.x  by horizontal
        if(is_facing_right && joystick.joystickVec.x < 0f || !is_facing_right && joystick.joystickVec.x > 0f) {
            is_facing_right = !is_facing_right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
