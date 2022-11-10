using System.Collections;
internal interface IHPConttrollerTower : IHPConttroller
{
    public void RepairTower(float timeTick, int hpRecoveryInOneTick);
}