using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image HealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.fillAmount = playerHealth.currHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currHealth / 10;
    }
}
