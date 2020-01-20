using UnityEngine;
using System.Collections;
using DG.Tweening;



namespace TMPro.Examples
{

    public class CustomTeleType : MonoBehaviour
    {
        //[Range(0, 100)]
        //public int RevealSpeed = 50;
        
        //original variable
        private TMP_Text m_textMeshPro;

        //gameobjects
        public GameObject QNA_Object;
        public GameObject Options;
        public GameObject Show;

        //scripts
        private QNA NextQnA;

        //time
        [Range(0.01f, 3f)]
        public float time;

        void Awake()
        {
            // Get Reference to TextMeshPro Component
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textMeshPro.enableWordWrapping = true;
            //m_textMeshPro.alignment = TextAlignmentOptions.TopLeft;

            if (QNA_Object != null)
                NextQnA = QNA_Object.GetComponent<QNA>();
            else if (QNA_Object == null)
                Debug.Log("Should Return");
        }


        IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            //Debug.Log(totalVisibleCharacters);
            int counter = 0;
            int visibleCount = 0;

            while (true)
            //if(counter <= totalVisibleCharacters)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                counter += 1;

                yield return new WaitForSeconds(0.05f);  //reveal Speed

                if (visibleCount == totalVisibleCharacters)
                    break;
            }

            if (QNA_Object != null)
                NextQnA.Invoke("Dialogue", 0.5f);
            else if (Options !=null && Show!=null)
            {
                Options.SetActive(true);
                Options.transform.DOMoveY(Show.transform.position.y, time*2).SetEase(Ease.InQuint).SetDelay(1);
            }

            //Debug.Log("Done revealing the text.");
        }

    }
}