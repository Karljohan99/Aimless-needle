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

    public static event Action OnNextCraftingCard;
    public static void NextCraftingCard() => OnNextCraftingCard?.Invoke();

    public static event Action OnPreviousCraftingCard;
    public static void PreviousCraftingCard() => OnPreviousCraftingCard?.Invoke();

    public static event Action<int> OnRemoveItem;
    public static void RemoveItem(int index) => OnRemoveItem?.Invoke(index);

    public static event Action<bool> OnSetDig;
    public static void SetDig(bool value) => OnSetDig?.Invoke(value);

    public static event Action<string> OnChangeScene;
    public static void ChangeScene(string sceneName) => OnChangeScene?.Invoke(sceneName);

    public static event Func<string> OnRequestSceneName;
    public static string RequestSceneName() => OnRequestSceneName?.Invoke() ?? "";

}
