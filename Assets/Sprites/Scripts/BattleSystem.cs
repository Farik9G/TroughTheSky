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
<<<<<<<< HEAD:Assets/BattleSystem.cs
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
========
    public float delayTime = 1f; // ����� �������� ����� ��������� ������
    private float lastClickTime = 0f; // ����� ���������� ������� ������

    private GameObject playerPrefab;
    private GameObject enemyPrefab;
>>>>>>>> origin/leikocit:Assets/Sprites/Scripts/BattleSystem.cs

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
<<<<<<<< HEAD:Assets/BattleSystem.cs
========
        Debug.Log(ObjectManager.instance.enemy);
        Debug.Log(ObjectManager.instance.player);
        enemyPrefab = ObjectManager.instance.enemy;
        playerPrefab = ObjectManager.instance.player;

        //��������� ������ ������������ �� ����� ������ �����
        playerPrefab.GetComponent<PC>().enabled = false;
>>>>>>>> origin/leikocit:Assets/Sprites/Scripts/BattleSystem.cs
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
<<<<<<<< HEAD:Assets/BattleSystem.cs
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
========
        Vector3 playerPos = new Vector3(-0.85f, -0.11f, 0f);
        GameObject playerGO = Instantiate(ObjectManager.instance.player, playerPos, Quaternion.identity);
        playerGO.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        playerUnit = playerGO.GetComponent<Unit>();

        Vector3 enemyPos = new Vector3(0.91f, 0.3f, 0f);
        GameObject enemyGO = Instantiate(ObjectManager.instance.enemy, enemyPos, Quaternion.identity);
        enemyGO.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
>>>>>>>> origin/leikocit:Assets/Sprites/Scripts/BattleSystem.cs
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "��� ���� " + enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "�������� ��������";
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "����� ������ �������";

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
        dialogueText.text = "�������� �������������";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDodge()
    {
        playerUnit.dodgeValue = UnityEngine.Random.Range(enemyUnit.damage / 2, enemyUnit.damage + 1);
        dialogueText.text = $"������ �� {playerUnit.dodgeValue} �����";

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
        dialogueText.text = "��� �����";
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
            dialogueText.text = "������";
<<<<<<<< HEAD:Assets/BattleSystem.cs
            SystemBoss.n++;
            SystemBoss.b = false;
========
            Destroy(playerPrefab);
            Destroy(enemyPrefab);
            ObjectManager.destroyedEnemies.Add(ObjectManager.instance.enemy.name);
            MainMenu.n1 = 1;
            ObjectManager.currentHp = playerUnit.currentHP;
           // rubers1.rubber1 += 15;
           // woods1.wood1 += 15;
           // foods1.food1 += 15;
           // metals1.metal1 += 15;
>>>>>>>> origin/leikocit:Assets/Sprites/Scripts/BattleSystem.cs
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            ObjectManager.fwood = 25;
            ObjectManager.fmetal = 25;
            ObjectManager.frebber = 5;
            ObjectManager.ffood = 25;
            ObjectManager.rand = 1;


        }
        else if (state == BattleState.LOST)
        {
            Destroy(playerPrefab);
            dialogueText.text = "���������";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
        }
    }


    bool EnemyRepair()
    {
        enemyActionText.text = "������";
        enemyUnit.Repair(5);
        enemyHUD.SetHP(enemyUnit.currentHP);
        return false;
    }

    bool EnemyAttack()
    {
        enemyActionText.text = "�����";
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage - playerUnit.dodgeValue);
        playerHUD.SetHP(playerUnit.currentHP);
        return isDead;
    }



}


















