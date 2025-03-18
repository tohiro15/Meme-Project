using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    private IJump _jumpComponent;

    public void Initialize(IJump jumpComponent)
    {
        _jumpComponent = jumpComponent;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);

        if (((1 << other.gameObject.layer) & _groundLayer) != 0)
        {
            Debug.Log("Grounded: true - Collided with: " + other.gameObject.name);
            if (_jumpComponent is JumpComponent jump)
            {
                jump.SetGrounded(true);
            }
        }
        else
        {
            Debug.Log("Collided with object not on Ground layer: " + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with: " + other.gameObject.name);

        if (((1 << other.gameObject.layer) & _groundLayer) != 0)
        {
            Debug.Log("Grounded: false - Exited collision with: " + other.gameObject.name);
            if (_jumpComponent is JumpComponent jump)
            {
                jump.SetGrounded(false);
            }
        }
    }
}