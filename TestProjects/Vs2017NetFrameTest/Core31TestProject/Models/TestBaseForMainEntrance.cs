using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public abstract class TestBaseForMainEntrance
    {
        public abstract void MainRun();
        public static bool CommonCompare<T>(T result, T expectation, ComparisonConfig comparisonConfig = null)
        {
            if (result == null && expectation == null) return true;

            var compare = comparisonConfig == null ? new CompareLogic() : new CompareLogic(comparisonConfig);
            ComparisonResult comparisonResult = compare.Compare(expectation, result);
            return comparisonResult.AreEqual;
        }
    }
}
