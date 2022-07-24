namespace School;

public static class RoomTypeExt
{
    public static readonly IDictionary<int, string> RoomTypes = new Dictionary<int, string>()
    {
        { (int)RoomType.Regular, nameof(RoomType.Regular) },
        { (int)RoomType.Math, nameof(RoomType.Math) },
        { (int)RoomType.Biology, nameof(RoomType.Biology) },
        { (int)RoomType.Literature, nameof(RoomType.Literature) },
        { (int)RoomType.Informatic, nameof(RoomType.Informatic) },
        { (int)RoomType.Gym, nameof(RoomType.Gym) },
        { (int)RoomType.Physics, nameof(RoomType.Physics) },
        { (int)RoomType.Hall, nameof(RoomType.Hall) },
        { (int)RoomType.Workshop, nameof(RoomType.Workshop) }
};
}