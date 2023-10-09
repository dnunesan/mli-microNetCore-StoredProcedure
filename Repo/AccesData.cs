namespace mli_microNetCore_StoredProcedure.Repo
{
    public class AccesData
    {
        private string conectionSQL;

        public string publicConectionSQL { get => conectionSQL; }

        public AccesData(string conectionBD)
        {
            conectionSQL = conectionBD;
        }
    }
}
