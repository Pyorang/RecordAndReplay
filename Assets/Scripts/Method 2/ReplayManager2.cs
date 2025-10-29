using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManager2 : MonoBehaviour
{
    public static ReplayManager2 instance;
    public float currentTime = 0;

    [SerializeField] private PlayerController playerController;
    public List<ICommand> commandList = new List<ICommand>();

    public enum State
    {
        Idle,
        Recording,
        PlayBack
    }

    public State currentState = State.Idle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
    }

    public void StartRecord()
    {
        currentState = State.Recording;
        currentTime = 0;
        commandList.Add(new SetPositionCommand(playerController, playerController.gameObject.transform.position, currentTime));
    }

    public void PlayBack()
    {
        commandList.Add(new SetPositionCommand(playerController, playerController.gameObject.transform.position, currentTime));
        currentState = State.PlayBack;
        StartCoroutine(StartRecordedCommand());
    }

    public void SetIdle()
    {
        currentState = State.Idle;
        commandList.Clear();
    }

    IEnumerator StartRecordedCommand()
    {
        for(int i = 0; i < commandList.Count - 1; i++)
        {
            commandList[i].Execute();

            yield return new WaitForSeconds(commandList[i + 1].ReturnTime() - commandList[i].ReturnTime());
        }

        commandList[commandList.Count - 1].Execute();

        SetIdle();
    }
}
