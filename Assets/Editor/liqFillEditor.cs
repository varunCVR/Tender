using UnityEditor;

[CustomEditor(typeof(LiqfillEffect))]          // target script for changes on inspector
public class LiqfillEffectEditor : Editor
{
  #region ml_100_properties

  private SerializedProperty shaderRend;  // shaderRD
  private SerializedProperty callType;    // callmethod
  private SerializedProperty fillType;    // fillMethod

  private SerializedProperty liqfi;    //LiqMl
  // for numeric type
  private SerializedProperty fillNum100; // fillFloat_100ml
  private SerializedProperty fillNum250; // fillFloat_250ml
  private SerializedProperty fillNum500; // fillFloat_500ml
  
  // for numeric type
  private SerializedProperty liqFixPoint; // liqFillArea
  
  
  // color property
  private SerializedProperty coloBool;
  private SerializedProperty upColor;
  public SerializedProperty desiredCol;
  
  
  #endregion

  private void OnEnable()
  {
      shaderRend = serializedObject.FindProperty("shaderRD");
      callType = serializedObject.FindProperty("callmethod");
      fillType = serializedObject.FindProperty("fillMethod");
      liqfi = serializedObject.FindProperty("bickerSize");
      fillNum100 = serializedObject.FindProperty("fillFloat_100ml");
      fillNum250 = serializedObject.FindProperty("fillFloat_250ml");
      fillNum500 = serializedObject.FindProperty("fillFloat_500ml");

      liqFixPoint = serializedObject.FindProperty("liqFillArea");

      coloBool = serializedObject.FindProperty("ColorChange");
      upColor = serializedObject.FindProperty("updateColor");
      desiredCol = serializedObject.FindProperty("desiredColor");
  }

  public override void OnInspectorGUI()
  {
      LiqfillEffect liqPop = (LiqfillEffect)target;
      serializedObject.Update();
      EditorGUILayout.PropertyField(shaderRend);
          if (liqPop.shaderRD != null)  
          {
              EditorGUILayout.PropertyField(liqfi);

              EditorGUILayout.PropertyField(callType);
              EditorGUILayout.Space();
              EditorGUILayout.PropertyField(fillType);

              if (liqPop.bickerSize == LiqfillEffect.downer.ml_500)
              {
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Autometic) {
                      EditorGUILayout.PropertyField(liqFixPoint);
                  }
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Numerical) {
                      EditorGUILayout.PropertyField(fillNum500);
                  }
              }
              if (liqPop.bickerSize == LiqfillEffect.downer.ml_250)
              {
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Autometic) {
                      EditorGUILayout.PropertyField(liqFixPoint);
                  }
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Numerical) {
                      EditorGUILayout.PropertyField(fillNum250);
                  }
              }
              if (liqPop.bickerSize == LiqfillEffect.downer.ml_100)
              {  
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Autometic) {
                      EditorGUILayout.PropertyField(liqFixPoint);
                  }
                  if (liqPop.fillMethod == LiqfillEffect.fillType.Numerical) {
                      EditorGUILayout.PropertyField(fillNum100);
                  }
              } 
              
              EditorGUILayout.Space();
              EditorGUILayout.PropertyField(coloBool);
              if (liqPop.ColorChange)
              {
                  EditorGUILayout.PropertyField(upColor);
                  EditorGUILayout.PropertyField(desiredCol);
              }

          }                 
          serializedObject.ApplyModifiedProperties();
  }
}
