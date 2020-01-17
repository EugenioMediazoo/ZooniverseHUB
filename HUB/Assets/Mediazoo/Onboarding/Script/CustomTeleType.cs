using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{

    public class CustomTeleType : MonoBehaviour
    {


        //[Range(0, 100)]
        //public int RevealSpeed = 50;

        private TMP_Text m_textMeshPro;


        void Awake()
        {
            // Get Reference to TextMeshPro Component
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textMeshPro.enableWordWrapping = true;
            //m_textMeshPro.alignment = TextAlignmentOptions.TopLeft;
        }


        IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            Debug.Log(totalVisibleCharacters);
            int counter = 0;
            int visibleCount = 0;

            while (true)
            //if(counter <= totalVisibleCharacters)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                counter += 1;

                yield return new WaitForSeconds(0.05f);

                if (visibleCount == totalVisibleCharacters)
                    break;
            }

            Debug.Log("Done revealing the text.");
        }

    }
}