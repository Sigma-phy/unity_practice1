using UnityEngine;
using TMPro;
using DG.Tweening;  // DOTween ���g��

public class PopupManager : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public CanvasGroup canvasGroup;

    public void ShowPopup(string message, Color color)
    {
        popupText.text = message;
        popupText.color = color;

        // �����x�����Z�b�g
        canvasGroup.alpha = 0;
        popupText.transform.localScale = Vector3.zero;

        // DOTween �ŃA�j���[�V����
        Sequence seq = DOTween.Sequence();
        seq.Append(canvasGroup.DOFade(1, 0.2f)); // �t�F�[�h�C��
        seq.Join(popupText.transform.DOScale(1.2f, 0.3f).SetEase(Ease.OutBack)); // �����傫��
        seq.AppendInterval(1.0f); // 1�b�ԕ\��
        seq.Append(canvasGroup.DOFade(0, 0.3f)); // �t�F�[�h�A�E�g
    }
}