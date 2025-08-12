using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude;  // 移動量
    public float speed;  // 移動速度

    void Start()
    {
        // ローカルポジションを初期位置に
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // 変位を計算
        // Sinは0～1～0～-1～0を回る　amplitudeで移動量の倍率を変更
        float z = amplitude * Mathf.Sin(Time.time * speed);

        // zを変位させたポジションに再設定
        // ローカルポジションを変更するには、Vector3型で変更を加えなければならない
        // 構造体は値渡しになるので
        transform.localPosition = startPosition + new Vector3(0, 0, z);  // ポジションの反映
    }
}
