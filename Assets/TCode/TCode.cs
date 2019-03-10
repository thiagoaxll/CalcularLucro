/*
 * Copyright (c) Thiago Z Silva
 * Created - 2019
 */

using UnityEngine;
using UnityEngine.UI;


namespace TCode
{
    public abstract class Utils : MonoBehaviour
    {

        /// <summary>
        /// Converte o localscale, para uma escala de 0 ~ 100
        /// </summary>
        public static Vector2 ConvertCanvasPositionToScale(Vector2 pos)
        {
            Vector2 positionConverted = pos;
            positionConverted.x = (positionConverted.x * 1920) / (100);
            positionConverted.y = (positionConverted.y * 1080) / (100) * -1;
            return positionConverted;
        }


        public delegate void FunctionToCall();

        /// <summary>
        /// Cria Um botão e associa a uma função
        /// </summary>
        /// <param name="func: ">Passar a função a ser associada.</param>
        /// <param name="pos: ">(Opcional)Posição que o botão vai ser instanciado X, y  (0 ~ 100).</param>

        public static void DebbugerButton(FunctionToCall func, Vector2? pos = null)
        {
            Vector2 localPositionConverted = pos ?? new Vector2(0, 0);
            localPositionConverted = ConvertCanvasPositionToScale(localPositionConverted);

            GameObject buttonToInstantiate = Instantiate(Resources.Load("DebbugButton") as GameObject);
            buttonToInstantiate.GetComponentInChildren<Text>().text = func.Method.Name;
            buttonToInstantiate.GetComponentInChildren<Button>().onClick.AddListener(delegate { func(); });
            buttonToInstantiate.GetComponentInChildren<RectTransform>().pivot = new Vector2(0, 1);
            buttonToInstantiate.GetComponentInChildren<RectTransform>().GetChild(0).localPosition = localPositionConverted;
        }


        public static Text textToDisplay;

        /// <summary>
        /// Cria um texto para debug in run-Time
        /// </summary>
        /// <param name="text: ">texto que será exbido no objeto.</param>
        /// <param name="pos: ">(Opcional)Posição que o texto vai ser instanciado X, y  (0 ~ 100).</param>
        /// <param name="persistent: "> (Opcional) false: O texto não é destruido, true: O texto é destruido após 1seg</param>

        public static void DebbugerText(string text, Vector2? pos = null, bool? temporaryText = false)
        {
            if (textToDisplay == null)
            {
                Vector2 localPositionConverted = pos ?? new Vector2(40, 50);
                localPositionConverted = ConvertCanvasPositionToScale(localPositionConverted);

                GameObject textToInstantiate = Instantiate(Resources.Load("DebbugText") as GameObject);
                textToDisplay = textToInstantiate.GetComponentInChildren<Text>();
                textToInstantiate.GetComponentInChildren<RectTransform>().pivot = new Vector2(0, 1);
                textToInstantiate.GetComponentInChildren<RectTransform>().GetChild(0).localPosition = localPositionConverted;
                if (temporaryText == true)
                {
                    Destroy(textToInstantiate, 1);
                    //textToDisplay = null;
                }
            }
            textToDisplay.text = text;
        }

    }

}
