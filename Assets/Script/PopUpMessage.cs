using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    [SerializeField] GameObject PopUpPanel;

    void OnPopUpMessage(string PopUpText)
    {
        //Textコンポーネントを取得する
        Text ChangeText = gameObject.GetComponent<Text>();

        ChangeText.text = PopUpText;

        StartCoroutine("HiddenText");
    }

    private IEnumerator HiddenText()
    {
        yield return new WaitForSeconds(5.0f);

        PopUpPanel.SetActive(false);
    }

}
