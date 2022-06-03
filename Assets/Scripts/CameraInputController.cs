using UnityEngine;

public class CameraInputController : MonoBehaviour
{
    [SerializeField] CameraMovement cameraMovement;
    void Update()
    {
        CheckCamera();
    }

    void CheckCamera()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
            cameraMovement.MoveCamera(movement);
        }

        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            cameraMovement.RotateCamera(mouseX,mouseY);
        }
    }

}
