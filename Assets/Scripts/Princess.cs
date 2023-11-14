using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    [SerializeField]
    GameObject characterToReact;

    [SerializeField]
    TMP_FontAsset fontForHits;

    [SerializeField]
    string victoryScene;

    [SerializeField]
    float delay = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == characterToReact)
        {
            var go = new GameObject();
            go.name = $"PrincessTalking";

            go.transform.position = new Vector2(transform.position.x, transform.position.y + 1);

            var text = go.AddComponent<TextMeshPro>();

            if (fontForHits != null)
                text.font = fontForHits;
            text.fontSize = 4.5f;

            text.enableWordWrapping = false;

            text.alignment = TextAlignmentOptions.Center;

            text.text = "It was about time!";
            text.color = Color.cyan;

            text.renderer.sortingLayerName = "UI";
            text.rectTransform.sizeDelta = new Vector2(2, 2);

            Rigidbody2D rb2D = go.AddComponent<Rigidbody2D>();
            rb2D.isKinematic = true;
            rb2D.velocity = new Vector2(0, 1);

            GameObject.Destroy(go, 2);


            //coroutine
            StartCoroutine(nameof(LoadSceneAfterSecond));
        }

    }

    private IEnumerator LoadSceneAfterSecond()
    {
        if (string.IsNullOrEmpty(victoryScene) == false)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(victoryScene);
        }
    }


}
