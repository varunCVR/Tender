using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class SceneManagement : MonoBehaviour
{

    public Text debugText;
    public bool loadSceneBybool;
    public Object sceneToLoad;

    public bool usebyGujarati;

    private void Update()
    {
        if (loadSceneBybool)
        {
            LoadSceneAdvanced(sceneToLoad);
            loadSceneBybool = false;
        }
    }

    public bool loadGujaratiMenu = true;
    public void BacktoEnglishMenu()
    {
        if (loadGujaratiMenu)
        {
            SceneManager.LoadScene("Menu Guj");
        }
        else
        {
            SceneManager.LoadScene("Menu");  
        }
             
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadSceneAdvanced(UnityEngine.Object sceneName)
    {
        SceneManager.LoadScene(sceneName.name);
        //debugText.text = "LoadSceneAdvanced is Called...";
    }

    public void LoadSceneWithString(string name)
    {
       // debugText.text = "LoadScene With String is Called...";
        SceneManager.LoadScene(name);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

/////////////// St 9.......
    public void St9_3()
    {
        SceneManager.LoadScene("demo01");
    }
    public void St9_5()
    {
         SceneManager.LoadScene("demo02");
    }
    public void St9_10()
    {
       SceneManager.LoadScene("demo03");
    }
  
/////////////// St 10.......
    public void St10_2()
    {
        //SceneManager.LoadScene("demo04");
        SceneManager.LoadScene("Chem 3");
    }
    public void St10_3()
    {
        SceneManager.LoadScene("demo05");
    }
    public void St10_6()
    {
        SceneManager.LoadScene("Bio 2");
    }
    public void St10_10()
    {
          SceneManager.LoadScene("demo07");
    }
    public void St10_11()
    {
          SceneManager.LoadScene("demo08");
    }


    /////////////// St 11.......
    public void St11C_1()
    {
        SceneManager.LoadScene("demo09");
    }
    public void St11C_2()
    {
        SceneManager.LoadScene("Chem 6");
    }
    public void St11P_2()
    {
        SceneManager.LoadScene("demo11");
    }
    public void St11P_8()
    {
          SceneManager.LoadScene("demo12");
    }
    public void St11P_9()
    {
        SceneManager.LoadScene("demo13");
    }

    public void St11B_6()
    {
          SceneManager.LoadScene("demo14");
    }
    public void St11B_7()
    {
         SceneManager.LoadScene("demo15");
    }
    public void St11B_18()
    { 
        SceneManager.LoadScene("demo16");
    }

    /////////////// St 12.......
    // 
    public void St12C_1()
    {
        SceneManager.LoadScene("demo17");
    }
    public void St12C_2()
    {
        SceneManager.LoadScene("demo18");
    }
    public void St12P_4()
    {
          SceneManager.LoadScene("demo19");
    }
    public void St12P_6()
    {
        SceneManager.LoadScene("demo20");
    }
    public void St12B_2()
    {
        SceneManager.LoadScene("demo21");
    }
    public void St12B_2_2()
    {
         SceneManager.LoadScene("demo22");
    }
    public void St12B_16()
    {
         SceneManager.LoadScene("demo23");
    }
    public void St12B_16_2()
    {
         SceneManager.LoadScene("demo24");
    } 

    //Phy
        public void p1()
        {
            SceneManager.LoadScene("demo07");
        }
        public void p2()
        {
            SceneManager.LoadScene("demo11");
        }
        public void p3()
        {
            SceneManager.LoadScene("demo12");
        }
        public void p4()
        {
            SceneManager.LoadScene("demo24");
        }
        public void p5()
        {
            SceneManager.LoadScene("demo20");
        }
        public void p6()
        {
            SceneManager.LoadScene("demo25");
        }
    
        //Chem
        public void c1()
        {
            SceneManager.LoadScene("Chem 3");
        }
        public void c2()
        {
            SceneManager.LoadScene("demo05");
        }
        public void c3()
        {
            SceneManager.LoadScene("Chem 6");
        }
        public void c4()
        {
            SceneManager.LoadScene("demo09");
        }
        public void c5()
        {
            SceneManager.LoadScene("demo18");
        }
        public void c6()
        {
            SceneManager.LoadScene("demo17");
        }
        public void c7()
        {
            SceneManager.LoadScene("demo19");
        }
        public void c8()
        {
            SceneManager.LoadScene("demo03");
        }
    
        //Bio
        public void b1()
        {
            SceneManager.LoadScene("demo02");
        }
        public void b2()
        {
            SceneManager.LoadScene("Bio 2");
        }
        public void b3()
        {
            SceneManager.LoadScene("demo16");
        }
        public void b4()
        {
            SceneManager.LoadScene("demo14");
        }
        public void b5()
        {
            SceneManager.LoadScene("demo15");
        }
        public void b6()
        {
            SceneManager.LoadScene("demo21");
        }
        public void b7()
        {
            SceneManager.LoadScene("demo22");
        }
        public void b8()
        {
            SceneManager.LoadScene("demo23");
        }
        public void b9()
        {
            SceneManager.LoadScene("demo13");
        }
        public void b10()
        {
            SceneManager.LoadScene("demo01");
        }
        public void b11()
        {
            SceneManager.LoadScene("demo08");
        }

        public void e1()
        {
            SceneManager.LoadScene("Eng 1 Verify the Law of Equivalent Proportions");
        }
        public void e2()
        {
            SceneManager.LoadScene("Eng 2 Study of Frictional Force of a Pulley");
        }
        public void e3()
        {
            SceneManager.LoadScene("Eng 3 Identification of Acid and Base");
        }
        public void e4()
        {
            SceneManager.LoadScene("Eng 4 Heart");
        }
        public void e5()
        {
            SceneManager.LoadScene("Eng 5 Light – Reflection and Refraction");
        }
        public void e6()
        {
            SceneManager.LoadScene("Eng 6 Eye Defects and Their Correction");
        }
        public void e7()
        {
            SceneManager.LoadScene("Eng 7 Cuso4 na dravan ma nh2oh");
        }
        public void e8()
        {
            SceneManager.LoadScene("Eng 8 Cyclotron");
        }

        public void englishMenu()
        {
            SceneManager.LoadScene("Menu English");
        }
}
