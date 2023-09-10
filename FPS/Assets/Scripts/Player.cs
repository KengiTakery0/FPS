using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 playerVelocity;
    [SerializeField] Animator a;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 inputVector)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = inputVector.x;
        moveDirection.z = inputVector.y;
        rb.velocity = moveDirection*_speed*Time.deltaTime;
        a.SetBool("isWalking",rb.velocity.z>Mathf.Epsilon);
        
    }


   
}
