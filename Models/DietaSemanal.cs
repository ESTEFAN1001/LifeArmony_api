namespace LifeArmony_api.Models
{
    public class DietaSemanal
    {
        public string dia { get; set; }
        public List<string> alimentos { get; set; }
        public List<string> porciones { get; set; }

        public DietaSemanal(string dia, List<string> alimentos, List<string> porciones)
        {
            this.dia = dia;
            this.alimentos = alimentos;
            this.porciones = porciones;
        }
    }
}
