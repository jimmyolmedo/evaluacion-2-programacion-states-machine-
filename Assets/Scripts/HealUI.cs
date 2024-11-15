using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealUI : MonoBehaviour
{
    [SerializeField] Image healthFill;

    private void OnEnable()
    {
        Player.OnHealtChange += ChangeHealth;
    }

    private void OnDisable()
    {
        Player.OnHealtChange += ChangeHealth;
    }

    void ChangeHealth(int health, int maxHealth)
    {
        healthFill.fillAmount = (float)health / maxHealth;
    }
}
