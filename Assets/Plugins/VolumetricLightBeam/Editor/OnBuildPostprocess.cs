#if UNITY_EDITOR && UNITY_2018_1_OR_NEWER
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

internal class OnBuildPostprocess : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPostprocessBuild(BuildReport report)
    {
        VLB.PlatformHelper.SetBuildTargetOverride(BuildTarget.NoTarget);
    }
}
#endif