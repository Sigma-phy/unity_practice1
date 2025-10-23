using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image questionImage;
    public TMP_InputField answerInput;
    public TMP_Text resultText;
    public Button submitButton;

    [Header("Question Data")]
    public Sprite[] questionImages;
    public string[] correctAnswers;

    private int currentQuestionIndex = 0;

    void Start()
    {
        // 最初の問題をセット
        ShowQuestion(currentQuestionIndex);

        // ボタンにリスナーを登録
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void ShowQuestion(int index)
    {
        if (index >= questionImages.Length) return;
        questionImage.sprite = questionImages[index];
        answerInput.text = "";
        resultText.text = "";
    }

    void CheckAnswer()
    {
        string userAnswer = answerInput.text.Trim();
        string correct = correctAnswers[currentQuestionIndex];

        if (userAnswer.Equals(correct, System.StringComparison.OrdinalIgnoreCase))
        {
            resultText.text = "⭕ 正解！";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "❌ 不正解！ 正しい答えは「" + correct + "」です。";
            resultText.color = Color.red;
        }

        // 次の問題へ（任意）
        currentQuestionIndex++;
        if (currentQuestionIndex < questionImages.Length)
        {
            Invoke(nameof(NextQuestion), 2f);
        }
        else
        {
            resultText.text += "\n全問終了！";
        }
    }

    void NextQuestion()
    {
        ShowQuestion(currentQuestionIndex);
    }
}