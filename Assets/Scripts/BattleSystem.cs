using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public enum EnemyActionState { ATTACK, REPAIR }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;
    public TMP_Text enemyActionText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    public EnemyActionState enemyAction;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Ваш враг " + enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Выберите действие";
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Атака прошла успешно";

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerRepair()
    {
        playerUnit.Repair(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Здоровье восстановлено";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDodge()
    {
        playerUnit.dodgeValue = UnityEngine.Random.Range(enemyUnit.damage / 2, enemyUnit.damage + 1);
        dialogueText.text = $"Уворот на {playerUnit.dodgeValue} урона";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnRepairButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerRepair());
    }

    public void OnDodgeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerDodge());
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Ход врага";
        enemyAction = (EnemyActionState)UnityEngine.Random.Range(0, 2);


        yield return new WaitForSeconds(1f);
        bool isDead = false;
        if (enemyAction == EnemyActionState.ATTACK) { isDead = EnemyAttack(); }
        else if (enemyAction == EnemyActionState.REPAIR) { isDead = EnemyRepair(); }

        yield return new WaitForSeconds(1f);

        enemyActionText.text = "";


        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Победа";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Поражение";
        }
    }


    bool EnemyRepair()
    {
        enemyActionText.text = "Ремонт";
        enemyUnit.Repair(5);
        enemyHUD.SetHP(enemyUnit.currentHP);
        return false;
    }

    bool EnemyAttack()
    {
        enemyActionText.text = "Атака";
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage - playerUnit.dodgeValue);
        playerHUD.SetHP(playerUnit.currentHP);
        return isDead;
    }



}