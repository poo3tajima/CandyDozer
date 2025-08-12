using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject candyPrefab;  // CandyPrefabプロパティ
    public float shotForce;
    public float shotTorque;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();  // 入力の検知
    }


    public void Shot()
    {
        // プレハブからCandyオブジェクトを生成
        GameObject candy = Instantiate(
            candyPrefab,
            transform.position,
            Quaternion.identity
        );  // オブジェクトの生成

        // CandyオブジェクトのRigidbodyを取得し力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce);  // フォースとトルクの加算
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));
    }
}
