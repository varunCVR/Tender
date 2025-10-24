using UnityEngine;
using TMPro;

public class StudentLogRowUI : MonoBehaviour
{
    public TMP_Text indexText;
    public TMP_Text nameText;
    public TMP_Text stdText;
    public TMP_Text rollText;
    public TMP_Text pracText;
    public TMP_Text dateText;
    public GameObject statusOK;    // green dot
    public GameObject statusPending; // optional red/grey

    public void Bind(int index, Queries.LogView v)
    {
        if (indexText) indexText.text = index.ToString() + ".";
        if (nameText) nameText.text = v.student_name;
        if (stdText) stdText.text = v.std_label;
        if (rollText) rollText.text = v.roll_no;
        if (pracText) pracText.text = v.practical_title;
        if (dateText) dateText.text = v.date_time;

        bool done = v.completion_status == "COMPLETED";
        if (statusOK) statusOK.SetActive(done);
        if (statusPending) statusPending.SetActive(!done);
    }
}
