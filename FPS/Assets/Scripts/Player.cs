using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Animator a;

    Vector3 playerVelocity;
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
        
        
    }


   
}
