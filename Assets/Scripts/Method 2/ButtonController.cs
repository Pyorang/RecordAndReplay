using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    public void OnClick()
    {
        if (ReplayManager.s_instance.CurrentState == ReplayManager.State.Idle)
        {
            ReplayManager.s_instance.StartRecord();
            buttonText.text = "PlayBack";
        }
        else if(ReplayManager.s_instance.CurrentState == ReplayManager.State.Recording)
        {
            ReplayManager.s_instance.PlayBack();
            buttonText.text = "Record";
        }
    }
}
