using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //Following script based on Brackeys "Turn-Based Combat in Unity" video

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    UnitScript playerUnit;
    UnitScript enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());


    }

    IEnumerator SetupBattle() //Runs once at the start of battle to set the HUD values and spawn the units. Is IEnumerator so we can pause and see whats on screen
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<UnitScript>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<UnitScript>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " appears!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); //Reason for IEnumerator, pauses the screen for 2 seconds before going to PLAYERTURN state

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.attack);

        enemyHUD.SetHP(enemyUnit.currentHP);
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
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You heal your wounds";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        //Enemy logic
        //Just basic here to get working, but will eventually reference the unit and have different logic for each enemy

        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.attack);

        playerHUD.SetHP(playerUnit.currentHP);

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

    public void OnAttackButton()
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
