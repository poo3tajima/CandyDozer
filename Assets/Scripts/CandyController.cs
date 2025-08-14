using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CandyController : MonoBehaviour
{
    public Transform lookAtTarget;
    public GameObject msg;

    void Start()
    {
        // 目標地点へ何秒かけて移動するか

        // 拡張版の記述

        // 動く
        // トゥイーンが終わったら、メッセージを表示
        transform.DOLocalMove(new Vector3(15f, 0, 0), 0.5f)
        .SetLoops(6, LoopType.Yoyo).OnComplete(ShowMsg);



        // 回転する
        // transform.DOLocalRotate(new Vector3(180f, 45f, -100f), 1f);

        // ターゲットオブジェクトを見る
        // transform.DOLookAt(lookAtTarget.localPosition, 0.5f);

        // (1秒後に)スケールする
        // transform.DOScale(new Vector3(4f, 0.24f, 2f), 1f).SetDelay(1f);

        // 通常版の記述
        // DOTween.To(() => transform.localPosition,  // 開始時の位置
        //     x => transform.localPosition = x,  // パラメータの更新
        //     new Vector3(15f, 0, 0),  // ゴールの位置
        //     1f  // 移動の時間
        //     );
    }

    // メッセージを表示する
    void ShowMsg()
    {
        msg.SetActive(true);
    }

    void Update()
    {

    }
}
