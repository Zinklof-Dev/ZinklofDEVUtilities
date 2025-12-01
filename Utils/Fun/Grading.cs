using System;
using System.Collections.Generic;
using System.Text;

namespace ZinklofDev.Utils.Fun
{
    static class Grading // this is so poorly written but it was entirely for a one off thing so i guess its passable lmfao - zink december 2025 (a year later?)
    {
        /// <summary>
        /// Goofy way to grade things
        /// </summary>
        /// <param name="percentage">0-100 percentage you scored</param>
        /// <returns></returns>
        public static string ZinkScale(double percentage)
        {
            string gradeValue = "";

            if (percentage > 100) { gradeValue = "You Broke The Scale!"; }
            else if (percentage == 100) { gradeValue = "S"; }
            else if (percentage >= 97) { gradeValue = "A+"; }
            else if (percentage >= 93) { gradeValue = "A"; }
            else if (percentage >= 90) { gradeValue = "A-"; }
            else if (percentage >= 87) { gradeValue = "B+"; }
            else if (percentage >= 83) { gradeValue = "B"; }
            else if (percentage >= 80) { gradeValue = "B-"; }
            else if (percentage >= 77) { gradeValue = "C+"; }
            else if (percentage >= 73) { gradeValue = "C"; }
            else if (percentage >= 70) { gradeValue = "C-"; }
            else if (percentage >= 67) { gradeValue = "D+"; }
            else if (percentage >= 63) { gradeValue = "D"; }
            else if (percentage >= 60) { gradeValue = "D-"; }
            else if (percentage >= 57) { gradeValue = "E+"; }
            else if (percentage >= 53) { gradeValue = "E"; }
            else if (percentage >= 50) { gradeValue = "E-"; }
            else if (percentage >= 47) { gradeValue = "F+"; }
            else if (percentage >= 43) { gradeValue = "F"; }
            else if (percentage >= 40) { gradeValue = "F-"; }
            else if (percentage >= 30) { gradeValue = "This Is Unnaceptable"; }
            else if (percentage >= 20) { gradeValue = "You've Disapointed Me"; }
            else if (percentage >= 10) { gradeValue = "Uncomprehensibly Bad, Be Ashamed of Yourself!"; }
            else if (percentage >= 0) { gradeValue = "Just... How?"; }
            else if (percentage < 0) { gradeValue = "Negative? I Know Where You Live."; }

            return gradeValue;
        }
    }
}
