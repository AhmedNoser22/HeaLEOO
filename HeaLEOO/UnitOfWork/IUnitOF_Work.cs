namespace HeaLEOO.UnitOfWork
{
    public interface IUnitOF_Work: IDisposable
    {
        IGenericRepo<Clinics> GetRepoCliinics { get; }
        IGenericRepo<Doctors> GetRepoDoctors { get; }
        IGenericRepo<Appointments> GetRepoAppointments { get; }
        IGenericRepo<ModelService> GetRepoModelService { get; }
        IGenericRepo<Specializations> GetRepoSpecializations { get; }
        Task<bool> Complete();
    }
}
