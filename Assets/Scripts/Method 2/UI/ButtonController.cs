using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    public void OnClick()
    {
        if (ReplayManager2.instance.currentState == ReplayManager2.State.Idle)
        {
            ReplayManager2.instance.StartRecord();
            buttonText.text = "PlayBack";
        }
        else if(ReplayManager2.instance.currentState == ReplayManager2.State.Recording)
        {
            ReplayManager2.instance.PlayBack();
            buttonText.text = "Record";
        }
    }
}
