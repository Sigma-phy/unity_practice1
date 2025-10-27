using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image questionImage;
    public TMP_InputField answerInput;
    public Button submitButton;         //　解答確認ボタン
    public Button nextButton;          // 次の問題ボタン
    public Button prevButton;          // 前の問題ボタン
    public PopupManager popupManager;

    [Header("Question Data")]
    public Sprite[] questionImages;
    public string[] correctAnswers;

    private int currentQuestionIndex = 0;

    void Start()
    {
        // 最初の問題をセット
        ShowQuestion(currentQuestionIndex);

        // 各ボタンの処理を登録
        submitButton.onClick.AddListener(CheckAnswer);
        nextButton.onClick.AddListener(NextQuestion);
        prevButton.onClick.AddListener(PreviousQuestion);
    }

    void ShowQuestion(int index)
    {
        if (index >= 0 && index < questionImages.Length)
        {
            questionImage.sprite = questionImages[index];
            answerInput.text = "";

            // ボタン制御（範囲外防止）
            prevButton.interactable = (index > 0);
            nextButton.interactable = (index < questionImages.Length - 1);
        }
        else
        {
            popupManager.ShowPopup("問題が存在しません。", Color.yellow);
        }
    }

    // 「回答ボタン」が押されたときに呼ばれる関数
    void CheckAnswer()
    {
        // 入力された文字を取得
        string userAnswer = answerInput.text.Trim();  // Trim()で空白を除去
        string correct = correctAnswers[currentQuestionIndex];

        // 答えが正解か判定
        if (userAnswer == correct)
        {
            // ✅ 正解だったとき
            popupManager.ShowPopup("正解！", Color.green);
        }
        else
        {
            // ❌ 不正解だったとき
            popupManager.ShowPopup("不正解！", Color.red);
        }

        // 入力欄をクリア（任意）
        answerInput.text = "";
    }
    
    //　次の問題へ
    void NextQuestion()
    {
        if (currentQuestionIndex < questionImages.Length - 1)
        {
            currentQuestionIndex++;
            ShowQuestion(currentQuestionIndex);
        }
    }

    //　前の問題へ
    void PreviousQuestion()
    {
        if (currentQuestionIndex > 0)
        {
            currentQuestionIndex--;
            ShowQuestion(currentQuestionIndex);
        }
    }

}