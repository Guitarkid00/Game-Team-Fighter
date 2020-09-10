using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedStateMachine : MonoBehaviour
{
    public enum BattleStates
    {
        START,
        PLAYERTURN,
        ENEMYTURN,
        CALCDAMAGE,
        ADDSTATUSEFFECT,
        WIN,
        LOSE
    }

    private BattleStates currentState;

    private void Start()
    {
        currentState = BattleStates.START;
    }

    private void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (BattleStates.START):
                //Start State
                break;
            case (BattleStates.PLAYERTURN):
                //Start State
                break;
            case (BattleStates.ENEMYTURN):
                //Start State
                break;
            case (BattleStates.ADDSTATUSEFFECT):
                //Start State
                break;
            case (BattleStates.CALCDAMAGE):
                //Start State
                break;
            case (BattleStates.WIN):
                //Start State
                break;
            case (BattleStates.LOSE):
                //Start State
                break;
        }
    }

}
