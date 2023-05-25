using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IDamageable
{
    public void OnDamageTaken(int _damage);

    public void OnDeath();
}
