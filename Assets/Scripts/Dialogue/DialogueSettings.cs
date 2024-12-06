using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]

public class DialogueSettings : ScriptableObject

{
    [Header("Settings")]
    public GameObject actor;
    [Header("Dialogue")]

    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]

public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
}

#if UNITY_EDITOR

[CustomEditor(typeof (DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;


        Languages lg = new Languages();
        lg.portuguese = ds.sentence;

        Sentences st = new Sentences();
        st.profile = ds.speakerSprite;
        st.sentence = lg;

       if (GUILayout.Button ("Create Dialogue"))
        {
            if(ds.sentence !="")
            {
                ds.dialogues.Add(st);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
       
    }
}




#endif