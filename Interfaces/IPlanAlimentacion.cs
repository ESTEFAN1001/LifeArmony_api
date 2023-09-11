using LifeArmony_api.Models;
using static LifeArmony_api.Interfaces.IPlanAlimentacion;
using LifeArmony_api.Interfaces.ICrud;


namespace LifeArmony_api.Interfaces
{
    public interface IPlanAlimentacion : IInsertOne<PlanAlimentacion>, ISelectMany<PlanAlimentacion>, ISelectOne<PlanAlimentacion>, IUpdateOne<PlanAlimentacion>, IDeleteOne<PlanAlimentacion>
    {

    }
}
