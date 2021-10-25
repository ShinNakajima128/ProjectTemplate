using UnityEngine;
using UnityEngine.UI;

public class LoadTest : MonoBehaviour
{
    //背景
    [SerializeField]
    Image m_testBackground = default;
    //背景用の画像
    [SerializeField]
    Sprite[] m_testSprite = default;
    //押したら処理を実行したいボタン
    [SerializeField]
    Button m_testButton = default;

    void Start()
    {
        //使用例
        m_testBackground.sprite = m_testSprite[0];  //一枚目の背景をセット

        LoadSceneManager.FadeInPanel(() =>
        {
            m_testBackground.sprite = m_testSprite[1]; //暗転後、背景の画像を変更する
        });

        //ボタンが押されたら関数を呼びたい時の書き方
        m_testButton.onClick.AddListener(() => LoadSceneManager.AnyLoadScene("Test")); //ボタンが押されたら「Test」というSceneに遷移する処理を設定
    }
    void Sample()
    {
        //コールバック無し
        LoadSceneManager.FadeOutPanel(); //画面が徐々に暗転していく関数。画面の状態を変更させたりしたい時に使用してください。
        
        LoadSceneManager.FadeInPanel(); //画面を徐々に表示する関数。主にフェードアウトした後に使用するものです。

        LoadSceneManager.AnyLoadScene("NextScene"); //引数に指定した名前のSceneに暗転しながら遷移します。

        LoadSceneManager.Restart(); //画面暗転後、現在のSceneを再読込みする。もう一度プレイするボタンを選択した時に実行するなど。

        LoadSceneManager.LoadBeforeScene(); //画面暗転後、直前のSceneに遷移する。クイズSceneからステージ選択画面に戻る時など。

        LoadSceneManager.QuitGame(); //画面暗転後、ゲームを終了する。実装する意味がなさそうなので、この関数にはコールバックの記述は現状できないです。

        //コールバック有り
        LoadSceneManager.FadeOutPanel(() =>
        {
            Debug.Log("フェードアウトが完了しました。");
        });
        
        LoadSceneManager.FadeInPanel(() =>
        {
            Debug.Log("フェードインが完了しました。");
        });
        
        LoadSceneManager.AnyLoadScene("NextScene", () =>
        {
            Debug.Log("遷移開始");
            Debug.Log("Sceneが切り替わる直前に実行したい処理をこんな感じで記述することもできます。");
            Debug.Log("もし使用していて不具合が起きた場合はリーダーへ報告をお願いします。");
        });

        LoadSceneManager.Restart(() => 
        {
            Debug.Log("再読み込み開始");
        });

        LoadSceneManager.LoadBeforeScene(() => 
        {
            Debug.Log("直前のSceneを読込み開始");
        });
    }
}
