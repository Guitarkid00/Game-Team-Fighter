using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //NOTE I am planning on remaking all of this to a version that I feel will work better for battle mechanics I haven't made yet
    //Will still be using a StateMachine due to turn based nature, just that I found better way to setup the code

    public GameObject playerPrefab1; //Gets the first unit in the Current Team List
    public GameObject enemyPrefab1; //Is the first unit of the enemies for this stage
    //NOTE has a 1 because eventually there will be multiple of these for each team for multiple units

    public Transform playerBattleStation1;
    public Transform enemyBattleStation1;

    UnitScript playerUnit1;
    UnitScript enemyUnit1;

    public BattleHUD playerHUD1;
    public BattleHUD enemyHUD1;

    public Text dialogueText;

    public BattleState state;

    

    void Start() //Sets BattleState to START and starts the method to set up the UI
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());


    }

    IEnumerator SetupBattle() //Runs once at the start of battle to set the HUD values and spawn the units. Is IEnumerator so we can pause and see whats on screen
    {
        GameObject playerGO = Instantiate(playerPrefab1, playerBattleStation1);
        playerUnit1 = playerGO.GetComponent<UnitScript>();

        GameObject enemyGO = Instantiate(enemyPrefab1, enemyBattleStation1);
        enemyUnit1 = enemyGO.GetComponent<UnitScript>();

        dialogueText.text = "The enemy appears before you";

        playerHUD1.SetHUD(playerUnit1); //Both of these go to the BattleHUD.cs script and are used to set the UI Display
        enemyHUD1.SetHUD(enemyUnit1);

        yield return new WaitForSeconds(2f); //Reason for IEnumerator, pauses the screen for 2 seconds before going to PLAYERTURN state

        state = BattleState.PLAYERTURN; //Change BattleState to PLAYERTURN
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        bool isDead = enemyUnit1.TakeDamage(playerUnit1.unitAttack);

        enemyHUD1.SetHP(enemyUnit1.currentHP);
        dialogueText.text = "The attack is successful";

        yield return new WaitForSeconds(2f);

        //Check if enemy dead
        if (isDead)
        {
            //End Battle
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            //Enemy Turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //Change state based on what happened
    }

    IEnumerator PlayerHeal()
    {
        playerUnit1.Heal(5);

        playerHUD1.SetHP(playerUnit1.currentHP);
        dialogueText.text = "You heal your wounds";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        //Enemy logic
        //Just basic here to get working, but will eventually reference the unit and have different logic for each enemy

        dialogueText.text = enemyUnit1.unitName + " attacks!";
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit1.TakeDamage(enemyUnit1.unitAttack);

        playerHUD1.SetHP(playerUnit1.currentHP);

        //Check if player dead
        if (isDead)
        {
            //End Battle
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            //Enemy Turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        //Change state based on what happened
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            //Victory
            dialogueText.text = "You won the battle";
            //show rewards
            //leave battle scene
        }
        else if(state == BattleState.LOST)
        {
            //Loss
            dialogueText.text = "You were defeated";
            //leave battle scene
        }
    }

    public void OnAttackButton() //What happens when the Attack button is pressed
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
