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

    private GameObject playerPrefab;
    private GameObject enemyPrefab;

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
        Debug.Log(ObjectManager.instance.enemy);
        Debug.Log(ObjectManager.instance.player);
        enemyPrefab = ObjectManager.instance.enemy;
        playerPrefab = ObjectManager.instance.player;

        //Отключает скрипт передвижения на время боевой сцены
        playerPrefab.GetComponent<PC>().enabled = false;
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        Vector3 playerPos = new Vector3(-0.85f, -0.11f, 0f);
        GameObject playerGO = Instantiate(ObjectManager.instance.player, playerPos, Quaternion.identity);
        playerGO.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        playerUnit = playerGO.GetComponent<Unit>();

        Vector3 enemyPos = new Vector3(0.91f, 0.3f, 0f);
        GameObject enemyGO = Instantiate(ObjectManager.instance.enemy, enemyPos, Quaternion.identity);
        enemyGO.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
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
        playerUnit.Repair(playerUnit.maxHP / 10);

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
        //enemyAction = (EnemyActionState)UnityEngine.Random.Range(0, 2);
        float randomValue = UnityEngine.Random.value;

        if (randomValue <= 0.7f) enemyAction = EnemyActionState.ATTACK;
        else enemyAction = EnemyActionState.REPAIR;


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
            MainMenu.n1 = 1;
            ObjectManager.currentHp = playerUnit.currentHP;
           // rubers1.rubber1 += 15;
           // woods1.wood1 += 15;
           // foods1.food1 += 15;
           // metals1.metal1 += 15;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            ObjectManager.fwood = 15;
            ObjectManager.fmetal = 15;
            ObjectManager.frebber = 10;
            ObjectManager.ffood = 15;
            ObjectManager.rand = 1;


        }
        else if (state == BattleState.LOST)
        {
            Destroy(playerPrefab);
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


















