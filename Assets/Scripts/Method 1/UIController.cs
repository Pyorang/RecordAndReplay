using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button RecordButton;
    [SerializeField] private TextMeshProUGUI ButtonText;

    public void OnClickButton()
    {
        if (ReplayManager.instance.currentState == ReplayManager.State.Idle)
        {
            ReplayManager.instance.StartRecording();
            ButtonText.text = "PlayBack";
        }

        else
        {
            ReplayManager.instance.Stop();
            ReplayManager.instance.StartPlayBack();
            ButtonText.text = "Record";
            ReplayManager.instance.snapshotIndex = 0;
        }
    }
}
