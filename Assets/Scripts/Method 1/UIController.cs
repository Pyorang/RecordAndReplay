using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button RecordButton;
    [SerializeField] private TextMeshProUGUI ButtonText;

    public void OnClickButton()
    {
        if (ReplayController.instance.currentState == ReplayController.State.Idle)
        {
            ReplayController.instance.StartRecording();
            ButtonText.text = "PlayBack";
        }

        else
        {
            ReplayController.instance.Stop();
            ReplayController.instance.StartPlayBack();
            ButtonText.text = "Record";
            ReplayController.instance.snapshotIndex = 0;
        }
    }
}
