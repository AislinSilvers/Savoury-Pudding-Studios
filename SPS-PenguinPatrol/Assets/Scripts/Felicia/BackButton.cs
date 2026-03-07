using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject panelToHide;    //to assign ANY panel in inspectr

    public void HidePanel()  //liretally hide assigned panel
    {
        if (panelToHide != null)
            panelToHide.SetActive(false);   //if theres a panel active(true) - hide it
    }
}