public interface IHPConttroller
{
    public int CurrentHP { get; }
    public int MaxHP { get; }
    public void SetMaxHP(int hp);
    public void TakesDamage(int damage);
    public void TakesHeal(int heal);
}