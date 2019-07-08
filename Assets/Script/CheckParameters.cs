using UnityEngine;
using UnityEngine.UI;

public class CheckParameters : MonoBehaviour
{
    Button confirmButton;
    public GameObject[] parametersToCheck;
    void Start()
    {
        confirmButton = this.GetComponent<Button>();
        confirmButton.interactable = false;
    }

    void Update()
    {
        CheckParametersInPlayerPrefs();
    }

    private void CheckParametersInPlayerPrefs()
    {
        int parametersChecked = 0;
        foreach(GameObject obj in parametersToCheck)
        {
            if (PlayerPrefs.HasKey(obj.name))
            {
                parametersChecked++;
            }
            else break;
        }

        if(parametersChecked == parametersToCheck.Length)
        {
            ChangeButtonInteractable(true);
        } else { 
            ChangeButtonInteractable(false);
        }
    }

    private void ChangeButtonInteractable(bool state)
    {
        confirmButton.interactable = state;
    }
}
