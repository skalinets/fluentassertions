using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public class NumericAssertionSpecs
{
    public class BePositiveOrNegative
    {
        [Fact]
        public void When_a_positive_value_is_positive_it_should_not_throw()
        {
            // Arrange
            float value = 1F;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_negative_value_is_positive_it_should_throw()
        {
            // Arrange
            double value = -1D;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_zero_value_is_positive_it_should_throw()
        {
            // Arrange
            int value = 0;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void NaN_is_never_a_positive_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }

        [Fact]
        public void NaN_is_never_a_positive_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }

        [Fact]
        public void When_a_negative_value_is_positive_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = -1;

            // Act
            Action act = () => value.Should().BePositive("because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be positive because we want to test the failure message, but found -1.");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_positive_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void When_a_negative_value_is_negative_it_should_not_throw()
        {
            // Arrange
            int value = -1;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_positive_value_is_negative_it_should_throw()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_zero_value_is_negative_it_should_throw()
        {
            // Arrange
            int value = 0;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_positive_value_is_negative_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => value.Should().BeNegative("because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be negative because we want to test the failure message, but found 1.");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_negative_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void NaN_is_never_a_negative_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }

        [Fact]
        public void NaN_is_never_a_negative_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }
    }

    public class Be
    {
        [Fact]
        public void A_value_is_equal_to_the_same_value()
        {
            // Arrange
            int value = 1;
            int sameValue = 1;

            // Act
            value.Should().Be(sameValue);
        }

        [Fact]
        public void A_value_is_not_equal_to_another_value()
        {
            // Arrange
            int value = 1;
            int differentValue = 2;

            // Act
            Action act = () => value.Should().Be(differentValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be 2 because we want to test the failure message, but found 1.");
        }

        [Fact]
        public void A_value_is_equal_to_the_same_nullable_value()
        {
            // Arrange
            int value = 2;
            int? nullableValue = 2;

            // Act
            value.Should().Be(nullableValue);
        }

        [Fact]
        public void A_value_is_not_equal_to_null()
        {
            // Arrange
            int value = 2;
            int? nullableValue = null;

            // Act
            Action act = () => value.Should().Be(nullableValue);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected*<null>, but found 2.");
        }

        [Fact]
        public void Null_is_not_equal_to_another_nullable_value()
        {
            // Arrange
            int? value = 2;

            // Act
            Action action = () => ((int?)null).Should().Be(value);

            // Assert
            action
                .Should().Throw<XunitException>()
                .WithMessage("Expected*2, but found <null>.");
        }

        [InlineData(1, 2)]
        [InlineData(null, 2)]
        [Theory]
        public void A_nullable_value_is_not_equal_to_another_value(int? subject, int unexpected)
        {
            // Act
            subject.Should().NotBe(unexpected);
        }

        [Fact]
        public void A_value_is_not_different_from_the_same_value()
        {
            // Arrange
            int value = 1;
            int sameValue = 1;

            // Act
            Action act = () => value.Should().NotBe(sameValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Did not expect value to be 1 because we want to test the failure message.");
        }

        [InlineData(null, null)]
        [InlineData(0, 0)]
        [Theory]
        public void A_nullable_value_is_not_different_from_the_same_value(int? subject, int? unexpected)
        {
            // Act
            Action act = () => subject.Should().NotBe(unexpected);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [InlineData(0, 1)]
        [InlineData(0, null)]
        [InlineData(null, 0)]
        [Theory]
        public void A_nullable_value_is_different_from_another_value(int? subject, int? unexpected)
        {
            // Act / Assert
            subject.Should().NotBe(unexpected);
        }

        [InlineData(0, 0)]
        [InlineData(null, null)]
        [Theory]
        public void A_nullable_value_is_equal_to_the_same_nullable_value(int? subject, int? expected)
        {
            // Act / Assert
            subject.Should().Be(expected);
        }

        [InlineData(0, 1)]
        [InlineData(0, null)]
        [InlineData(null, 0)]
        [Theory]
        public void A_nullable_value_is_not_equal_to_another_nullable_value(int? subject, int? expected)
        {
            // Act
            Action act = () => subject.Should().Be(expected);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Null_is_not_equal_to_another_value()
        {
            // Arrange
            int? subject = null;
            int expected = 1;

            // Act
            Action act = () => subject.Should().Be(expected);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_asserting_that_a_float_value_is_equal_to_a_different_value_it_should_throw()
        {
            // Arrange
            float value = 3.5F;

            // Act
            Action act = () => value.Should().Be(3.4F, "we want to test the error message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be *3.4* because we want to test the error message, but found *3.5*");
        }

        [Fact]
        public void When_asserting_that_a_float_value_is_equal_to_the_same_value_it_should_not_throw()
        {
            // Arrange
            float value = 3.5F;

            // Act
            Action act = () => value.Should().Be(3.5F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_that_a_null_float_value_is_equal_to_some_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().Be(3.5F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be *3.5* but found <null>.");
        }

        [Fact]
        public void When_asserting_that_a_double_value_is_equal_to_a_different_value_it_should_throw()
        {
            // Arrange
            double value = 3.5;

            // Act
            Action act = () => value.Should().Be(3.4, "we want to test the error message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be 3.4 because we want to test the error message, but found 3.5*.");
        }

        [Fact]
        public void When_asserting_that_a_double_value_is_equal_to_the_same_value_it_should_not_throw()
        {
            // Arrange
            double value = 3.5;

            // Act
            Action act = () => value.Should().Be(3.5);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_that_a_null_double_value_is_equal_to_some_value_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () => value.Should().Be(3.5);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be 3.5, but found <null>.");
        }

        [Fact]
        public void When_asserting_that_a_decimal_value_is_equal_to_a_different_value_it_should_throw()
        {
            // Arrange
            decimal value = 3.5m;

            // Act
            Action act = () => value.Should().Be(3.4m, "we want to test the error message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be*3.4* because we want to test the error message, but found*3.5*");
        }

        [Fact]
        public void When_asserting_that_a_decimal_value_is_equal_to_the_same_value_it_should_not_throw()
        {
            // Arrange
            decimal value = 3.5m;

            // Act
            Action act = () => value.Should().Be(3.5m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_that_a_null_decimal_value_is_equal_to_some_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;
            decimal someValue = 3.5m;

            // Act
            Action act = () => value.Should().Be(someValue);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be*3.5*, but found <null>.");
        }

        [Fact]
        public void Nan_is_never_equal_to_a_normal_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().Be(3.4F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be *3.4F, but found NaN*");
        }

        [Fact]
        public void NaN_can_be_compared_to_NaN_when_its_a_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            value.Should().Be(float.NaN);
        }

        [Fact]
        public void Nan_is_never_equal_to_a_normal_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().Be(3.4D);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be *3.4, but found NaN*");
        }

        [Fact]
        public void NaN_can_be_compared_to_NaN_when_its_a_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            value.Should().Be(double.NaN);
        }
    }

    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public void When_a_value_is_greater_than_smaller_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => value.Should().BeGreaterThan(smallerValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_greater_than_greater_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () => value.Should().BeGreaterThan(greaterValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_greater_than_same_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => value.Should().BeGreaterThan(sameValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_greater_than_greater_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () =>
                value.Should().BeGreaterThan(greaterValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be greater than 3 because we want to test the failure message, but found 2.");
        }

        [Fact]
        public void NaN_is_never_greater_than_another_float()
        {
            // Act
            Action act = () => float.NaN.Should().BeGreaterThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_cannot_be_greater_than_NaN()
        {
            // Act
            Action act = () => 3.4F.Should().BeGreaterThan(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_than_another_double()
        {
            // Act
            Action act = () => double.NaN.Should().BeGreaterThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_greater_than_NaN()
        {
            // Act
            Action act = () => 3.4D.Should().BeGreaterThan(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_a_value_is_greater_than_or_equal_to_smaller_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(smallerValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_greater_than_or_equal_to_same_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(sameValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_greater_than_or_equal_to_greater_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(greaterValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_greater_than_or_equal_to_greater_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act =
                () => value.Should()
                    .BeGreaterThanOrEqualTo(greaterValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be greater than or equal to 3 because we want to test the failure message, but found 2.");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_greater_than_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeGreaterThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_greater_than_or_equal_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void NaN_is_never_greater_than_or_equal_to_another_float()
        {
            // Act
            Action act = () => float.NaN.Should().BeGreaterThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_cannot_be_greater_than_or_equal_to_NaN()
        {
            // Act
            Action act = () => 3.4F.Should().BeGreaterThanOrEqualTo(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_or_equal_to_another_double()
        {
            // Act
            Action act = () => double.NaN.Should().BeGreaterThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_greater_or_equal_to_NaN()
        {
            // Act
            Action act = () => 3.4D.Should().BeGreaterThanOrEqualTo(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }
    }

    public class LessThanOrEqualTo
    {
        [Fact]
        public void When_a_value_is_less_than_greater_value_it_should_not_throw()
        {
            // Arrange
            int value = 1;
            int greaterValue = 2;

            // Act
            Action act = () => value.Should().BeLessThan(greaterValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_less_than_smaller_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => value.Should().BeLessThan(smallerValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_less_than_same_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => value.Should().BeLessThan(sameValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_less_than_smaller_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => value.Should().BeLessThan(smallerValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be less than 1 because we want to test the failure message, but found 2.");
        }

        [Fact]
        public void NaN_is_never_less_than_another_float()
        {
            // Act
            Action act = () => float.NaN.Should().BeLessThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_can_never_be_less_than_NaN()
        {
            // Act
            Action act = () => 3.4F.Should().BeLessThan(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_another_double()
        {
            // Act
            Action act = () => double.NaN.Should().BeLessThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_less_than_NaN()
        {
            // Act
            Action act = () => 3.4D.Should().BeLessThan(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_a_value_is_less_than_or_equal_to_greater_value_it_should_not_throw()
        {
            // Arrange
            int value = 1;
            int greaterValue = 2;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(greaterValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_less_than_or_equal_to_same_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(sameValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_value_is_less_than_or_equal_to_smaller_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(smallerValue);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_value_is_less_than_or_equal_to_smaller_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () =>
                value.Should().BeLessThanOrEqualTo(smallerValue, "because we want to test the failure {0}", "message");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be less than or equal to 1 because we want to test the failure message, but found 2.");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_less_than_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeLessThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_less_than_or_equal_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void NaN_is_never_less_than_or_equal_to_another_float()
        {
            // Act
            Action act = () => float.NaN.Should().BeLessThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_can_never_be_less_than_or_equal_to_NaN()
        {
            // Act
            Action act = () => 3.4F.Should().BeLessThanOrEqualTo(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_or_equal_to_another_double()
        {
            // Act
            Action act = () => double.NaN.Should().BeLessThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_less_than_or_equal_to_NaN()
        {
            // Act
            Action act = () => 3.4D.Should().BeLessThanOrEqualTo(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }
    }

    public class InRange
    {
        [Fact]
        public void When_a_value_is_outside_a_range_it_should_throw()
        {
            // Arrange
            float value = 3.99F;

            // Act
            Action act = () => value.Should().BeInRange(4, 5, "because that's the valid range");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be between*4* and*5* because that\'s the valid range, but found*3.99*");
        }

        [Fact]
        public void When_a_value_is_inside_a_range_it_should_not_throw()
        {
            // Arrange
            int value = 4;

            // Act
            Action act = () => value.Should().BeInRange(3, 5);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_in_range_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeInRange(0, 1);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void NaN_is_never_in_range_of_two_floats()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BeInRange(4, 5);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be between*4* and*5*, but found*NaN*");
        }

        [Theory]
        [InlineData(float.NaN, 5F)]
        [InlineData(5F, float.NaN)]
        public void A_float_can_never_be_in_a_range_containing_NaN(float minimumValue, float maximumValue)
        {
            // Arrange
            float value = 4.5F;

            // Act
            Action act = () => value.Should().BeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage(
                    "*NaN*");
        }

        [Fact]
        public void A_NaN_is_never_in_range_of_two_doubles()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BeInRange(4, 5);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be between*4* and*5*, but found*NaN*");
        }

        [Theory]
        [InlineData(double.NaN, 5)]
        [InlineData(5, double.NaN)]
        public void A_double_can_never_be_in_a_range_containing_NaN(double minimumValue, double maximumValue)
        {
            // Arrange
            double value = 4.5D;

            // Act
            Action act = () => value.Should().BeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage(
                    "*NaN*");
        }
    }

    public class NotInRange
    {
        [Fact]
        public void When_a_value_is_inside_an_unexpected_range_it_should_throw()
        {
            // Arrange
            float value = 4.99F;

            // Act
            Action act = () => value.Should().NotBeInRange(4, 5, "because that's the invalid range");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to not be between*4* and*5* because that\'s the invalid range, but found*4.99*");
        }

        [Fact]
        public void When_a_value_is_outside_an_unexpected_range_it_should_not_throw()
        {
            // Arrange
            float value = 3.99F;

            // Act
            Action act = () => value.Should().NotBeInRange(4, 5);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_not_in_range_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().NotBeInRange(0, 1);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void NaN_is_never_inside_any_range_of_floats()
        {
            // Arrange
            float value = float.NaN;

            // Act / Assert
            value.Should().NotBeInRange(4, 5);
        }

        [Theory]
        [InlineData(float.NaN, 1F)]
        [InlineData(1F, float.NaN)]
        public void Cannot_use_NaN_in_a_range_of_floats(float minimumValue, float maximumValue)
        {
            // Arrange
            float value = 4.5F;

            // Act
            Action act = () => value.Should().NotBeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_inside_any_range_of_doubles()
        {
            // Arrange
            double value = double.NaN;

            // Act / Assert
            value.Should().NotBeInRange(4, 5);
        }

        [Theory]
        [InlineData(double.NaN, 1D)]
        [InlineData(1D, double.NaN)]
        public void Cannot_use_NaN_in_a_range_of_doubles(double minimumValue, double maximumValue)
        {
            // Arrange
            double value = 4.5D;

            // Act
            Action act = () => value.Should().NotBeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }
    }

    public class BeOneOf
    {
        [Fact]
        public void When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            int value = 3;

            // Act
            Action act = () => value.Should().BeOneOf(4, 5);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be one of {4, 5}, but found 3.");
        }

        [Fact]
        public void When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 3;

            // Act
            Action act = () => value.Should().BeOneOf(new[] { 4, 5 }, "because those are the valid values");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to be one of {4, 5} because those are the valid values, but found 3.");
        }

        [Fact]
        public void When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            int value = 4;

            // Act
            Action act = () => value.Should().BeOneOf(4, 5);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_nullable_numeric_null_value_is_not_one_of_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => value.Should().BeOneOf(0, 1);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*null*");
        }

        [Fact]
        public void Two_floats_that_are_NaN_can_be_compared()
        {
            // Arrange
            float value = float.NaN;

            // Act / Assert
            value.Should().BeOneOf(float.NaN, 4.5F);
        }

        [Fact]
        public void Floats_are_never_equal_to_NaN()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BeOneOf(1.5F, 4.5F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected*1.5F*found*NaN*");
        }

        [Fact]
        public void Two_doubles_that_are_NaN_can_be_compared()
        {
            // Arrange
            double value = double.NaN;

            // Act / Assert
            value.Should().BeOneOf(double.NaN, 4.5F);
        }

        [Fact]
        public void Doubles_are_never_equal_to_NaN()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BeOneOf(1.5D, 4.5D);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected*1.5*found NaN*");
        }
    }

    public class Bytes
    {
        [Fact]
        public void When_asserting_a_byte_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            byte value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_sbyte_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            sbyte value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_short_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            short value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_an_ushort_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            ushort value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_an_uint_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            uint value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_long_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            long value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_an_ulong_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            ulong value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class NullableBytes
    {
        [Fact]
        public void When_asserting_a_nullable_byte_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            byte? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_sbyte_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            sbyte? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_short_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            short? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_ushort_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            ushort? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_uint_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            uint? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_long_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            long? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_a_nullable_nullable_ulong_value_it_should_treat_is_any_numeric_value()
        {
            // Arrange
            ulong? value = 2;

            // Act
            Action act = () => value.Should().Be(2);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class BeApproximately
    {
        [Fact]
        public void When_approximating_a_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_float_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.001F, "rockets will crash otherwise");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to approximate *3.14* +/- *0.001* because rockets will crash otherwise, but *3.1415927* differed by *0.001592*");
        }

        [Fact]
        public void When_float_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public void When_float_is_approximating_a_value_on_boundaries_it_should_not_throw(float value)
        {
            // Act
            Action act = () => value.Should().BeApproximately(10F, 1F);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public void When_float_is_not_approximating_a_value_on_boundaries_it_should_throw(float value)
        {
            // Act
            Action act = () => value.Should().BeApproximately(10F, 0.9F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_approximating_a_float_towards_nan_it_should_not_throw()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_approximating_positive_infinity_float_towards_positive_infinity_it_should_not_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(float.PositiveInfinity, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_approximating_negative_infinity_float_towards_negative_infinity_it_should_not_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(float.NegativeInfinity, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_float_is_not_approximating_positive_infinity_it_should_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(float.MaxValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_float_is_not_approximating_negative_infinity_it_should_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(float.MinValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void NaN_can_never_be_close_to_any_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().BeApproximately(float.MinValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_can_never_be_close_to_NaN()
        {
            // Arrange
            float value = float.MinValue;

            // Act
            Action act = () => value.Should().BeApproximately(float.NaN, 0.1F);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("*NaN*");
        }

        [Fact]
        public void When_a_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.001F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to approximate*3.14* +/-*0.001*, but it was <null>.");
        }

        [Fact]
        public void When_approximating_a_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().BeApproximately(3.14, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_double_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().BeApproximately(3.14, 0.001, "rockets will crash otherwise");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to approximate 3.14 +/- 0.001 because rockets will crash otherwise, but 3.1415927 differed by 0.001592*");
        }

        [Fact]
        public void When_double_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().BeApproximately(3.14, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_approximating_a_double_towards_nan_it_should_not_throw()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_approximating_positive_infinity_double_towards_positive_infinity_it_should_not_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(double.PositiveInfinity, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_approximating_negative_infinity_double_towards_negative_infinity_it_should_not_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(double.NegativeInfinity, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_double_is_not_approximating_positive_infinity_it_should_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(double.MaxValue, 0.1);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_double_is_not_approximating_negative_infinity_it_should_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().BeApproximately(double.MinValue, 0.1);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public void When_double_is_approximating_a_value_on_boundaries_it_should_not_throw(double value)
        {
            // Act
            Action act = () => value.Should().BeApproximately(10D, 1D);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public void When_double_is_not_approximating_a_value_on_boundaries_it_should_throw(double value)
        {
            // Act
            Action act = () => value.Should().BeApproximately(10D, 0.9D);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void NaN_can_never_be_close_to_any_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().BeApproximately(double.MinValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void A_double_can_never_be_close_to_NaN()
        {
            // Arrange
            double value = double.MinValue;

            // Act
            Action act = () => value.Should().BeApproximately(double.NaN, 0.1F);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void When_approximating_a_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal value = 3.1415927M;

            // Act
            Action act = () => value.Should().BeApproximately(3.14m, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().BeApproximately(3.5m, 0.001m, "rockets will crash otherwise");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate*3.5* +/-*0.001* because rockets will crash otherwise, but *3.5011* differed by*0.0011*");
        }

        [Fact]
        public void When_decimal_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().BeApproximately(3.5m, 0.01m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_approximating_a_value_on_lower_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().BeApproximately(10m, 1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_approximating_a_value_on_upper_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().BeApproximately(10m, 1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_value_on_lower_boundary_it_should_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().BeApproximately(10m, 0.9m);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_value_on_upper_boundary_it_should_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().BeApproximately(10m, 0.9m);

            // Assert
            act.Should().Throw<XunitException>();
        }
    }

    public class NotBeApproximately
    {
        [Fact]
        public void When_not_approximating_a_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_float_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F, "rockets will crash otherwise");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to not approximate *3.14* +/- *0.1* because rockets will crash otherwise, but *3.1415927* only differed by *0.001592*");
        }

        [Fact]
        public void When_float_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_approximating_a_float_towards_nan_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_not_approximating_a_float_towards_positive_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MaxValue, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_not_approximating_a_float_towards_negative_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MinValue, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_approximating_positive_infinity_float_towards_positive_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.PositiveInfinity, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void
            When_not_approximating_negative_infinity_float_towards_negative_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NegativeInfinity, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public void When_float_is_not_approximating_a_value_on_boundaries_it_should_not_throw(float value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10F, 0.9F);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public void When_float_is_approximating_a_value_on_boundaries_it_should_throw(float value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10F, 1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_nullable_float_has_no_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void NaN_can_never_be_close_to_any_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MinValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*NaN*");
        }

        [Fact]
        public void A_float_can_never_be_close_to_NaN()
        {
            // Arrange
            float value = float.MinValue;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NaN, 0.1F);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("*NaN*");
        }

        [Fact]
        public void When_not_approximating_a_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_double_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1, "rockets will crash otherwise");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to not approximate *3.14* +/- *0.1* because rockets will crash otherwise, but *3.1415927* only differed by *0.001592*");
        }

        [Fact]
        public void When_double_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_approximating_a_double_towards_nan_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_not_approximating_a_double_towards_positive_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MaxValue, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_not_approximating_a_double_towards_negative_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MinValue, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_approximating_positive_infinity_double_towards_positive_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.PositiveInfinity, 0.1);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void
            When_not_approximating_negative_infinity_double_towards_negative_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NegativeInfinity, 0.1);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_nullable_double_has_no_value_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public void When_double_is_not_approximating_a_value_on_boundaries_it_should_not_throw(double value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10D, 0.9D);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public void When_double_is_approximating_a_value_on_boundaries_it_should_throw(double value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10D, 1D);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void NaN_can_never_be_close_to_any_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MinValue, 0.1F);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_close_to_NaN()
        {
            // Arrange
            double value = double.MinValue;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NaN, 0.1F);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("*NaN*");
        }

        [Fact]
        public void When_not_approximating_a_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_decimal_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.1m, "rockets will crash otherwise");

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to not approximate *3.5* +/- *0.1* because rockets will crash otherwise, but *3.5011* only differed by *0.0011*");
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.001m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_nullable_decimal_has_no_value_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.001m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_value_on_lower_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 0.9m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_not_approximating_a_value_on_upper_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 0.9m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_decimal_is_approximating_a_value_on_lower_boundary_it_should_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 1m);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_decimal_is_approximating_a_value_on_upper_boundary_it_should_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 1m);

            // Assert
            act.Should().Throw<XunitException>();
        }
    }

    public class CloseTo
    {
        [InlineData(sbyte.MinValue, sbyte.MinValue, 0)]
        [InlineData(sbyte.MinValue, sbyte.MinValue, 1)]
        [InlineData(sbyte.MinValue, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, sbyte.MinValue + 1, 1)]
        [InlineData(sbyte.MinValue, sbyte.MinValue + 1, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, -1, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue + 1, sbyte.MinValue, 1)]
        [InlineData(sbyte.MinValue + 1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue + 1, 0, sbyte.MaxValue)]
        [InlineData(-1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, sbyte.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, sbyte.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, sbyte.MaxValue)]
        [InlineData(0, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(0, sbyte.MinValue + 1, sbyte.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, sbyte.MaxValue)]
        [InlineData(1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue - 1, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MaxValue - 1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, 0, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, 1, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, 0)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue - 1, 1)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue - 1, sbyte.MaxValue)]
        [Theory]
        public void When_a_sbyte_value_is_close_to_expected_value_it_should_succeed(sbyte actual, sbyte nearbyValue,
            byte delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(sbyte.MinValue, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MinValue, 0, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, 1, sbyte.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(0, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MinValue, 1)]
        [InlineData(sbyte.MaxValue, -1, sbyte.MaxValue)]
        [Theory]
        public void When_a_sbyte_value_is_not_close_to_expected_value_it_should_fail(sbyte actual, sbyte nearbyValue,
            byte delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_sbyte_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            sbyte actual = 1;
            sbyte nearbyValue = 4;
            byte delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_a_sbyte_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            sbyte actual = sbyte.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(short.MinValue, short.MinValue, 0)]
        [InlineData(short.MinValue, short.MinValue, 1)]
        [InlineData(short.MinValue, short.MinValue, short.MaxValue)]
        [InlineData(short.MinValue, short.MinValue + 1, 1)]
        [InlineData(short.MinValue, short.MinValue + 1, short.MaxValue)]
        [InlineData(short.MinValue, -1, short.MaxValue)]
        [InlineData(short.MinValue + 1, short.MinValue, 1)]
        [InlineData(short.MinValue + 1, short.MinValue, short.MaxValue)]
        [InlineData(short.MinValue + 1, 0, short.MaxValue)]
        [InlineData(-1, short.MinValue, short.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, short.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, short.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, short.MaxValue)]
        [InlineData(0, short.MaxValue, short.MaxValue)]
        [InlineData(0, short.MinValue + 1, short.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, short.MaxValue)]
        [InlineData(1, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue - 1, short.MaxValue, 1)]
        [InlineData(short.MaxValue - 1, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue, 0, short.MaxValue)]
        [InlineData(short.MaxValue, 1, short.MaxValue)]
        [InlineData(short.MaxValue, short.MaxValue, 0)]
        [InlineData(short.MaxValue, short.MaxValue, 1)]
        [InlineData(short.MaxValue, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue, short.MaxValue - 1, 1)]
        [InlineData(short.MaxValue, short.MaxValue - 1, short.MaxValue)]
        [Theory]
        public void When_a_short_value_is_close_to_expected_value_it_should_succeed(short actual, short nearbyValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(short.MinValue, short.MaxValue, 1)]
        [InlineData(short.MinValue, 0, short.MaxValue)]
        [InlineData(short.MinValue, 1, short.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, short.MaxValue, short.MaxValue)]
        [InlineData(0, short.MinValue, short.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, short.MinValue, short.MaxValue)]
        [InlineData(short.MaxValue, short.MinValue, 1)]
        [InlineData(short.MaxValue, -1, short.MaxValue)]
        [Theory]
        public void When_a_short_value_is_not_close_to_expected_value_it_should_fail(short actual, short nearbyValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_short_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            short actual = 1;
            short nearbyValue = 4;
            ushort delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_a_short_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            short actual = short.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(int.MinValue, int.MinValue, 0)]
        [InlineData(int.MinValue, int.MinValue, 1)]
        [InlineData(int.MinValue, int.MinValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue + 1, 1)]
        [InlineData(int.MinValue, int.MinValue + 1, int.MaxValue)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        [InlineData(int.MinValue + 1, int.MinValue, 1)]
        [InlineData(int.MinValue + 1, int.MinValue, int.MaxValue)]
        [InlineData(int.MinValue + 1, 0, int.MaxValue)]
        [InlineData(-1, int.MinValue, int.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, int.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, int.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, int.MaxValue)]
        [InlineData(0, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue + 1, int.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, int.MaxValue)]
        [InlineData(1, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue - 1, int.MaxValue, 1)]
        [InlineData(int.MaxValue - 1, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(int.MaxValue, 1, int.MaxValue)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(int.MaxValue, int.MaxValue, 1)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MaxValue - 1, 1)]
        [InlineData(int.MaxValue, int.MaxValue - 1, int.MaxValue)]
        [Theory]
        public void When_an_int_value_is_close_to_expected_value_it_should_succeed(int actual, int nearbyValue, uint delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(int.MinValue, int.MaxValue, 1)]
        [InlineData(int.MinValue, 0, int.MaxValue)]
        [InlineData(int.MinValue, 1, int.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, int.MinValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MinValue, 1)]
        [InlineData(int.MaxValue, -1, int.MaxValue)]
        [Theory]
        public void When_an_int_value_is_not_close_to_expected_value_it_should_fail(int actual, int nearbyValue, uint delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_int_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            int actual = 1;
            int nearbyValue = 4;
            uint delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_an_int_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            int actual = int.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(long.MinValue, long.MinValue, 0)]
        [InlineData(long.MinValue, long.MinValue, 1)]
        [InlineData(long.MinValue, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(long.MinValue, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue, long.MinValue, ulong.MaxValue)]
        [InlineData(long.MinValue, long.MinValue + 1, 1)]
        [InlineData(long.MinValue, long.MinValue + 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MinValue + 1, ulong.MaxValue / 2)]
        [InlineData(long.MinValue, long.MinValue + 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue, long.MinValue + 1, ulong.MaxValue)]
        [InlineData(long.MinValue, -1, long.MaxValue)]
        [InlineData(long.MinValue + 1, long.MinValue, 1)]
        [InlineData(long.MinValue + 1, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue + 1, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(long.MinValue + 1, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue + 1, long.MinValue, ulong.MaxValue)]
        [InlineData(long.MinValue + 1, 0, ulong.MaxValue / 2)]
        [InlineData(long.MinValue + 1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue + 1, 0, ulong.MaxValue)]
        [InlineData(long.MinValue, long.MaxValue, ulong.MaxValue)]
        [InlineData(-1, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(-1, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(-1, long.MinValue, ulong.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(-1, 0, ulong.MaxValue / 2)]
        [InlineData(-1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(-1, 0, ulong.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, -1, ulong.MaxValue / 2)]
        [InlineData(0, -1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, -1, ulong.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, 1, ulong.MaxValue / 2)]
        [InlineData(0, 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, 1, ulong.MaxValue)]
        [InlineData(0, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(0, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, long.MaxValue, ulong.MaxValue)]
        [InlineData(0, long.MinValue + 1, ulong.MaxValue / 2)]
        [InlineData(0, long.MinValue + 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, long.MinValue + 1, ulong.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(1, 0, ulong.MaxValue / 2)]
        [InlineData(1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(1, 0, ulong.MaxValue)]
        [InlineData(1, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(1, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(1, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(1, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue - 1, long.MaxValue, 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue - 1, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue, 0, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, 0, ulong.MaxValue)]
        [InlineData(long.MaxValue, 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, 1, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, 1, ulong.MaxValue)]
        [InlineData(long.MaxValue, long.MaxValue, 0)]
        [InlineData(long.MaxValue, long.MaxValue, 1)]
        [InlineData(long.MaxValue, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue, long.MaxValue - 1, 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, long.MaxValue - 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, ulong.MaxValue)]
        [Theory]
        public void When_a_long_value_is_close_to_expected_value_it_should_succeed(long actual, long nearbyValue, ulong delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(long.MinValue, long.MaxValue, 1)]
        [InlineData(long.MinValue, 0, long.MaxValue)]
        [InlineData(long.MinValue, 1, long.MaxValue)]
        [InlineData(long.MinValue + 1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, long.MaxValue, long.MaxValue)]
        [InlineData(-1, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, long.MinValue, long.MaxValue)]
        [InlineData(0, long.MinValue + 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, long.MinValue, long.MaxValue)]
        [InlineData(long.MaxValue, long.MinValue, 1)]
        [InlineData(long.MaxValue, -1, long.MaxValue)]
        [InlineData(long.MaxValue, 0, (ulong.MaxValue / 2) - 1)]
        [Theory]
        public void When_a_long_value_is_not_close_to_expected_value_it_should_fail(long actual, long nearbyValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_long_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            long actual = 1;
            long nearbyValue = 4;
            ulong delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_a_long_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            long actual = long.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, byte.MaxValue, byte.MaxValue)]
        [InlineData(byte.MinValue, byte.MinValue + 1, byte.MaxValue)]
        [InlineData(byte.MinValue + 1, 0, byte.MaxValue)]
        [InlineData(byte.MinValue + 1, byte.MinValue, 1)]
        [InlineData(byte.MinValue + 1, byte.MinValue, byte.MaxValue)]
        [InlineData(byte.MaxValue - 1, byte.MaxValue, 1)]
        [InlineData(byte.MaxValue - 1, byte.MaxValue, byte.MaxValue)]
        [InlineData(byte.MaxValue, 0, byte.MaxValue)]
        [InlineData(byte.MaxValue, 1, byte.MaxValue)]
        [InlineData(byte.MaxValue, byte.MaxValue - 1, 1)]
        [InlineData(byte.MaxValue, byte.MaxValue - 1, byte.MaxValue)]
        [InlineData(byte.MaxValue, byte.MaxValue, 0)]
        [InlineData(byte.MaxValue, byte.MaxValue, 1)]
        [Theory]
        public void When_a_byte_value_is_close_to_expected_value_it_should_succeed(byte actual, byte nearbyValue, byte delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(byte.MinValue, byte.MaxValue, 1)]
        [InlineData(byte.MaxValue, byte.MinValue, 1)]
        [Theory]
        public void When_a_byte_value_is_not_close_to_expected_value_it_should_fail(byte actual, byte nearbyValue, byte delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_byte_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            byte actual = 1;
            byte nearbyValue = 4;
            byte delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_a_byte_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            byte actual = byte.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, ushort.MaxValue, ushort.MaxValue)]
        [InlineData(ushort.MinValue, ushort.MinValue + 1, ushort.MaxValue)]
        [InlineData(ushort.MinValue + 1, 0, ushort.MaxValue)]
        [InlineData(ushort.MinValue + 1, ushort.MinValue, 1)]
        [InlineData(ushort.MinValue + 1, ushort.MinValue, ushort.MaxValue)]
        [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 1)]
        [InlineData(ushort.MaxValue - 1, ushort.MaxValue, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, 0, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, 1, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 1)]
        [InlineData(ushort.MaxValue, ushort.MaxValue - 1, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, ushort.MaxValue, 0)]
        [InlineData(ushort.MaxValue, ushort.MaxValue, 1)]
        [Theory]
        public void When_an_ushort_value_is_close_to_expected_value_it_should_succeed(ushort actual, ushort nearbyValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(ushort.MinValue, ushort.MaxValue, 1)]
        [InlineData(ushort.MaxValue, ushort.MinValue, 1)]
        [Theory]
        public void When_an_ushort_value_is_not_close_to_expected_value_it_should_fail(ushort actual, ushort nearbyValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_ushort_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            ushort actual = 1;
            ushort nearbyValue = 4;
            ushort delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_an_ushort_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            ushort actual = ushort.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, uint.MaxValue, uint.MaxValue)]
        [InlineData(uint.MinValue, uint.MinValue + 1, uint.MaxValue)]
        [InlineData(uint.MinValue + 1, 0, uint.MaxValue)]
        [InlineData(uint.MinValue + 1, uint.MinValue, 1)]
        [InlineData(uint.MinValue + 1, uint.MinValue, uint.MaxValue)]
        [InlineData(uint.MaxValue - 1, uint.MaxValue, 1)]
        [InlineData(uint.MaxValue - 1, uint.MaxValue, uint.MaxValue)]
        [InlineData(uint.MaxValue, 0, uint.MaxValue)]
        [InlineData(uint.MaxValue, 1, uint.MaxValue)]
        [InlineData(uint.MaxValue, uint.MaxValue - 1, 1)]
        [InlineData(uint.MaxValue, uint.MaxValue - 1, uint.MaxValue)]
        [InlineData(uint.MaxValue, uint.MaxValue, 0)]
        [InlineData(uint.MaxValue, uint.MaxValue, 1)]
        [Theory]
        public void When_an_uint_value_is_close_to_expected_value_it_should_succeed(uint actual, uint nearbyValue, uint delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(uint.MinValue, uint.MaxValue, 1)]
        [InlineData(uint.MaxValue, uint.MinValue, 1)]
        [Theory]
        public void When_an_uint_value_is_not_close_to_expected_value_it_should_fail(uint actual, uint nearbyValue,
            uint delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_uint_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            uint actual = 1;
            uint nearbyValue = 4;
            uint delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_an_uint_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            uint actual = uint.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, ulong.MaxValue, ulong.MaxValue)]
        [InlineData(ulong.MinValue, ulong.MinValue + 1, ulong.MaxValue)]
        [InlineData(ulong.MinValue + 1, 0, ulong.MaxValue)]
        [InlineData(ulong.MinValue + 1, ulong.MinValue, 1)]
        [InlineData(ulong.MinValue + 1, ulong.MinValue, ulong.MaxValue)]
        [InlineData(ulong.MaxValue - 1, ulong.MaxValue, 1)]
        [InlineData(ulong.MaxValue - 1, ulong.MaxValue, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, 0, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, 1, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, ulong.MaxValue - 1, 1)]
        [InlineData(ulong.MaxValue, ulong.MaxValue - 1, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, ulong.MaxValue, 0)]
        [InlineData(ulong.MaxValue, ulong.MaxValue, 1)]
        [Theory]
        public void When_an_ulong_value_is_close_to_expected_value_it_should_succeed(ulong actual, ulong nearbyValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(ulong.MinValue, ulong.MaxValue, 1)]
        [InlineData(ulong.MaxValue, ulong.MinValue, 1)]
        [Theory]
        public void When_an_ulong_value_is_not_close_to_expected_value_it_should_fail(ulong actual, ulong nearbyValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_ulong_value_is_not_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            ulong actual = 1;
            ulong nearbyValue = 4;
            ulong delta = 2;

            // Act
            Action act = () => actual.Should().BeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*4*but found*1*");
        }

        [Fact]
        public void When_an_ulong_value_is_returned_from_BeCloseTo_it_should_chain()
        {
            // Arrange
            ulong actual = ulong.MaxValue;

            // Act
            Action act = () => actual.Should().BeCloseTo(actual, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class NotBeCloseTo
    {
        [InlineData(sbyte.MinValue, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MinValue, 0, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, 1, sbyte.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(0, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MinValue, 1)]
        [InlineData(sbyte.MaxValue, -1, sbyte.MaxValue)]
        [Theory]
        public void When_a_sbyte_value_is_not_close_to_expected_value_it_should_succeed(sbyte actual, sbyte distantValue,
            byte delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(sbyte.MinValue, sbyte.MinValue, 0)]
        [InlineData(sbyte.MinValue, sbyte.MinValue, 1)]
        [InlineData(sbyte.MinValue, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, sbyte.MinValue + 1, 1)]
        [InlineData(sbyte.MinValue, sbyte.MinValue + 1, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, -1, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue + 1, sbyte.MinValue, 1)]
        [InlineData(sbyte.MinValue + 1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue + 1, 0, sbyte.MaxValue)]
        [InlineData(-1, sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, sbyte.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, sbyte.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, sbyte.MaxValue)]
        [InlineData(0, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(0, sbyte.MinValue + 1, sbyte.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, sbyte.MaxValue)]
        [InlineData(1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue - 1, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MaxValue - 1, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, 0, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, 1, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, 0)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, 1)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue - 1, 1)]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue - 1, sbyte.MaxValue)]
        [Theory]
        public void When_a_sbyte_value_is_close_to_expected_value_it_should_fail(sbyte actual, sbyte distantValue, byte delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_sbyte_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            sbyte actual = 1;
            sbyte nearbyValue = 3;
            byte delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_a_sbyte_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            sbyte actual = sbyte.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(short.MinValue, short.MaxValue, 1)]
        [InlineData(short.MinValue, 0, short.MaxValue)]
        [InlineData(short.MinValue, 1, short.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, short.MaxValue, short.MaxValue)]
        [InlineData(0, short.MinValue, short.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, short.MinValue, short.MaxValue)]
        [InlineData(short.MaxValue, short.MinValue, 1)]
        [InlineData(short.MaxValue, -1, short.MaxValue)]
        [Theory]
        public void When_a_short_value_is_not_close_to_expected_value_it_should_succeed(short actual, short distantValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(short.MinValue, short.MinValue, 0)]
        [InlineData(short.MinValue, short.MinValue, 1)]
        [InlineData(short.MinValue, short.MinValue, short.MaxValue)]
        [InlineData(short.MinValue, short.MinValue + 1, 1)]
        [InlineData(short.MinValue, short.MinValue + 1, short.MaxValue)]
        [InlineData(short.MinValue, -1, short.MaxValue)]
        [InlineData(short.MinValue + 1, short.MinValue, 1)]
        [InlineData(short.MinValue + 1, short.MinValue, short.MaxValue)]
        [InlineData(short.MinValue + 1, 0, short.MaxValue)]
        [InlineData(-1, short.MinValue, short.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, short.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, short.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, short.MaxValue)]
        [InlineData(0, short.MaxValue, short.MaxValue)]
        [InlineData(0, short.MinValue + 1, short.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, short.MaxValue)]
        [InlineData(1, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue - 1, short.MaxValue, 1)]
        [InlineData(short.MaxValue - 1, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue, 0, short.MaxValue)]
        [InlineData(short.MaxValue, 1, short.MaxValue)]
        [InlineData(short.MaxValue, short.MaxValue, 0)]
        [InlineData(short.MaxValue, short.MaxValue, 1)]
        [InlineData(short.MaxValue, short.MaxValue, short.MaxValue)]
        [InlineData(short.MaxValue, short.MaxValue - 1, 1)]
        [InlineData(short.MaxValue, short.MaxValue - 1, short.MaxValue)]
        [Theory]
        public void When_a_short_value_is_close_to_expected_value_it_should_fail(short actual, short distantValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_short_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            short actual = 1;
            short nearbyValue = 3;
            ushort delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_a_short_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            short actual = short.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(int.MinValue, int.MaxValue, 1)]
        [InlineData(int.MinValue, 0, int.MaxValue)]
        [InlineData(int.MinValue, 1, int.MaxValue)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MaxValue)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, int.MinValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MinValue, 1)]
        [InlineData(int.MaxValue, -1, int.MaxValue)]
        [Theory]
        public void When_an_int_value_is_not_close_to_expected_value_it_should_succeed(int actual, int distantValue,
            uint delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(int.MinValue, int.MinValue, 0)]
        [InlineData(int.MinValue, int.MinValue, 1)]
        [InlineData(int.MinValue, int.MinValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue + 1, 1)]
        [InlineData(int.MinValue, int.MinValue + 1, int.MaxValue)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        [InlineData(int.MinValue + 1, int.MinValue, 1)]
        [InlineData(int.MinValue + 1, int.MinValue, int.MaxValue)]
        [InlineData(int.MinValue + 1, 0, int.MaxValue)]
        [InlineData(-1, int.MinValue, int.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, int.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, int.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, int.MaxValue)]
        [InlineData(0, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue + 1, int.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, int.MaxValue)]
        [InlineData(1, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue - 1, int.MaxValue, 1)]
        [InlineData(int.MaxValue - 1, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(int.MaxValue, 1, int.MaxValue)]
        [InlineData(int.MaxValue, int.MaxValue, 0)]
        [InlineData(int.MaxValue, int.MaxValue, 1)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MaxValue - 1, 1)]
        [InlineData(int.MaxValue, int.MaxValue - 1, int.MaxValue)]
        [Theory]
        public void When_an_int_value_is_close_to_expected_value_it_should_fail(int actual, int distantValue, uint delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_int_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            int actual = 1;
            int nearbyValue = 3;
            uint delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_an_int_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            int actual = int.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(long.MinValue, long.MaxValue, 1)]
        [InlineData(long.MinValue, 0, long.MaxValue)]
        [InlineData(long.MinValue, 1, long.MaxValue)]
        [InlineData(long.MinValue + 1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, long.MaxValue, long.MaxValue)]
        [InlineData(-1, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, long.MinValue, long.MaxValue)]
        [InlineData(0, long.MinValue + 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, long.MinValue, long.MaxValue)]
        [InlineData(long.MaxValue, long.MinValue, 1)]
        [InlineData(long.MaxValue, -1, long.MaxValue)]
        [InlineData(long.MaxValue, 0, (ulong.MaxValue / 2) - 1)]
        [Theory]
        public void When_a_long_value_is_not_close_to_expected_value_it_should_succeed(long actual, long distantValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(long.MinValue, long.MinValue, 0)]
        [InlineData(long.MinValue, long.MinValue, 1)]
        [InlineData(long.MinValue, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(long.MinValue, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue, long.MinValue, ulong.MaxValue)]
        [InlineData(long.MinValue, long.MinValue + 1, 1)]
        [InlineData(long.MinValue, long.MinValue + 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue, long.MinValue + 1, ulong.MaxValue / 2)]
        [InlineData(long.MinValue, long.MinValue + 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue, long.MinValue + 1, ulong.MaxValue)]
        [InlineData(long.MinValue, -1, long.MaxValue)]
        [InlineData(long.MinValue + 1, long.MinValue, 1)]
        [InlineData(long.MinValue + 1, long.MinValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MinValue + 1, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(long.MinValue + 1, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue + 1, long.MinValue, ulong.MaxValue)]
        [InlineData(long.MinValue + 1, 0, ulong.MaxValue / 2)]
        [InlineData(long.MinValue + 1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MinValue + 1, 0, ulong.MaxValue)]
        [InlineData(long.MinValue, long.MaxValue, ulong.MaxValue)]
        [InlineData(-1, long.MinValue, ulong.MaxValue / 2)]
        [InlineData(-1, long.MinValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(-1, long.MinValue, ulong.MaxValue)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(-1, 0, ulong.MaxValue / 2)]
        [InlineData(-1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(-1, 0, ulong.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, -1, 1)]
        [InlineData(0, -1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, -1, ulong.MaxValue / 2)]
        [InlineData(0, -1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, -1, ulong.MaxValue)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(0, 1, ulong.MaxValue / 2)]
        [InlineData(0, 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, 1, ulong.MaxValue)]
        [InlineData(0, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(0, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, long.MaxValue, ulong.MaxValue)]
        [InlineData(0, long.MinValue + 1, ulong.MaxValue / 2)]
        [InlineData(0, long.MinValue + 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(0, long.MinValue + 1, ulong.MaxValue)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, (ulong.MaxValue / 2) - 1)]
        [InlineData(1, 0, ulong.MaxValue / 2)]
        [InlineData(1, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(1, 0, ulong.MaxValue)]
        [InlineData(1, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(1, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(1, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(1, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue - 1, long.MaxValue, 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue - 1, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue - 1, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue, 0, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, 0, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, 0, ulong.MaxValue)]
        [InlineData(long.MaxValue, 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, 1, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, 1, ulong.MaxValue)]
        [InlineData(long.MaxValue, long.MaxValue, 0)]
        [InlineData(long.MaxValue, long.MaxValue, 1)]
        [InlineData(long.MaxValue, long.MaxValue, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, long.MaxValue, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, long.MaxValue, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, long.MaxValue, ulong.MaxValue)]
        [InlineData(long.MaxValue, long.MaxValue - 1, 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, (ulong.MaxValue / 2) - 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, ulong.MaxValue / 2)]
        [InlineData(long.MaxValue, long.MaxValue - 1, (ulong.MaxValue / 2) + 1)]
        [InlineData(long.MaxValue, long.MaxValue - 1, ulong.MaxValue)]
        [Theory]
        public void When_a_long_value_is_close_to_expected_value_it_should_fail(long actual, long distantValue, ulong delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_long_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            long actual = 1;
            long nearbyValue = 3;
            ulong delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_a_long_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            long actual = long.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(byte.MinValue, byte.MaxValue, 1)]
        [InlineData(byte.MaxValue, byte.MinValue, 1)]
        [Theory]
        public void When_a_byte_value_is_not_close_to_expected_value_it_should_succeed(byte actual, byte distantValue,
            byte delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, byte.MaxValue, byte.MaxValue)]
        [InlineData(byte.MinValue, byte.MinValue + 1, byte.MaxValue)]
        [InlineData(byte.MinValue + 1, 0, byte.MaxValue)]
        [InlineData(byte.MinValue + 1, byte.MinValue, 1)]
        [InlineData(byte.MinValue + 1, byte.MinValue, byte.MaxValue)]
        [InlineData(byte.MaxValue - 1, byte.MaxValue, 1)]
        [InlineData(byte.MaxValue - 1, byte.MaxValue, byte.MaxValue)]
        [InlineData(byte.MaxValue, 0, byte.MaxValue)]
        [InlineData(byte.MaxValue, 1, byte.MaxValue)]
        [InlineData(byte.MaxValue, byte.MaxValue - 1, 1)]
        [InlineData(byte.MaxValue, byte.MaxValue - 1, byte.MaxValue)]
        [InlineData(byte.MaxValue, byte.MaxValue, 0)]
        [InlineData(byte.MaxValue, byte.MaxValue, 1)]
        [Theory]
        public void When_a_byte_value_is_close_to_expected_value_it_should_fail(byte actual, byte distantValue, byte delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_byte_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            byte actual = 1;
            byte nearbyValue = 3;
            byte delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_a_byte_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            byte actual = byte.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(ushort.MinValue, ushort.MaxValue, 1)]
        [InlineData(ushort.MaxValue, ushort.MinValue, 1)]
        [Theory]
        public void When_an_ushort_value_is_not_close_to_expected_value_it_should_succeed(ushort actual, ushort distantValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, ushort.MaxValue, ushort.MaxValue)]
        [InlineData(ushort.MinValue, ushort.MinValue + 1, ushort.MaxValue)]
        [InlineData(ushort.MinValue + 1, 0, ushort.MaxValue)]
        [InlineData(ushort.MinValue + 1, ushort.MinValue, 1)]
        [InlineData(ushort.MinValue + 1, ushort.MinValue, ushort.MaxValue)]
        [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 1)]
        [InlineData(ushort.MaxValue - 1, ushort.MaxValue, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, 0, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, 1, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 1)]
        [InlineData(ushort.MaxValue, ushort.MaxValue - 1, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, ushort.MaxValue, 0)]
        [InlineData(ushort.MaxValue, ushort.MaxValue, 1)]
        [Theory]
        public void When_an_ushort_value_is_close_to_expected_value_it_should_fail(ushort actual, ushort distantValue,
            ushort delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_ushort_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            ushort actual = 1;
            ushort nearbyValue = 3;
            ushort delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_an_ushort_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            ushort actual = ushort.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(uint.MinValue, uint.MaxValue, 1)]
        [InlineData(uint.MaxValue, uint.MinValue, 1)]
        [Theory]
        public void When_an_uint_value_is_not_close_to_expected_value_it_should_succeed(uint actual, uint distantValue,
            uint delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, uint.MaxValue, uint.MaxValue)]
        [InlineData(uint.MinValue, uint.MinValue + 1, uint.MaxValue)]
        [InlineData(uint.MinValue + 1, 0, uint.MaxValue)]
        [InlineData(uint.MinValue + 1, uint.MinValue, 1)]
        [InlineData(uint.MinValue + 1, uint.MinValue, uint.MaxValue)]
        [InlineData(uint.MaxValue - 1, uint.MaxValue, 1)]
        [InlineData(uint.MaxValue - 1, uint.MaxValue, uint.MaxValue)]
        [InlineData(uint.MaxValue, 0, uint.MaxValue)]
        [InlineData(uint.MaxValue, 1, uint.MaxValue)]
        [InlineData(uint.MaxValue, uint.MaxValue - 1, 1)]
        [InlineData(uint.MaxValue, uint.MaxValue - 1, uint.MaxValue)]
        [InlineData(uint.MaxValue, uint.MaxValue, 0)]
        [InlineData(uint.MaxValue, uint.MaxValue, 1)]
        [Theory]
        public void When_an_uint_value_is_close_to_expected_value_it_should_fail(uint actual, uint distantValue, uint delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_uint_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            uint actual = 1;
            uint nearbyValue = 3;
            uint delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_an_uint_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            uint actual = uint.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(ulong.MinValue, ulong.MaxValue, 1)]
        [InlineData(ulong.MaxValue, ulong.MinValue, 1)]
        [Theory]
        public void When_an_ulong_value_is_not_close_to_expected_value_it_should_succeed(ulong actual, ulong distantValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().NotThrow();
        }

        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, ulong.MaxValue, ulong.MaxValue)]
        [InlineData(ulong.MinValue, ulong.MinValue + 1, ulong.MaxValue)]
        [InlineData(ulong.MinValue + 1, 0, ulong.MaxValue)]
        [InlineData(ulong.MinValue + 1, ulong.MinValue, 1)]
        [InlineData(ulong.MinValue + 1, ulong.MinValue, ulong.MaxValue)]
        [InlineData(ulong.MaxValue - 1, ulong.MaxValue, 1)]
        [InlineData(ulong.MaxValue - 1, ulong.MaxValue, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, 0, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, 1, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, ulong.MaxValue - 1, 1)]
        [InlineData(ulong.MaxValue, ulong.MaxValue - 1, ulong.MaxValue)]
        [InlineData(ulong.MaxValue, ulong.MaxValue, 0)]
        [InlineData(ulong.MaxValue, ulong.MaxValue, 1)]
        [Theory]
        public void When_an_ulong_value_is_close_to_expected_value_it_should_fail(ulong actual, ulong distantValue,
            ulong delta)
        {
            // Act
            Action act = () => actual.Should().NotBeCloseTo(distantValue, delta);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_an_ulong_value_is_close_to_expected_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            ulong actual = 1;
            ulong nearbyValue = 3;
            ulong delta = 2;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(nearbyValue, delta);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("*be within*2*from*3*but found*1*");
        }

        [Fact]
        public void When_an_ulong_value_is_returned_from_NotBeCloseTo_it_should_chain()
        {
            // Arrange
            ulong actual = ulong.MaxValue;

            // Act
            Action act = () => actual.Should().NotBeCloseTo(0, 0)
                .And.Be(actual);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class Match
    {
        [Fact]
        public void When_value_satisfies_predicate_it_should_not_throw()
        {
            // Arrange
            int value = 1;

            // Act / Assert
            value.Should().Match(o => o > 0);
        }

        [Fact]
        public void When_value_does_not_match_the_predicate_it_should_throw()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => value.Should().Match(o => o == 0, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected value to match (o == 0) because we want to test the failure message, but found 1.");
        }

        [Fact]
        public void When_value_is_matched_against_a_null_it_should_throw()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => value.Should().Match(null);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>()
                .WithParameterName("predicate");
        }
    }

    [Fact]
    public void When_chaining_constraints_with_and_should_not_throw()
    {
        // Arrange
        int value = 2;
        int greaterValue = 3;
        int smallerValue = 1;

        // Act
        Action action = () => value.Should()
            .BePositive()
            .And
            .BeGreaterThan(smallerValue)
            .And
            .BeLessThan(greaterValue);

        // Assert
        action.Should().NotThrow();
    }

    [Fact]
    public void Should_throw_a_helpful_error_when_accidentally_using_equals()
    {
        // Arrange
        int value = 1;

        // Act
        Action action = () => value.Should().Equals(1);

        // Assert
        action.Should().Throw<NotSupportedException>()
            .WithMessage("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
    }
}
