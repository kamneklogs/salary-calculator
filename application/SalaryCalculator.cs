using e05.domain;

namespace e05.application;
public class SalaryCalculator
{
    public static decimal CalculateSalary(Developer developer)
    {
        decimal BaseRule = developer.SalaryByHour * developer.WorkedHours;
        switch (developer.Type)
        {
            case DevType.Junior:
                break;
            case DevType.Intermediate:
                BaseRule *= 1.12m; // m is used to indicate that the number is decimal
                break;
            case DevType.Senior:
                BaseRule *= 1.25m;
                break;
            case DevType.Lead:
                BaseRule *= 1.5m;
                break;
            default:
                break;
        }
        return BaseRule;
    }
}