using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] UIViewer uiViewer;
  
    
 
    public void Initialize()
    {
      
        uiViewer.Initialize();
    }

    public void UpdatePlayerScore(int num)
    {
        uiViewer.UpdatePlayerScoreText(num);
    }

    public void UpdateOpponentScore(int num)
    {
        uiViewer.UpdateOpponentScoreText(num);
    }

    public void UpdateTimer(float num)
    {
        uiViewer.UpdateTimerText(num);
    }
}
