namespace Tasks.Mapper
{
    public static class EnumMapper
    {
        public static Entity.ETaskStatus ToEntityETaskStatus(this Models.ETaskStatus status)
        {
            return status switch
            {
                Models.ETaskStatus.Completed => Entity.ETaskStatus.Completed,
                Models.ETaskStatus.InProgress => Entity.ETaskStatus.InProgress,
                Models.ETaskStatus.Postponed => Entity.ETaskStatus.Postponed,
                _ => Entity.ETaskStatus.None
            };
        }
        public static Entity.ETaskRepeat ToEntityETaskRepeat(this Models.ETaskRepeat repeat)
        {
            return repeat switch
            {
                Models.ETaskRepeat.Daily => Entity.ETaskRepeat.Daily,
                Models.ETaskRepeat.Hourly => Entity.ETaskRepeat.Hourly,
                Models.ETaskRepeat.Weekly => Entity.ETaskRepeat.Weekly,
                Models.ETaskRepeat.Monthly => Entity.ETaskRepeat.Monthly,
                Models.ETaskRepeat.Yearly => Entity.ETaskRepeat.Yearly,
                _ => Entity.ETaskRepeat.Never
            };
        }
        public static Entity.ETaskPriority ToEntityETaskPriority(this Models.ETaskPriority priority)
        {
            return priority switch
            {
                Models.ETaskPriority.High => Entity.ETaskPriority.High,
                Models.ETaskPriority.Mid => Entity.ETaskPriority.Mid,
                Models.ETaskPriority.Low => Entity.ETaskPriority.Low,
                _ => Entity.ETaskPriority.None
            };
        }
    }
}