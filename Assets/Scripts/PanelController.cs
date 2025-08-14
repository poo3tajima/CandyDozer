using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour
{
    RectTransform panel;
    public Image img1;
    public Image img2;

    public TextMeshProUGUI hello;
    public TextMeshProUGUI score;

    void Start()
    {
        panel = GetComponent<RectTransform>();
        panel.DOAnchorPos(new Vector2(240f, 0), 0.6f)
            .SetEase(Ease.OutBack);

        panel.DOLocalRotate(new Vector3(360f, 0, 0), 0.6f,
            RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic);

        panel.localScale = Vector3.one * 0.2f;
        panel.DOScale(1f, 0.6f)
            .SetEase(Ease.OutBack, 5f);

        img1.DOColor(new Color(1f, 0, 0), 1.5f);
        img2.DOFade(0.2f, 1.5f);

        // hello.DOText("Hello World", 1f);
        hello.DOText("Hello World", 2f, false, ScrambleMode.Custom, "*+?%$&");
        score.DOCounter(0, 100000000, 1.5f, true);
    }


    void Update()
    {

    }
}
