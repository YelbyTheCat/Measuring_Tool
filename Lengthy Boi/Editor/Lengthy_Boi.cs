using UnityEngine;
using UnityEditor;

public class Lengthy_Boi : EditorWindow
{
    //Attributes
    private GameObject obj1;
    private GameObject obj2;
    private float distance = 0;
    private float feet = 0;
    private float inches = 0;

    [MenuItem("Yelby/Lengthy Boi")]
    public static void ShowWindow()
    {
        GetWindow<Lengthy_Boi>("Lengthy Boi");
    }

    private void Awake(){spawnPoints();}

    private void OnDestroy(){removePoints();}

    private void Update(){distance = getDistance();}

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.white;

        GUILayout.Label(" Metric: " + distance.ToString("0.###") + "m",myStyle);
        GUILayout.Label(" Imperial: " + feet.ToString("0") + "' " + inches.ToString("0.###") + "\"",myStyle);

        if (GUILayout.Button("Manual Update"))
        {
            getDistance();
        }
    }
    //~~~~Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    void spawnPoints()
    {
        if(GameObject.Find("Position 1") == null)
        {
            obj1 = new GameObject();
            obj1.name = "Position 1";
        }

        if (GameObject.Find("Position 2") == null)
        {
            obj2 = new GameObject();
            obj2.name = "Position 2";
        }
    }

    void removePoints()
    {
        DestroyImmediate(obj1);
        DestroyImmediate(obj2);
    }

    float getDistance()
    {
        float distance = 0;
        if(GameObject.Find("Position 1") != null && GameObject.Find("Position 2") != null)
        {
            Vector3 pos1 = obj1.transform.position;
            Vector3 pos2 = obj2.transform.position;

            distance = Mathf.Pow(
                       Mathf.Pow(pos2.x - pos1.x, 2) 
                     + Mathf.Pow(pos2.y - pos1.y, 2) 
                     + Mathf.Pow(pos2.z - pos1.z, 2),
                       0.5f);
        }
        convertMeter2Feet();
        return distance;
    }

    void convertMeter2Feet()
    {
        float temp = distance / 0.0254f;
        feet = Mathf.Floor(temp / 12);
        inches = temp - 12 * feet;
    }
}