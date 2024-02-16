using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RetryCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI times;
    RockFall rockFall;

    private void Start() {
        rockFall = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockFall>();
    }

    private void Update() {
        times.text = string.Format("{0}", rockFall.count);
    }
}
