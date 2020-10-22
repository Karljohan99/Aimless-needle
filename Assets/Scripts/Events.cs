using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<float> OnSetHealth;
    public static void SetHealth(float value) => OnSetHealth?.Invoke(value);

    public static event Func<float> OnRequestHealth;
    public static float RequestHealth() => OnRequestHealth?.Invoke() ?? 0;

    public static event Action OnWinLevel;
    public static void WinLevel() => OnWinLevel?.Invoke();

    public static event Action OnDie;
    public static void Die() => OnDie?.Invoke();
}
