﻿using System;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public class DateTimeOffsetAssertionSpecs
{
    public class HaveValue
    {
        [Fact]
        public void When_nullable_datetimeoffset_value_with_a_value_to_have_a_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () => nullableDateTime.Should().HaveValue();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_datetimeoffset_value_without_a_value_to_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () => nullableDateTime.Should().HaveValue();

            // Assert
            action.Should().Throw<XunitException>();
        }
    }

    public class NotHaveValue
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_datetimeoffset_value_without_a_value_to_not_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () =>
                nullableDateTime.Should().NotHaveValue();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_datetimeoffset_value_with_a_value_to_not_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTime.Should().NotHaveValue();

            // Assert
            action.Should().Throw<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public void When_nullable_datetimeoffset_value_with_a_value_not_be_null_it_should_succeed()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () => nullableDateTime.Should().NotBeNull();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_datetimeoffset_value_without_a_value_to_not_be_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () => nullableDateTime.Should().NotBeNull();

            // Assert
            action.Should().Throw<XunitException>();
        }
    }

    public class BeNull
    {
        [Fact]
        public void Should_succeed_when_asserting_nullable_datetimeoffset_value_without_a_value_to_be_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () =>
                nullableDateTime.Should().BeNull();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_datetimeoffset_value_with_a_value_to_be_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTime.Should().BeNull();

            // Assert
            action.Should().Throw<XunitException>();
        }
    }

    public class Be
    {
        [Fact]
        public void Should_succeed_when_asserting_datetimeoffset_value_is_equal_to_the_same_value()
        {
            // Arrange
            DateTimeOffset dateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset sameDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action act = () => dateTime.Should().Be(sameDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_datetimeoffset_value_is_equal_to_the_same_nullable_value_be_should_succeed()
        {
            // Arrange
            DateTimeOffset dateTime = 4.June(2016).ToDateTimeOffset();
            DateTimeOffset? sameDateTime = 4.June(2016).ToDateTimeOffset();

            // Act
            Action act = () => dateTime.Should().Be(sameDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_both_values_are_at_their_minimum_then_it_should_succeed()
        {
            // Arrange
            DateTimeOffset dateTime = DateTimeOffset.MinValue;
            DateTimeOffset sameDateTime = DateTimeOffset.MinValue;

            // Act
            Action act = () => dateTime.Should().Be(sameDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_both_values_are_at_their_maximum_then_it_should_succeed()
        {
            // Arrange
            DateTimeOffset dateTime = DateTimeOffset.MaxValue;
            DateTimeOffset sameDateTime = DateTimeOffset.MaxValue;

            // Act
            Action act = () => dateTime.Should().Be(sameDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_datetimeoffset_value_is_equal_to_the_different_value()
        {
            // Arrange
            var dateTime = 10.March(2012).WithOffset(1.Hours());
            var otherDateTime = 11.March(2012).WithOffset(1.Hours());

            // Act
            Action act = () => dateTime.Should().Be(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected dateTime to represent the same point in time as <2012-03-11 +1h>*failure message, but <2012-03-10 +1h> does not.");
        }

        [Fact]
        public void When_datetimeoffset_value_is_equal_to_the_different_nullable_value_be_should_failed()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset? otherDateTime = 11.March(2012).WithOffset(1.Hours());

            // Act
            Action act = () => dateTime.Should().Be(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected dateTime to represent the same point in time as <2012-03-11 +1h>*failure message, but <2012-03-10 +1h> does not.");
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_datetimeoffset_value_equals_the_same_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTimeA.Should().Be(nullableDateTimeB);

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_datetimeoffset_null_value_equals_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = null;
            DateTimeOffset? nullableDateTimeB = null;

            // Act / Assert
            nullableDateTimeA.Should().Be(nullableDateTimeB);
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_datetimeoffset_value_equals_a_different_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 06).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTimeA.Should().Be(nullableDateTimeB);

            // Assert
            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void Should_fail_with_descriptive_message_when_asserting_datetimeoffset_null_value_is_equal_to_another_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;
            DateTimeOffset expectation = 27.March(2016).ToDateTimeOffset(1.Hours());

            // Act
            Action action = () =>
                nullableDateTime.Should().Be(expectation, "because we want to test the failure {0}", "message");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected nullableDateTime to represent the same point in time as <2016-03-27 +1h> because we want to test the failure message, but found a <null> DateTimeOffset.");
        }

        [Fact]
        public void Should_fail_with_descriptive_message_when_asserting_non_null_value_is_equal_to_null_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = 27.March(2016).ToDateTimeOffset(1.Hours());
            DateTimeOffset? expectation = null;

            // Act
            Action action = () =>
                nullableDateTime.Should().Be(expectation, "because we want to test the failure {0}", "message");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected nullableDateTime to be <null> because we want to test the failure message, but it was <2016-03-27 +1h>.");
        }

        [Fact]
        public void
            When_asserting_different_date_time_offsets_representing_the_same_world_time_it_should_succeed()
        {
            // Arrange
            var specificDate = 1.May(2008).At(6, 32);

            var dateWithFiveHourOffset = new DateTimeOffset(specificDate - 5.Hours(), -5.Hours());

            var dateWithSixHourOffset = new DateTimeOffset(specificDate - 6.Hours(), -6.Hours());

            // Act / Assert
            dateWithFiveHourOffset.Should().Be(dateWithSixHourOffset);
        }
    }

    public class NotBe
    {
        [Fact]
        public void Should_succeed_when_asserting_datetimeoffset_value_is_not_equal_to_a_different_value()
        {
            // Arrange
            DateTimeOffset dateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset otherDateTime = new DateTime(2016, 06, 05).ToDateTimeOffset();

            // Act
            Action act = () => dateTime.Should().NotBe(otherDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_datetimeoffset_value_is_not_equal_to_a_nullable_different_value_notbe_should_succeed()
        {
            // Arrange
            DateTimeOffset dateTime = 4.June(2016).ToDateTimeOffset();
            DateTimeOffset? otherDateTime = 5.June(2016).ToDateTimeOffset();

            // Act
            Action act = () => dateTime.Should().NotBe(otherDateTime);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Should_fail_when_asserting_datetimeoffset_value_is_not_equal_to_the_same_value()
        {
            // Arrange
            var dateTime = new DateTimeOffset(10.March(2012), 1.Hours());
            var sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBe(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect dateTime to represent the same point in time as <2012-03-10 +1h> because we want to test the failure message, but it did.");
        }

        [Fact]
        public void When_datetimeoffset_value_is_not_equal_to_the_same_nullable_value_notbe_should_failed()
        {
            // Arrange
            DateTimeOffset dateTime = new(10.March(2012), 1.Hours());
            DateTimeOffset? sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBe(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect dateTime to represent the same point in time as <2012-03-10 +1h> because we want to test the failure message, but it did.");
        }

        [Fact]
        public void
            When_asserting_different_date_time_offsets_representing_different_world_times_it_should_not_succeed()
        {
            // Arrange
            var specificDate = 1.May(2008).At(6, 32);

            var dateWithZeroHourOffset = new DateTimeOffset(specificDate, TimeSpan.Zero);
            var dateWithOneHourOffset = new DateTimeOffset(specificDate, 1.Hours());

            // Act / Assert
            dateWithZeroHourOffset.Should().NotBe(dateWithOneHourOffset);
        }
    }

    public class BeExactly
    {
        [Fact]
        public void Should_succeed_when_asserting_value_is_exactly_equal_to_the_same_value()
        {
            // Arrange
            DateTimeOffset dateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset sameDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act / Assert
            dateTime.Should().BeExactly(sameDateTime);
        }

        [Fact]
        public void Should_succeed_when_asserting_value_is_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 4.June(2016).ToDateTimeOffset();
            DateTimeOffset? sameDateTime = 4.June(2016).ToDateTimeOffset();

            // Act / Assert
            dateTime.Should().BeExactly(sameDateTime);
        }

        [Fact]
        public void Should_fail_when_asserting_value_is_exactly_equal_to_a_different_value()
        {
            // Arrange
            var dateTime = 10.March(2012).WithOffset(1.Hours());
            var otherDateTime = dateTime.ToUniversalTime();

            // Act
            Action act = () => dateTime.Should().BeExactly(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected dateTime to be exactly <2012-03-09 23:00:00 +0h>*failure message, but it was <2012-03-10 +1h>.");
        }

        [Fact]
        public void Should_fail_when_asserting_value_is_exactly_equal_to_a_different_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset? otherDateTime = dateTime.ToUniversalTime();

            // Act
            Action act = () => dateTime.Should().BeExactly(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected dateTime to be exactly <2012-03-09 23:00:00 +0h>*failure message, but it was <2012-03-10 +1h>.");
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_value_is_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act / Assert
            nullableDateTimeA.Should().BeExactly(nullableDateTimeB);
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_null_value_exactly_equals_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = null;
            DateTimeOffset? nullableDateTimeB = null;

            // Act / Assert
            nullableDateTimeA.Should().BeExactly(nullableDateTimeB);
        }

        [Fact]
        public void Should_fail_when_asserting_nullable_value_exactly_equals_a_different_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 06).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTimeA.Should().BeExactly(nullableDateTimeB);

            // Assert
            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void Should_fail_with_descriptive_message_when_asserting_null_value_is_exactly_equal_to_another_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;
            DateTimeOffset expectation = 27.March(2016).ToDateTimeOffset(1.Hours());

            // Act
            Action action = () =>
                nullableDateTime.Should().BeExactly(expectation, "because we want to test the failure {0}", "message");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected nullableDateTime to be exactly <2016-03-27 +1h> because we want to test the failure message, but found a <null> DateTimeOffset.");
        }
    }

    public class NotBeExactly
    {
        [Fact]
        public void Should_succeed_when_asserting_value_is_not_exactly_equal_to_a_different_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset otherDateTime = dateTime.ToUniversalTime();

            // Act / Assert
            dateTime.Should().NotBeExactly(otherDateTime);
        }

        [Fact]
        public void Should_succeed_when_asserting_value_is_not_exactly_equal_to_a_different_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset? otherDateTime = dateTime.ToUniversalTime();

            // Act / Assert
            dateTime.Should().NotBeExactly(otherDateTime);
        }

        [Fact]
        public void Should_fail_when_asserting_value_is_not_exactly_equal_to_the_same_value()
        {
            // Arrange
            var dateTime = new DateTimeOffset(10.March(2012), 1.Hours());
            var sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBeExactly(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect dateTime to be exactly <2012-03-10 +1h> because we want to test the failure message, but it was.");
        }

        [Fact]
        public void Should_fail_when_asserting_value_is_not_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = new(10.March(2012), 1.Hours());
            DateTimeOffset? sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBeExactly(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect dateTime to be exactly <2012-03-10 +1h> because we want to test the failure message, but it was.");
        }
    }

    public class BeCloseTo
    {
        [Fact]
        public void When_asserting_that_time_is_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, -1.Ticks());

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_later_datetimeoffset_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_MinValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.MinValue;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_MaxValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.MaxValue;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_close_to_a_later_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_close_to_an_earlier_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 31, 020, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_later_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 30, 979).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected time to be within 20ms from <2012-03-13 12:15:31 +1H>, but <2012-03-13 12:15:30.979 +1H> was off by 21ms.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 021).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected time to be within 20ms from <2012-03-13 12:15:31 +1h>, but <2012-03-13 12:15:31.021 +1h> was off by 21ms.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_earlier_by_more_than_a_35ms_timespan_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 036).WithOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).WithOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(35));

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected time to be within 35ms from <2012-03-13 12:15:31 +1h>, but <2012-03-13 12:15:31.036 +1h> was off by 36ms.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_35ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 035).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_is_close_to_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset? time = null;
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(5.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected*, but found <null>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_close_to_the_maximum_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MaxValue - 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MaxValue;

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_close_to_the_minimum_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MinValue + 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MinValue;

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }
    }

    public class NotBeCloseTo
    {
        [Fact]
        public void When_asserting_that_time_is_not_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, -1.Ticks());

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("precision")
                .WithMessage("*must be non-negative*");
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_later_datetimeoffset_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_MinValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.MinValue;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_a_datetimeoffset_is_close_to_a_MaxValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.MaxValue;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_close_to_a_later_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Did not expect time to be within 20ms from <2016-06-04 12:15:31 +0h>, but it was <2016-06-04 12:15:30.980 +0h>.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_not_close_to_a_later_datetimeoffset_by_a_20ms_timespan_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect time to be within 20ms from <2016-06-04 12:15:31 +0h>, but it was <2016-06-04 12:15:30.980 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_close_to_an_earlier_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 31, 020, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Did not expect time to be within 20ms from <2016-06-04 12:15:31 +0h>, but it was <2016-06-04 12:15:31.020 +0h>.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_not_close_to_another_value_that_is_later_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 30, 979).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_not_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 021).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_close_to_an_earlier_datetimeoffset_by_35ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 035).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Did not expect time to be within 35ms from <2012-03-13 12:15:31 +1h>, but it was <2012-03-13 12:15:31.035 +1h>.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_is_not_close_to_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset? time = null;
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(5.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect*, but it was <null>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_close_to_the_minimum_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MinValue + 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MinValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Did not expect time to be within 100ms from <0001-01-01 00:00:00.000>, but it was <00:00:00.050 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_close_to_the_maximum_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MaxValue - 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MaxValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage(
                    "Did not expect time to be within 100ms from <9999-12-31 23:59:59.9999999 +0h>, but it was <9999-12-31 23:59:59.9499999 +0h>.");
        }
    }

    public class BeBefore
    {
        [Fact]
        public void When_asserting_a_point_of_time_is_before_a_later_point_it_should_succeed()
        {
            // Arrange
            DateTimeOffset earlierDate = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset laterDate = new(new DateTime(2016, 06, 04, 0, 5, 0), TimeSpan.Zero);

            // Act
            Action act = () => earlierDate.Should().BeBefore(laterDate);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_is_before_earlier_expected_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 03), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeBefore(expected);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be before <2016-06-03 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_before_the_same_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeBefore(expected);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be before <2016-06-04 +0h>, but it was <2016-06-04 +0h>.");
        }
    }

    public class NotBeBefore
    {
        [Fact]
        public void When_asserting_a_point_of_time_is_not_before_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset earlierDate = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset laterDate = new(new DateTime(2016, 06, 04, 0, 5, 0), TimeSpan.Zero);

            // Act
            Action act = () => earlierDate.Should().NotBeBefore(laterDate);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected earlierDate to be on or after <2016-06-04 00:05:00 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_is_not_before_earlier_expected_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 03), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeBefore(expected);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_before_the_same_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeBefore(expected);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class BeOnOrBefore
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_on_or_before_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrBefore(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_on_or_before_the_same_date_as_the_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrBefore(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_on_or_before_earlier_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrBefore(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be on or before <2016-06-03 +0h>, but it was <2016-06-04 +0h>.");
        }
    }

    public class NotBeOnOrBefore
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_on_or_before_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrBefore(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be after <2016-06-05 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_is_on_or_before_the_same_date_as_the_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrBefore(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be after <2016-06-04 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_on_or_before_earlier_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrBefore(expectation);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class BeAfter
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_after_earlier_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_after_later_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject to be after <2016-06-05 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_after_the_same_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject to be after <2016-06-04 +0h>, but it was <2016-06-04 +0h>.");
        }
    }

    public class NotBeAfter
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_after_earlier_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject to be on or before <2016-06-03 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_after_later_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_after_the_same_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class BeOnOrAfter
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_on_or_after_earlier_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_on_or_after_the_same_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_on_or_after_later_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeOnOrAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be on or after <2016-06-05 +0h>, but it was <2016-06-04 +0h>.");
        }
    }

    public class NotBeOnOrAfter
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_on_or_after_earlier_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be before <2016-06-03 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_on_or_after_the_same_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrAfter(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected subject to be before <2016-06-04 +0h>, but it was <2016-06-04 +0h>.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_is_not_on_or_after_later_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeOnOrAfter(expectation);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class HaveYear
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_year_with_the_same_value_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_year_with_a_different_value_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the year part of subject to be 2008, but it was 2009.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_year_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the year part of subject to be 2008, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveYear
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_year_with_the_same_value_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the year part of subject to be 2009, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_year_with_a_different_value_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_year_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the year part of subject to be 2008, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveMonth
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_month_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_a_month_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the month part of subject to be 11, but it was 12.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_month_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the month part of subject to be 12, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveMonth
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_month_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the month part of subject to be 12, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_a_month_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_month_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the month part of subject to be 12, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveDay
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_day_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_day_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the day part of subject to be 30, but it was 31.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_day_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the day part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveDay
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_day_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the day part of subject to be 31, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_day_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_day_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the day part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveHour
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_hour_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 23;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_hour_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the hour part of subject to be 22, but it was 23.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_hour_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the hour part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveHour
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_hour_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 23;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the hour part of subject to be 23, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_hour_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_hour_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the hour part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveMinute
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_minutes_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 59;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_minutes_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 58;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the minute part of subject to be 58, but it was 59.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_minute_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the minute part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveMinute
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_minutes_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 59;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the minute part of subject to be 59, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_minutes_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 58;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_minute_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the minute part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveSecond
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_seconds_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 0;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_seconds_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 1;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the seconds part of subject to be 1, but it was 0.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_second_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the seconds part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveSecond
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_seconds_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 0;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the seconds part of subject to be 0, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_seconds_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 1;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_second_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the seconds part of subject to be 22, but found a <null> DateTimeOffset.");
        }
    }

    public class HaveOffset
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_offset_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.FromHours(7));
            TimeSpan expectation = TimeSpan.FromHours(7);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_offset_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 10), TimeSpan.Zero);
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the offset of subject to be 3h, but it was default.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_have_offset_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the offset of subject to be 3h, but found a <null> DateTimeOffset.");
        }
    }

    public class NotHaveOffset
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_offset_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.FromHours(7));
            TimeSpan expectation = TimeSpan.FromHours(7);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the offset of subject to be 7h, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_offset_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_should_not_have_offset_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the offset of subject to be 3h, but found a <null> DateTimeOffset.");
        }
    }

    public class BeSameDateAs
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_be_same_date_as_another_with_the_same_date_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_should_be_same_as_another_with_same_date_but_different_time_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31, 11, 15, 11), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_to_be_same_date_as_another_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected the date part of subject to be <2009-12-31>, but found a <null> DateTimeOffset.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_have_same_date_as_another_but_it_doesnt_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 30), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected the date part of subject to be <2009-12-30>, but it was <2009-12-31>.");
        }
    }

    public class NotBeSameDateAs
    {
        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_be_same_date_as_another_with_the_same_date_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the date part of subject to be <2009-12-31>, but it was.");
        }

        [Fact]
        public void
            When_asserting_subject_datetimeoffset_should_not_be_same_as_another_with_same_date_but_different_time_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31, 11, 15, 11), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the date part of subject to be <2009-12-31>, but it was.");
        }

        [Fact]
        public void When_asserting_subject_null_datetimeoffset_to_not_be_same_date_as_another_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Did not expect the date part of subject to be <2009-12-31>, but found a <null> DateTimeOffset.");
        }

        [Fact]
        public void When_asserting_subject_datetimeoffset_should_not_have_same_date_as_another_but_it_doesnt_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 30), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            act.Should().NotThrow();
        }
    }

    public class TimespanComparison
    {
        [Fact]
        public void When_date_is_not_more_than_the_required_one_day_before_another_it_should_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009), 0.Hours());
            DateTimeOffset subject = target - 1.Days();

            // Act
            Action act = () => subject.Should().BeMoreThan(TimeSpan.FromDays(1)).Before(target, "we like {0}", "that");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject <2009-10-01 +0h> to be more than 1d before <2009-10-02 +0h> because we like that, but it is behind by 1d.");
        }

        [Fact]
        public void When_date_is_more_than_the_required_one_day_before_another_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009));
            DateTimeOffset subject = target - 25.Hours();

            // Act / Assert
            subject.Should().BeMoreThan(TimeSpan.FromDays(1)).Before(target);
        }

        [Fact]
        public void When_date_is_not_at_least_one_day_before_another_it_should_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009), 0.Hours());
            DateTimeOffset subject = target - 23.Hours();

            // Act
            Action act = () => subject.Should().BeAtLeast(TimeSpan.FromDays(1)).Before(target, "we like {0}", "that");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject <2009-10-01 01:00:00 +0h> to be at least 1d before <2009-10-02 +0h> because we like that, but it is behind by 23h.");
        }

        [Fact]
        public void When_date_is_at_least_one_day_before_another_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009));
            DateTimeOffset subject = target - 24.Hours();

            // Act / Assert
            subject.Should().BeAtLeast(TimeSpan.FromDays(1)).Before(target);
        }

        [Fact]
        public void When_time_is_not_at_exactly_20_minutes_before_another_time_it_should_throw()
        {
            // Arrange
            DateTimeOffset target = 1.January(0001).At(12, 55).ToDateTimeOffset();
            DateTimeOffset subject = 1.January(0001).At(12, 36).ToDateTimeOffset();

            // Act
            Action act =
                () => subject.Should().BeExactly(TimeSpan.FromMinutes(20)).Before(target, "{0} minutes is enough", 20);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject <12:36:00 +0h> to be exactly 20m before <12:55:00 +0h> because 20 minutes is enough, but it is behind by 19m.");
        }

        [Fact]
        public void When_time_is_exactly_90_seconds_before_another_time_it_should_not_throw()
        {
            // Arrange
            DateTimeOffset target = 1.January(0001).At(12, 55).ToDateTimeOffset();
            DateTimeOffset subject = 1.January(0001).At(12, 53, 30).ToDateTimeOffset();

            // Act / Assert
            subject.Should().BeExactly(TimeSpan.FromSeconds(90)).Before(target);
        }

        [Fact]
        public void When_date_is_not_within_50_hours_before_another_date_it_should_throw()
        {
            // Arrange
            var target = 10.April(2010).At(12, 0).WithOffset(0.Hours());
            DateTimeOffset subject = target - 50.Hours() - 1.Seconds();

            // Act
            Action act =
                () => subject.Should().BeWithin(TimeSpan.FromHours(50)).Before(target, "{0} hours is enough", 50);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject <2010-04-08 09:59:59 +0h> to be within 2d and 2h before <2010-04-10 12:00:00 +0h> because 50 hours is enough, but it is behind by 2d, 2h and 1s.");
        }

        [Fact]
        public void When_date_is_exactly_within_1d_before_another_date_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(10.April(2010));
            DateTimeOffset subject = target - 1.Days();

            // Act / Assert
            subject.Should().BeWithin(TimeSpan.FromHours(24)).Before(target);
        }

        [Fact]
        public void When_date_is_within_1d_before_another_date_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(10.April(2010));
            DateTimeOffset subject = target - 23.Hours();

            // Act / Assert
            subject.Should().BeWithin(TimeSpan.FromHours(24)).Before(target);
        }

        [Fact]
        public void When_a_utc_date_is_within_0s_before_itself_it_should_not_throw()
        {
            // Arrange
            var date = DateTimeOffset.UtcNow; // local timezone differs from +0h

            // Act / Assert
            date.Should().BeWithin(TimeSpan.Zero).Before(date);
        }

        [Fact]
        public void When_a_utc_date_is_within_0s_after_itself_it_should_not_throw()
        {
            // Arrange
            var date = DateTimeOffset.UtcNow; // local timezone differs from +0h

            // Act / Assert
            date.Should().BeWithin(TimeSpan.Zero).After(date);
        }

        [Fact]
        public void When_time_is_not_less_than_30s_after_another_time_it_should_throw()
        {
            // Arrange
            var target = 1.January(1).At(12, 0, 30).WithOffset(1.Hours());
            DateTimeOffset subject = target + 30.Seconds();

            // Act
            Action act =
                () => subject.Should().BeLessThan(TimeSpan.FromSeconds(30)).After(target, "{0}s is the max", 30);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected subject <12:01:00 +1h> to be less than 30s after <12:00:30 +1h> because 30s is the max, but it is ahead by 30s.");
        }

        [Fact]
        public void When_time_is_less_than_30s_after_another_time_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(1.January(1).At(12, 0, 30));
            DateTimeOffset subject = target + 20.Seconds();

            // Act / Assert
            subject.Should().BeLessThan(TimeSpan.FromSeconds(30)).After(target);
        }

        [Fact]
        public void When_asserting_subject_be_more_than_10_seconds_after_target_but_subject_is_before_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 15).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeMoreThan(10.Seconds()).After(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected subject <00:00:15 +0h> to be more than 10s after <00:00:30 +0h>, but it is behind by 15s.");
        }

        [Theory]
        [InlineData(30, 20)] // edge case
        [InlineData(30, 15)]
        public void When_asserting_subject_be_at_least_10_seconds_after_target_but_subject_is_before_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeAtLeast(10.Seconds()).After(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    $"Expected subject <00:00:{subjectSeconds} +0h> to be at least 10s after <00:00:30 +0h>, but it is behind by {Math.Abs(subjectSeconds - targetSeconds)}s.");
        }

        [Fact]
        public void When_asserting_subject_be_exactly_10_seconds_after_target_but_subject_is_before_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 20).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeExactly(10.Seconds()).After(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("Expected subject <00:00:20 +0h> to be exactly 10s after <00:00:30 +0h>, but it is behind by 10s.");
        }

        [Theory]
        [InlineData(30, 20)] // edge case
        [InlineData(30, 25)]
        public void When_asserting_subject_be_within_10_seconds_after_target_but_subject_is_before_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeWithin(10.Seconds()).After(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    $"Expected subject <00:00:{subjectSeconds} +0h> to be within 10s after <00:00:30 +0h>, but it is behind by {Math.Abs(subjectSeconds - targetSeconds)}s.");
        }

        [Fact]
        public void When_asserting_subject_be_less_than_10_seconds_after_target_but_subject_is_before_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 25).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeLessThan(10.Seconds()).After(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("Expected subject <00:00:25 +0h> to be less than 10s after <00:00:30 +0h>, but it is behind by 5s.");
        }

        [Fact]
        public void When_asserting_subject_be_more_than_10_seconds_before_target_but_subject_is_after_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 45).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeMoreThan(10.Seconds()).Before(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected subject <00:00:45 +0h> to be more than 10s before <00:00:30 +0h>, but it is ahead by 15s.");
        }

        [Theory]
        [InlineData(30, 40)] // edge case
        [InlineData(30, 45)]
        public void When_asserting_subject_be_at_least_10_seconds_before_target_but_subject_is_after_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeAtLeast(10.Seconds()).Before(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    $"Expected subject <00:00:{subjectSeconds} +0h> to be at least 10s before <00:00:30 +0h>, but it is ahead by {Math.Abs(subjectSeconds - targetSeconds)}s.");
        }

        [Fact]
        public void When_asserting_subject_be_exactly_10_seconds_before_target_but_subject_is_after_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 40).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeExactly(10.Seconds()).Before(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("Expected subject <00:00:40 +0h> to be exactly 10s before <00:00:30 +0h>, but it is ahead by 10s.");
        }

        [Theory]
        [InlineData(30, 40)] // edge case
        [InlineData(30, 35)]
        public void When_asserting_subject_be_within_10_seconds_before_target_but_subject_is_after_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeWithin(10.Seconds()).Before(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    $"Expected subject <00:00:{subjectSeconds} +0h> to be within 10s before <00:00:30 +0h>, but it is ahead by {Math.Abs(subjectSeconds - targetSeconds)}s.");
        }

        [Fact]
        public void When_asserting_subject_be_less_than_10_seconds_before_target_but_subject_is_after_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 45).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeLessThan(10.Seconds()).Before(expectation);

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage(
                    "Expected subject <00:00:45 +0h> to be less than 10s before <00:00:30 +0h>, but it is ahead by 15s.");
        }

        [Fact]
        public void Should_throw_a_helpful_error_when_accidentally_using_equals_with_a_range()
        {
            // Arrange
            DateTimeOffset someDateTimeOffset = new(2022, 9, 25, 13, 48, 42, 0, TimeSpan.Zero);

            // Act
            var action = () => someDateTimeOffset.Should().BeLessThan(0.Seconds()).Equals(null);

            // Assert
            action.Should().Throw<NotSupportedException>()
                .WithMessage("Equals is not part of Fluent Assertions. Did you mean Before() or After() instead?");
        }
    }

    public class ChainingConstraint
    {
        [Fact]
        public void Should_support_chaining_constraints_with_and()
        {
            // Arrange
            DateTimeOffset yesterday = new DateTime(2016, 06, 03).ToDateTimeOffset();
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTime.Should()
                    .HaveValue()
                    .And
                    .BeAfter(yesterday);

            // Assert
            action.Should().NotThrow();
        }
    }

    public class BeOneOf
    {
        [Fact]
        public void When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());

            // Act
            Action action = () => value.Should().BeOneOf(value + 1.Days(), value + 4.Hours());

            // Assert
            action.Should().Throw<XunitException>().WithMessage(
                "Expected value to be one of {<2017-01-01 +1h>, <2016-12-31 04:00:00 +1h>}, but it was <2016-12-31 +1h>.");
        }

        [Fact]
        public void When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            DateTimeOffset value = 31.December(2016).WithOffset(1.Hours());

            // Act
            Action action = () => value.Should().BeOneOf(new[] { value + 1.Days(), value + 2.Days() }, "because it's true");

            // Assert
            action.Should().Throw<XunitException>().WithMessage(
                "Expected value to be one of {<2017-01-01 +1h>, <2017-01-02 +1h>} because it's true, but it was <2016-12-31 +1h>.");
        }

        [Fact]
        public void When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            DateTimeOffset value = new(2016, 12, 30, 23, 58, 57, TimeSpan.FromHours(4));

            // Act
            Action action = () => value.Should().BeOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.FromHours(2)),
                new DateTimeOffset(2016, 12, 30, 23, 58, 57, TimeSpan.FromHours(4)));

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void When_a_null_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateTimeOffset? value = null;

            // Act
            Action action = () => value.Should().BeOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.FromHours(1)),
                new DateTimeOffset(2016, 2, 10, 2, 45, 7, TimeSpan.FromHours(2)));

            // Assert
            action.Should().Throw<XunitException>().WithMessage(
                "Expected value to be one of {<2216-01-30 00:05:07 +1h>, <2016-02-10 02:45:07 +2h>}, but it was <null>.");
        }

        [Fact]
        public void When_a_value_is_one_of_the_specified_values_it_should_succeed_when_datetimeoffset_is_null()
        {
            // Arrange
            DateTimeOffset? value = null;

            // Act
            Action action = () => value.Should().BeOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.Zero), null);

            // Assert
            action.Should().NotThrow();
        }
    }

    public class Miscellaneous
    {
        [Fact]
        public void Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            DateTimeOffset someDateTimeOffset = new(2022, 9, 25, 13, 48, 42, 0, TimeSpan.Zero);

            // Act
            var action = () => someDateTimeOffset.Should().Equals(null);

            // Assert
            action.Should().Throw<NotSupportedException>()
                .WithMessage("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
        }
    }
}
