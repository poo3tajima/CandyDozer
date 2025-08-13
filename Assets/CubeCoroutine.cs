using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCoroutine : MonoBehaviour
{
    Vector3 rot;
    float sc;

    void Start()
    {
        Application.targetFrameRate = 60;
        rot = Vector3.zero;  // (0, 0, 0)
        sc = 1.0f;
        StartCoroutine(ChangeRotation());
    }

    void Update()
    {
        transform.Rotate(rot);
        Vector3 nowScale = transform.localScale;
        transform.localScale = nowScale * sc;

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeScale(true));
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ChangeScale(false));
        }
    }

    // コルーチンはメインのUpdate()とは別にもうひとつUpdate()をつくり、
    // 何秒経ったら、何をするみたいな別処理をつくれる
    // IEnumerator は戻り値のこと
    // コルーチンは1回以上のyield returnが必要
    IEnumerator ChangeRotation()
    {
        yield return null;
        yield return new WaitForSeconds(1f);
        Debug.Log("1秒経過");
        yield return new WaitForSeconds(2f);
        Debug.Log("3秒経過、x回転開始");
        rot.x = 1.0f;
        yield return new WaitForSeconds(3f);
        Debug.Log("6秒経過、y回転開始");
        rot.y = 1.0f;
        yield return new WaitForSeconds(4f);
        Debug.Log("10秒経過、z回転開始");
        rot.z = 1.0f;
        yield return new WaitForSeconds(3f);
        Debug.Log("13秒経過、回転終了");
        rot.x = 0.0f;
        rot.y = 0.0f;
        rot.z = 0.0f;
    }

    IEnumerator ChangeScale(bool isLarger)
    {
        if (isLarger)
        {
            sc = 1.002f;
        }
        else
        {
            sc = -1.002f;
        }

        yield return new WaitForSeconds(2f);
        sc = 1.0f;
    }
}
