using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;

    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        // Unityに登録されているFire1ボタンが押されたとき(クリックか左矢印)
        if (Input.GetButtonDown("Fire1")) Shot();  // 入力の検知
    }


    // キャンディのプレハブからランダムに1つ選ぶ
    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        // 舞台のサイズとクリックの位置の割合でキャンディ生成のx座標を算出
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }


    public void Shot()
    {
        // キャンディを生成できる条件外ならばShotしない
        if (candyManager.GetCandyAmount() <= 0) return;
        if (shotPower <= 0) return;

        // プレハブからCandyオブジェクトを生成
        GameObject candy = Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),  // ダミーオブジェクトの位置を取得して発射  
            Quaternion.identity
        );

        // 生成したCandyオブジェクトの親をcandyParentTransformに設定する(グループ化するだけ)
        candy.transform.parent = candyParentTransform;

        // CandyオブジェクトのRigidbodyを取得し力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        // shotForce値で打ち出す強さを決める
        candyRigidBody.AddForce(transform.forward * shotForce);
        // y軸に回転をあたえる
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        // Candyのストックを消費
        candyManager.ConsumeCandy();
        // ShotPowerを消費
        ConsumePower();

        // サウンドを再生
        shotSound.Play();
    }


    void OnGUI()
    {
        GUI.color = Color.black;

        // ShotPowerの残数を+の数で表示
        string label = "";
        for (int i = 0; i < shotPower; i++) label = label + "+";

        GUI.Label(new Rect(50, 65, 100, 30), label);
    }


    void ConsumePower()
    {
        // ShotPowerを消費すると同時に回復のカウントをスタート
        shotPower--;
        StartCoroutine(RecoverPower());  // リカバリー開始
    }


    IEnumerator RecoverPower()
    {
        // 一定秒待ったあとにshotPowerを回復
        yield return new WaitForSeconds(RecoverySeconds);  //3秒まつ
        shotPower++;
    }
}
