using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Qualities")]
public class EnemyQualities : ScriptableObject //ScriptableObject
{
    [SerializeField] private float regularSpeed;
    [SerializeField] private float aggroSpeed;
    [SerializeField] private Color aggroColor;
    [SerializeField] private float damage;

    public float GetRegularSpeed()
    {
        return regularSpeed;
    }

    public float GetAggroSpeed()
    {
        return aggroSpeed;
    }

    public Color GetAggroColor()
    {
        return aggroColor;
    }

    public float GetDamage()
    {
        return damage;
    }
}
