using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class TimeController : MonoBehaviour
{
    [SerializeField] public float timecounter;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreTime;

    private void Update() {
        timecounter += Time.deltaTime;
        minutes = Mathf.FloorToInt(timecounter / 60f);
        seconds = Mathf.FloorToInt(timecounter - minutes * 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //For show total time when clear level.
        scoreTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
