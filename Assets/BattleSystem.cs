using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public enum EnemyActionState { ATTACK, REPAIR }

public class BattleSystem : MonoBehaviour
{
    public float delayTime = 1f; // время задержки между нажатиями кнопок
    private float lastClickTime = 0f; // время последнего нажатия кнопки

    public static GameObject playerPrefab;
    public static GameObject enemyPrefab;

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
        enemyPrefab = ObjectManager.instance.enemy;
        playerPrefab = ObjectManager.instance.player;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Vector3 playerPos = new Vector3(-0.85f, -0.11f, 0f);
        GameObject playerGO = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        playerUnit = playerGO.GetComponent<Unit>();

        Vector3 enemyPos = new Vector3(0.91f, 0.56f, 0f);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
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
        float currentTime = Time.time;
        if (state != BattleState.PLAYERTURN)
            return;

        if (currentTime - lastClickTime > delayTime)
        {
            StartCoroutine(PlayerAttack());
            lastClickTime = currentTime;
        }
    }

    public void OnRepairButton()
    {
        float currentTime = Time.time;

        if (state != BattleState.PLAYERTURN)
            return;

        if (currentTime - lastClickTime > delayTime)
        {
            StartCoroutine(PlayerRepair());
            lastClickTime = currentTime;
        }
    }

    public void OnDodgeButton()
    {
        float currentTime = Time.time;

        if (state != BattleState.PLAYERTURN)
            return;

        if (currentTime - lastClickTime > delayTime)
        {
            StartCoroutine(PlayerDodge());
            lastClickTime = currentTime;
        }
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
            Destroy(playerPrefab);
            Destroy(enemyPrefab);
            ObjectManager.destroyedEnemies.Add(ObjectManager.instance.enemy.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Поражение";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
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