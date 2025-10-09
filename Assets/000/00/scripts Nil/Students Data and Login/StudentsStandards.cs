
using System.Collections.Generic;

[System.Serializable]
public class StudentsStandards
{
   public List<string> studentsName;
   public List<int> studentsRollnumbers;

   public StudentsStandards(List<string> someStrings,List<int> someInts)
   {
      this.studentsName = someStrings;
      this.studentsRollnumbers = studentsRollnumbers;
   }
}
