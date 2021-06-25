using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int morale;
    [SerializeField] public int condition;
    [SerializeField] public int fuel;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI moraleText;
    [SerializeField] private TextMeshProUGUI conditionText;
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private GameObject gameOverAnimation;

    private void Update()
    {
        healthText.text = health.ToString();
        moraleText.text = morale.ToString();
        conditionText.text = condition.ToString();
        fuelText.text = fuel.ToString();

        if (health <= 0 || morale <= 0 || fuel <= 0 || condition <= 0)
        {
            gameOverAnimation.SetActive(true);
            StartCoroutine(RestartScene());
        }
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
