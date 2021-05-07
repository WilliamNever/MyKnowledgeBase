using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public abstract class TestBaseForMainEntrance
    {
        public abstract void MainRun();
        public static bool CommonCompare<T>(T expectation, T result, ComparisonConfig comparisonConfig = null)
        {
            return CommonCompareResult(expectation, result, comparisonConfig).AreEqual;
        }
        public static ComparisonResult CommonCompareResult<T>(T expectation, T result, ComparisonConfig comparisonConfig = null)
        {
            var compare = comparisonConfig == null ? new CompareLogic() : new CompareLogic(comparisonConfig);
            ComparisonResult comparisonResult = compare.Compare(expectation, result);
            return comparisonResult;
        }
    }
}
