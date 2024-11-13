using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceCount : MonoBehaviour
{
    public static BounceCount Instance;

    [SerializeField] private TextMeshProUGUI bounceCounterText;
    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateBounceCount()
    {
        score++;
        bounceCounterText.text = "Bounce Count :" + score.ToString();
    }
}
