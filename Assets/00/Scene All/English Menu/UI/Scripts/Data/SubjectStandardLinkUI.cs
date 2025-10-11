using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class SubjectStandardLinkUI : MonoBehaviour
{
    public TMP_Dropdown subjectDropdown;
    public TMP_Dropdown standardDropdown;
    public Button linkBtn, unlinkBtn;

    List<Subject> _subs;
    List<Standard> _stds;

    void OnEnable() { LoadOptions(); Wire(); }

    void Wire() {
        linkBtn.onClick.RemoveAllListeners();
        unlinkBtn.onClick.RemoveAllListeners();

        linkBtn.onClick.AddListener(() => {
            if (_subs.Count==0 || _stds.Count==0) return;
            var subId = _subs[subjectDropdown.value].subject_id;
            var stdId = _stds[standardDropdown.value].std_id;
            Queries.AddSubjectStandard(subId, stdId);
        });

        unlinkBtn.onClick.AddListener(() => {
            if (_subs.Count==0 || _stds.Count==0) return;
            var subId = _subs[subjectDropdown.value].subject_id;
            var stdId = _stds[standardDropdown.value].std_id;
            Queries.DeleteSubjectStandard(subId, stdId);
        });
    }

    void LoadOptions() {
        _subs = Queries.GetSubjects();
        _stds = Queries.GetStandards();
        subjectDropdown.options = _subs.Select(s => new TMP_Dropdown.OptionData($"{s.subject_name}")).ToList();
        standardDropdown.options = _stds.Select(s => new TMP_Dropdown.OptionData($"{s.std_num}")).ToList();
        subjectDropdown.value = 0; standardDropdown.value = 0;
        subjectDropdown.RefreshShownValue(); standardDropdown.RefreshShownValue();
    }
}
