using UnityEngine;
using TMPro;
using DG.Tweening;  // DOTween を使う

public class PopupManager : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public CanvasGroup canvasGroup;

    public void ShowPopup(string message, Color color)
    {
        popupText.text = message;
        popupText.color = color;

        // 透明度をリセット
        canvasGroup.alpha = 0;
        popupText.transform.localScale = Vector3.zero;

        // DOTween でアニメーション
        Sequence seq = DOTween.Sequence();
        seq.Append(canvasGroup.DOFade(1, 0.2f)); // フェードイン
        seq.Join(popupText.transform.DOScale(1.2f, 0.3f).SetEase(Ease.OutBack)); // 少し大きく
        seq.AppendInterval(1.0f); // 1秒間表示
        seq.Append(canvasGroup.DOFade(0, 0.3f)); // フェードアウト
    }
}