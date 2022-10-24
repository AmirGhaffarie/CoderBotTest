using System.Collections;
using UnityEngine;

public class CommandRunner : MonoBehaviour
{
    [SerializeField] BlockList mainCommandsList;

    bool runningCommands = false;

    private void OnEnable()
    {
        GameEvents.PlayClicked += RunCommands;
        GameEvents.LevelReset += StopRunning;
        GameEvents.LevelWon += StopRunning;
    }

    private void OnDisable()
    {
        GameEvents.PlayClicked -= RunCommands;
        GameEvents.LevelReset -= StopRunning;
        GameEvents.LevelWon -= StopRunning;
    }

    private void StopRunning()
    {
        runningCommands = false;
        StopAllCoroutines();
    }

    private void RunCommands()
    {
        if (runningCommands)
        {
            StopAllCoroutines();
            runningCommands = false;
        }
        else
        {
            runningCommands = true;
            StartCoroutine(RunCommandsRoutine());
        }
    }

    private IEnumerator RunCommandsRoutine()
    {
        for (int i = 0; i < mainCommandsList.Count; i++)
        {
            var block = mainCommandsList.Get(i);

            if(block.CheckPossiblity())
            {
                yield return block.SuccessAction();
            }
            else
            {
                yield return block.FailAction();
            }
        }
        runningCommands = false;
    }
}
