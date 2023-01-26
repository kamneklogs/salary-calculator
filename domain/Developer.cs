namespace e05.domain;

public record Developer(
    string Name,
    DevType Type,
    int WorkedHours,
    decimal SalaryByHour // https://stackoverflow.com/questions/3730019/why-not-use-double-or-float-to-represent-currency/3730040#3730040
);