using NUnitPresentation.Calculator;

Calculator calculator = new();
int sum = calculator.Add(2, 3);

#pragma warning disable NUnit2045
Assert.That(sum, Is.EqualTo(5));
Assert.That(sum, Is.GreaterThan(4));
Assert.That(sum, Is.InRange(1, 10));
Assert.That(sum, Is.Positive);
Assert.That(calculator, Is.Not.Null);

Assert.Throws<DivideByZeroException>(() => calculator.Divide(1, 0));