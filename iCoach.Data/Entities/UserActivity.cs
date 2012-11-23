namespace iCoach.Data.Entities
{
    public abstract class UserActivity: ActionStampableIdableEntity
    {}

    
    public class UserRegistered: UserActivity
    {}

    public class UserLogin: UserActivity
    {}
}
