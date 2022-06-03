using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    Rect rect;
    bool isDrawimg; 

    void OnGUI()
    {
        if (isDrawimg)
        {  
            GUI.Box(rect, GUIContent.none);
        }   

    }

    public void DrawSelectionIndicator(Vector3 pos1, Vector3 pos2)
    {
        rect = CreateRect(pos1, pos2);
        isDrawimg = true;
    }

    public void UpdateSelectionIndicator(Vector3 pos1, Vector3 pos2)
    {
        UpdateRect(pos1, pos2);

    }

    public void ClearSelectionIndicator()
    {
        isDrawimg = false;
    }

    Rect CreateRect(Vector3 pos1, Vector3 pos2)
    {
        pos1.y = Screen.height - pos1.y;
        pos2.y = Screen.height - pos2.y;

        Vector3 topLeft = Vector3.Min(pos1, pos2);
        Vector3 bottomRight = Vector3.Max(pos1, pos2);

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    void UpdateRect(Vector3 pos1, Vector3 pos2)
    {
        pos1.y = Screen.height - pos1.y;
        pos2.y = Screen.height - pos2.y;

        Vector3 topLeft = Vector3.Min(pos1, pos2);
        Vector3 bottomRight = Vector3.Max(pos1, pos2);
        
        rect.xMin = topLeft.x;
        rect.yMin = topLeft.y;
        rect.xMax = bottomRight.x;
        rect.yMax = bottomRight.y;

    }

}
