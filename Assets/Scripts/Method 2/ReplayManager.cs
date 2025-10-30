using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public enum State
    {
        Idle,
        Recording,
        PlayBack
    }

    [SerializeField] private PlayerController playerController;

    public static ReplayManager s_instance;

    public float CurrentTime = 0;
    public State CurrentState = State.Idle;
    public List<RecordedCommand> CommandList = new List<RecordedCommand>();

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        CurrentTime += Time.fixedDeltaTime;
    }

    public void StartRecord()
    {
        CurrentState = State.Recording;
        CurrentTime = 0;
        CommandList.Add(new SetPositionCommand(playerController.gameObject, CurrentTime));
    }

    public void PlayBack()
    {
        CommandList.Add(new SetPositionCommand(playerController.gameObject, CurrentTime));
        CurrentState = State.PlayBack;
        StartCoroutine(StartRecordedCommand());
    }

    public void SetIdle()
    {
        CurrentState = State.Idle;
        CommandList.Clear();
    }

    IEnumerator StartRecordedCommand()
    {
        for(int i = 0; i < CommandList.Count - 1; i++)
        {
            CommandList[i].Execute();

            yield return new WaitForSeconds(CommandList[i + 1].ReturnTime() - CommandList[i].ReturnTime());
        }

        CommandList[CommandList.Count - 1].Execute();

        SetIdle();
    }
}
