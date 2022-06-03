using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] float sensivityX;
    [SerializeField] float sensivityY;
    [SerializeField] float angleX;
    [SerializeField] float angleY;
    public void MoveCamera(Vector3 pos)
    {
        transform.Translate(pos * cameraSpeed * Time.deltaTime);
    }

    public void RotateCamera(float mouseX, float mouseY)
    {
        angleX += mouseX * sensivityX * Time.deltaTime;
        angleY += mouseY * sensivityY * Time.deltaTime;
        angleY = Mathf.Clamp(angleY, -90, 90);
        transform.eulerAngles = new Vector3(angleX,angleY,0);
    }

}
