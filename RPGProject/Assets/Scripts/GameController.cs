using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private Slider playerHealth = null;
    [SerializeField] private Slider enemyHealth = null;
    [SerializeField] private Button AttackButton = null;
    [SerializeField] private Button HealButton = null;
    public string winScene;
     

    private bool IsplayerTurn = true;
   
    private void Attack(GameObject target,float damage)
    {
        if (target == enemy)
        {
            enemyHealth.value -= damage;
        }
        else
        {
            playerHealth.value -= damage;
        }
        ChangeTurn();
    }
    private void Heal(GameObject target, float amount)
    {
        if(target== enemy)
        {
            enemyHealth.value += amount;
        }
        else
        {
            playerHealth.value += amount;
        }
        ChangeTurn();
    }
    public void ButtonAttack()
    {
        Attack(enemy, 100);
    }
    public void ButtonHeal() {
        Heal(Player, 3);
    }
    private void ChangeTurn()
    {
        IsplayerTurn = !IsplayerTurn;

        if (!IsplayerTurn)
        {
            AttackButton.interactable = false;
            HealButton.interactable = false;
            StartCoroutine(enemyTurn());
        }
        else
        {
            AttackButton.interactable = true;
            HealButton.interactable = true;
        }
    }
    private IEnumerator enemyTurn()
    {
        yield return new WaitForSeconds(3);
        int random = 0;
        random = Random.Range(1, 3);

        if (random== 1)
        {
            Attack(Player, 10);
        }
        else
        {
            Heal(enemy, 3);
        }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.value == 0) {
            SceneManager.LoadScene("winScene");
        }
    }
}
