using UnityEngine;

public class SelectionInputController : MonoBehaviour
{
    [SerializeField] SelectedUnits selectedUnits;
    [SerializeField] LayerMask unitMask;
    [SerializeField] UnitContainer unitContainer;
    [SerializeField] SelectionIndicator selectionIndicator;

    Vector3 mousePosition1;
    Vector3 mousePosition2;
    bool isGameActive;

    void Update()
    {
        if (isGameActive)
        {
            CheckSelectedUnit();
        }       
    }

    void CheckSelectedUnit()
    {

        if (Input.GetMouseButtonDown(1))
        {
            mousePosition1 = Input.mousePosition;
           
            Ray ray = Camera.main.ScreenPointToRay(mousePosition1);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, unitMask))
            {

                if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
                {
                    selectedUnits.RemoveSelectedUnits();
                }
                if (!selectedUnits.isInSelectedUnitsList(hit.collider.gameObject.GetComponent<Unit>()))
                {
                    selectedUnits.AddSelectedUnit(hit.collider.gameObject.GetComponent<Unit>());
                
                }

            }
            else if (Physics.Raycast(ray, out hit))
            {
                if (!hit.collider.CompareTag("Target"))
                {
                    if ( !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
                    {
                        selectedUnits.RemoveSelectedUnits();                       
                    }                                  
                }
            }
            selectionIndicator.DrawSelectionIndicator(mousePosition1, mousePosition1);
        }

        if (Input.GetMouseButton(1))
        {
            mousePosition2 = Input.mousePosition;
            
            if (mousePosition1 == mousePosition2) return;

            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                selectedUnits.RemoveSelectedUnits();
            }

            for (int i = 0; i < unitContainer.Count; i++)
            {
                    Bounds viewportBounds = GetViewportBounds(Camera.main, mousePosition1, mousePosition2);

                    if (viewportBounds.Contains(Camera.main.WorldToViewportPoint(unitContainer.GetUnit(i).transform.position)))
                    {

                        if (!selectedUnits.isInSelectedUnitsList(unitContainer.GetUnit(i)))
                        {
                            selectedUnits.AddSelectedUnit(unitContainer.GetUnit(i));
                        }
                    }               
            }
            selectionIndicator.UpdateSelectionIndicator(mousePosition1, mousePosition2);
        }

        if (Input.GetMouseButtonUp(1))
        {
            selectionIndicator.ClearSelectionIndicator();
        }

    }
    Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2)
    {
        Vector3 v1 = camera.ScreenToViewportPoint(screenPosition1);
        Vector3 v2 = camera.ScreenToViewportPoint(screenPosition2);
        Vector3 min = Vector3.Min(v1, v2);
        Vector3 max = Vector3.Max(v1, v2);
        min.z = camera.nearClipPlane;
        max.z = camera.farClipPlane;

        Bounds bounds = new Bounds();
        bounds.SetMinMax(min, max);
        return bounds;
    }

    public void Initialize()
    {
        isGameActive = true;
    }
}
