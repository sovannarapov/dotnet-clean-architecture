using SharedKernel;

namespace Infrastructure.Time;

internal sealed class DateTimeProvider : TimeProvider
{
    public override DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;

    public override ITimer CreateTimer(TimerCallback callback, object? state, TimeSpan dueTime, TimeSpan period)
    {
        return new Timer(callback, state, dueTime, period);
    }
}
