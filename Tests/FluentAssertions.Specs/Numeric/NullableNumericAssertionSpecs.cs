using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public class NullableNumericAssertionSpecs
{
    public class BePositive
    {
        [Fact]
        public void NaN_is_never_a_positive_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }

        [Fact]
        public void NaN_is_never_a_positive_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BePositive();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }
    }

    public class BeNegative
    {
        [Fact]
        public void NaN_is_never_a_negative_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }

        [Fact]
        public void NaN_is_never_a_negative_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeNegative();

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*but found NaN*");
        }
    }

    public class BeLessThan
    {
        [Fact]
        public void A_float_can_never_be_less_than_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => value.Should().BeLessThan(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BeLessThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_less_than_NaN()
        {
            // Arrange
            double? value = 3.4F;

            // Act
            Action act = () => value.Should().BeLessThan(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeLessThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }
    }

    public class BeGreaterThan
    {
        [Fact]
        public void A_float_can_never_be_greater_than_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => value.Should().BeGreaterThan(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_than_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BeGreaterThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_greater_than_NaN()
        {
            // Arrange
            double? value = 3.4F;

            // Act
            Action act = () => value.Should().BeGreaterThan(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_than_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeGreaterThan(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }
    }

    public class BeLessThanOrEqualTo
    {
        [Fact]
        public void A_float_can_never_be_less_than_or_equal_to_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_or_equal_to_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_less_than_or_equal_to_NaN()
        {
            // Arrange
            double? value = 3.4;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_less_than_or_equal_to_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeLessThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }
    }

    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public void A_float_can_never_be_greater_than_or_equal_to_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(float.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_than_or_equal_to_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void A_double_can_never_be_greater_than_or_equal_to_NaN()
        {
            // Arrange
            double? value = 3.4;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(double.NaN);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_greater_than_or_equal_to_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeGreaterThanOrEqualTo(0);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("*NaN*");
        }
    }

    public class BeInRange
    {
        [Theory]
        [InlineData(float.NaN, 5F)]
        [InlineData(5F, float.NaN)]
        public void A_float_can_never_be_in_a_range_containing_NaN(float minimumValue, float maximumValue)
        {
            // Arrange
            float? value = 4.5F;

            // Act
            Action act = () => value.Should().BeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage(
                    "*NaN*");
        }

        [Fact]
        public void NaN_is_never_in_range_of_two_floats()
        {
            // Arrange
            float? value = float.NaN;

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
            double? value = 4.5;

            // Act
            Action act = () => value.Should().BeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage(
                    "*NaN*");
        }

        [Fact]
        public void NaN_is_never_in_range_of_two_doubles()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => value.Should().BeInRange(4, 5);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to be between*4* and*5*, but found*NaN*");
        }
    }

    public class NotBeInRange
    {
        [Theory]
        [InlineData(float.NaN, 1F)]
        [InlineData(1F, float.NaN)]
        public void Cannot_use_NaN_in_a_range_of_floats(float minimumValue, float maximumValue)
        {
            // Arrange
            float? value = 4.5F;

            // Act
            Action act = () => value.Should().NotBeInRange(minimumValue, maximumValue);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void NaN_is_never_inside_any_range_of_floats()
        {
            // Arrange
            float? value = float.NaN;

            // Act / Assert
            value.Should().NotBeInRange(4, 5);
        }

        [Theory]
        [InlineData(double.NaN, 1D)]
        [InlineData(1D, double.NaN)]
        public void Cannot_use_NaN_in_a_range_of_doubles(double minimumValue, double maximumValue)
        {
            // Arrange
            double? value = 4.5D;

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
            double? value = double.NaN;

            // Act / Assert
            value.Should().NotBeInRange(4, 5);
        }
    }

    public class HaveValue
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_value_with_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act / Assert
            nullableInteger.Should().HaveValue();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => nullableInteger.Should().HaveValue();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void
            Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => nullableInteger.Should().HaveValue("because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected a value because we want to test the failure message.");
        }
    }

    public class NotHaveValue
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_value_without_a_value_to_not_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act / Assert
            nullableInteger.Should().NotHaveValue();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_numeric_value_with_a_value_to_not_have_a_value()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => nullableInteger.Should().NotHaveValue();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_nullable_value_with_unexpected_value_is_found_it_should_throw_with_message()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action action = () => nullableInteger.Should().NotHaveValue("it was {0} expected", "not");

            // Assert
            action
                .Should().Throw<XunitException>()
                .WithMessage("Did not expect a value because it was not expected, but found 1.");
        }
    }

    public class NotBeNull
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_value_with_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act / Assert
            nullableInteger.Should().NotBeNull();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_numeric_value_without_a_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => nullableInteger.Should().NotBeNull();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void
            Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_without_a_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => nullableInteger.Should().NotBeNull("because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected a value because we want to test the failure message.");
        }
    }

    public class BeNull
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_value_without_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act / Assert
            nullableInteger.Should().BeNull();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_numeric_value_with_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => nullableInteger.Should().BeNull();

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_with_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => nullableInteger.Should().BeNull("because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect a value because we want to test the failure message, but found 1.");
        }
    }

    public class Be
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_value_equals_an_equal_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 1;

            // Act / Assert
            nullableIntegerA.Should().Be(nullableIntegerB);
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            int? nullableIntegerA = null;
            int? nullableIntegerB = null;

            // Act / Assert
            nullableIntegerA.Should().Be(nullableIntegerB);
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () => nullableIntegerA.Should().Be(nullableIntegerB);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () =>
                nullableIntegerA.Should().Be(nullableIntegerB, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected*2 because we want to test the failure message, but found 1.");
        }

        [Fact]
        public void Nan_is_never_equal_to_a_normal_float()
        {
            // Arrange
            float? value = float.NaN;

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
            float? value = float.NaN;

            // Act
            value.Should().Be(float.NaN);
        }

        [Fact]
        public void Nan_is_never_equal_to_a_normal_double()
        {
            // Arrange
            double? value = double.NaN;

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
            double? value = double.NaN;

            // Act
            value.Should().Be(double.NaN);
        }
    }

    public class BeApproximately
    {
        [Fact]
        public void When_approximating_a_nullable_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().BeApproximately(3.14, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_approximating_two_nullable_doubles_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.14;

            // Act
            Action act = () => value.Should().BeApproximately(expected, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_nullable_double_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().BeApproximately(3.14, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_double_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.142;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_double_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            double? value = null;
            double? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_double_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = 13;
            double? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("Expected*12.0*0.1*13.0*");
        }

        [Fact]
        public void When_nullable_double_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = null;
            double? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate 12.0 +/- 0.1, but it was <null>.");
        }

        [Fact]
        public void When_nullable_double_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            double? value = 12;
            double? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate <null> +/- 0.1, but it was 12.0.");
        }

        [Fact]
        public void When_nullable_double_has_no_value_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                value.Should().BeApproximately(3.14, 0.001);
            };

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate 3.14 +/- 0.001, but it was <null>.");
        }

        [Fact]
        public void When_nullable_double_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(1.0, 0.1);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to approximate 1.0 +/- 0.1, but 3.14* differed by*");
        }

        [Fact]
        public void A_double_cannot_approximate_NaN()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(double.NaN, 0.1);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_approximating_a_nullable_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_approximating_two_nullable_floats_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.14F;

            // Act
            Action act = () => value.Should().BeApproximately(expected, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_nullable_float_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(3.14F, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_float_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927f;
            float? expected = 3.142f;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1f);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_float_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            float? value = null;
            float? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1f);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_float_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = 13;
            float? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1f);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("Expected*12*0.1*13*");
        }

        [Fact]
        public void When_nullable_float_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = null;
            float? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1f);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate 12F +/- 0.1F, but it was <null>.");
        }

        [Fact]
        public void When_nullable_float_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            float? value = 12;
            float? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1f);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate <null> +/- 0.1F, but it was 12F.");
        }

        [Fact]
        public void When_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                value.Should().BeApproximately(3.14F, 0.001F);
            };

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate 3.14F +/- 0.001F, but it was <null>.");
        }

        [Fact]
        public void When_nullable_float_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(1.0F, 0.1F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to approximate *1* +/- *0.1* but 3.14* differed by*");
        }

        [Fact]
        public void A_float_cannot_approximate_NaN()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().BeApproximately(float.NaN, 0.1F);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_approximating_a_nullable_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().BeApproximately(3.14m, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_approximating_two_nullable_decimals_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.14m;

            // Act
            Action act = () => value.Should().BeApproximately(expected, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_nullable_decimal_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().BeApproximately(3.14m, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_decimal_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.142m;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_decimal_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_nullable_decimal_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = 13;
            decimal? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1m);

            // Assert
            act.Should().Throw<XunitException>().WithMessage("Expected*12*0.1*13*");
        }

        [Fact]
        public void When_nullable_decimal_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = 12;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1m);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate 12M +/- 0.1M, but it was <null>.");
        }

        [Fact]
        public void When_nullable_decimal_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            decimal? value = 12;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().BeApproximately(expected, 0.1m);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected value to approximate <null> +/- 0.1M, but it was 12M.");
        }

        [Fact]
        public void When_nullable_decimal_has_no_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                value.Should().BeApproximately(3.14m, 0.001m);
            };

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected value to approximate*3.14* +/-*0.001*, but it was <null>.");
        }

        [Fact]
        public void When_nullable_decimal_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().BeApproximately(1.0m, 0.1m);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to approximate*1.0* +/-*0.1*, but 3.14* differed by*");
        }
    }

    public class NotBeApproximately
    {
        [Fact]
        public void When_not_approximating_a_nullable_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_not_approximating_two_nullable_doubles_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.14;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_double_has_no_value_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_double_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to not approximate 3.14 +/- 0.1, but 3.14*only differed by*");
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 1.0;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_null_double_is_not_approximating_a_nullable_double_value_it_should_throw()
        {
            // Arrange
            double? value = null;
            double? expected = 20.0;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_null_double_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            double? value = null;
            double? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected*null*0.1*but*null*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_double_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.1;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void A_double_cannot_approximate_NaN()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NaN, 0.1);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_not_approximating_a_nullable_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_not_approximating_two_nullable_floats_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.14F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1F);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0F, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_float_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to not approximate *3.14F* +/- *0.1F* but 3.14* only differed by*");
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 1.0F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_null_float_is_not_approximating_a_nullable_float_value_it_should_throw()
        {
            // Arrange
            float? value = null;
            float? expected = 20.0f;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_null_float_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            float? value = null;
            float? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().Throw<XunitException>("Expected*<null>*+/-*0.1F*<null>*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_float_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.1F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void A_float_cannot_approximate_NaN()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NaN, 0.1F);

            // Assert
            act
                .Should().Throw<ArgumentException>()
                .WithMessage("*NaN*");
        }

        [Fact]
        public void When_not_approximating_a_nullable_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_not_approximating_two_nullable_decimals_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.14m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1m);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0m, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_decimal_has_no_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, 0.001m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_decimal_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, 0.1m);

            // Assert
            act
                .Should().Throw<XunitException>()
                .WithMessage("Expected value to not approximate*3.14* +/-*0.1*, but*3.14*only differed by*");
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 1.0m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_not_approximately_and_null_decimal_is_not_approximating_a_nullable_decimal_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = 20.0m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_not_approximately_and_null_decimal_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected*<null>*0.1M*<null>*");
        }

        [Fact]
        public void When_asserting_not_approximately_and_nullable_decimal_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.1m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            act.Should().Throw<XunitException>();
        }
    }

    public class Match
    {
        [Fact]
        public void When_nullable_value_satisfies_predicate_it_should_not_throw()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act / Assert
            nullableInteger.Should().Match(o => o.HasValue);
        }

        [Fact]
        public void When_nullable_value_does_not_match_the_predicate_it_should_throw()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () =>
                nullableInteger.Should().Match(o => !o.HasValue, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected value to match Not(o.HasValue) because we want to test the failure message, but found 1.");
        }

        [Fact]
        public void When_nullable_value_is_matched_against_a_null_it_should_throw()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => nullableInteger.Should().Match(null);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>()
                .WithParameterName("predicate");
        }
    }

    [Fact]
    public void Should_support_chaining_constraints_with_and()
    {
        // Arrange
        int? nullableInteger = 1;

        // Act / Assert
        nullableInteger.Should()
            .HaveValue()
            .And
            .BePositive();
    }
}
