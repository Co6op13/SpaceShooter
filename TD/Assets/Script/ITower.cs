internal interface ITower
{
    public void TowerSelected();
    public void TowerDeselected();
    public void SetMaxHP(int maxHP);
    public void SetAttackDistance(float distance);
}