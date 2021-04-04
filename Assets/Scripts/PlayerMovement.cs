using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 30f;
    [SerializeField] float moveSpeed;
    public Animator animator;
    public CharacterController characterController;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        if (characterController == null)
            return;
        
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X");

        animator.SetFloat("Speed", vertical);

        if (Input.GetMouseButton(1) == false)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * rotateSpeed);
        }

        characterController.SimpleMove(transform.forward * Time.deltaTime * moveSpeed * vertical);
        characterController.SimpleMove(transform.right * Time.deltaTime * moveSpeed * horizontal);
        animator.SetFloat("Strafe", horizontal);
    }
}
