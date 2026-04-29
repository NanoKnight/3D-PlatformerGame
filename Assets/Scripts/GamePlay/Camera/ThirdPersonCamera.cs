using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransfrom;
    [SerializeField] private Transform OrientationTransform;
    [SerializeField] private Transform VisualTransform;
    [SerializeField] private float RotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ViewDirection =
      PlayerTransfrom.position - new Vector3(transform.position.x,PlayerTransfrom.position.y,transform.position.z);
        OrientationTransform.forward = ViewDirection.normalized;

        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        Vector3 InputDirection = 
        OrientationTransform.forward * VerticalInput + OrientationTransform.right * HorizontalInput;

        if(InputDirection != Vector3.zero)
        {
         VisualTransform.forward =
          Vector3.Slerp(VisualTransform.forward,InputDirection.normalized,Time.deltaTime* RotationSpeed);
        }
   
    }
}
